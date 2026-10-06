using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using BehaviorTreeInstance = BehaviorTree.BehaviorTree;

namespace BehaviorTree.Editor
{
    public class BehaviorTreeViewerWindow : EditorWindow, IBehaviorTreeDebugger
    {
        private static readonly Color RunningColor = new(0.36f, 0.55f, 0.84f);
        private static readonly Color SuccessColor = new(0.30f, 0.69f, 0.31f);
        private static readonly Color FailureColor = new(0.88f, 0.33f, 0.33f);
        private static readonly Color IdleColor = new(0.3f, 0.3f, 0.3f);

        private const float ConnectorGap = 18f;
        private const float SiblingGap = 14f;

        /// <summary>The agent this window is showing. Serialized so it survives a domain reload while the window stays open.</summary>
        [SerializeField] private BehaviorTreeRunner runner;

        private BehaviorTreeInstance boundTree;
        private VisualElement treeContainer;

        /// <summary>Maps every node currently drawn to its box, so debugger callbacks can recolor it.</summary>
        private readonly Dictionary<Node, VisualElement> nodeBoxes = new Dictionary<Node, VisualElement>();

        /// <summary>Maps every ConditionGuard's condition to its small status dot</summary>
        private readonly Dictionary<Node, VisualElement> conditionBadges = new Dictionary<Node, VisualElement>();

        private static Color ConnectorColor => EditorGUIUtility.isProSkin ? new Color(0.65f, 0.65f, 0.65f) : new Color(0.25f, 0.25f, 0.25f);

        private static Color NeutralShapeColor => EditorGUIUtility.isProSkin ? new Color(0.75f, 0.75f, 0.75f) : new Color(0.2f, 0.2f, 0.2f);

        // Sharp rectangle = flow control (Root/Composite),
        // Pill = Decorator,
        // lightly rounded = leaf (Action/Condition).
        private const float CompositeCornerRadius = 0f;
        private const float DecoratorCornerRadius = 14f;
        private const float LeafCornerRadius = 4f;

        public static void Open(BehaviorTreeRunner target)
        {
            BehaviorTreeViewerWindow window = CreateInstance<BehaviorTreeViewerWindow>();
            window.runner = target;
            window.titleContent = new GUIContent($"Tree Viewer - {target.name}");
            window.Show();
        }

        private void CreateGUI()
        {
            ScrollView scrollView = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
            treeContainer = new VisualElement();
            treeContainer.style.paddingLeft = 8;
            treeContainer.style.paddingTop = 8;
            treeContainer.style.paddingRight = 8;
            treeContainer.style.paddingBottom = 8;
            scrollView.Add(treeContainer);

            rootVisualElement.Add(scrollView);
            rootVisualElement.Add(CreateLegend());

            RebuildTree();
        }

        private void OnEnable()
        {
            EditorApplication.update += OnEditorUpdate;
        }

        private void OnDisable()
        {
            EditorApplication.update -= OnEditorUpdate;
            DetachDebugger();
        }

        private void OnEditorUpdate()
        {
            BehaviorTreeInstance currentTree = runner != null ? runner.Tree : null;

            if (!ReferenceEquals(currentTree, boundTree))
                RebuildTree();
        }

        private void DetachDebugger()
        {
            boundTree?.RemoveDebugger(this);
        }

        private void RebuildTree()
        {
            if (treeContainer == null)
                return;

            DetachDebugger();
            nodeBoxes.Clear();
            conditionBadges.Clear();
            treeContainer.Clear();

            if (runner == null)
            {
                boundTree = null;
                treeContainer.Add(new Label("No agent assigned."));
                return;
            }

            boundTree = runner.Tree;

            if (boundTree == null)
            {
                var message = Application.isPlaying
                    ? $"'{runner.name}' has no active tree (component disabled?)."
                    : "Enter Play Mode to visualize this tree.";
                treeContainer.Add(new Label(message));
                return;
            }

            boundTree.AddDebugger(this);
            treeContainer.Add(BuildNodeElement(boundTree.Root));
        }

        /// <summary>
        /// Recursively builds one node's visual element and, if it has children,
        /// theirs too. Each node is laid out as a "column": its own box, centered above
        /// a row of its children's columns. Centering (rather than left-aligning) makes
        /// the parent/children relationship visually obvious, and a connector line is
        /// drawn from the parent's bottom edge to each child's top edge.
        /// </summary>
        private VisualElement BuildNodeElement(Node node)
        {
            VisualElement column = new VisualElement();
            column.style.alignItems = Align.Center;
            column.style.marginRight = SiblingGap;

            VisualElement box = CreateNodeBox(node);
            column.Add(box);

            IReadOnlyList<Node> children = node.GetChildren();

            if (children.Count > 0)
            {
                VisualElement childrenRow = new VisualElement();
                childrenRow.style.flexDirection = FlexDirection.Row;
                childrenRow.style.marginTop = ConnectorGap;

                List<VisualElement> childBoxes = new List<VisualElement>(children.Count);

                foreach (Node child in children)
                {
                    childrenRow.Add(BuildNodeElement(child));
                    childBoxes.Add(nodeBoxes[child]);
                }

                column.Add(childrenRow);
                RegisterConnectors(column, box, childBoxes);
            }

            return column;
        }

        /// <summary>Wires up connector-line drawing for a node and keeps it redrawn as layout changes.</summary>
        private static void RegisterConnectors(VisualElement column, VisualElement parentBox, List<VisualElement> childBoxes)
        {
            column.generateVisualContent += ctx => DrawConnectors(ctx, column, parentBox, childBoxes);

            void RequestRedraw(GeometryChangedEvent _) => column.MarkDirtyRepaint();

            column.RegisterCallback<GeometryChangedEvent>(RequestRedraw);
            parentBox.RegisterCallback<GeometryChangedEvent>(RequestRedraw);
            foreach (VisualElement childBox in childBoxes)
                childBox.RegisterCallback<GeometryChangedEvent>(RequestRedraw);
        }

        /// <summary>Draws a straight line from parent's bottom-center to each child box's top-center, in column's local space.</summary>
        private static void DrawConnectors(MeshGenerationContext ctx, VisualElement column, VisualElement parentBox, List<VisualElement> childBoxes)
        {
            Painter2D painter = ctx.painter2D;
            painter.strokeColor = ConnectorColor;
            painter.lineWidth = 2f;

            Vector2 start = column.WorldToLocal(parentBox.LocalToWorld(new Vector2(parentBox.layout.width * 0.5f, parentBox.layout.height)));

            painter.BeginPath();

            foreach (VisualElement childBox in childBoxes)
            {
                Vector2 end = column.WorldToLocal(childBox.LocalToWorld(new Vector2(childBox.layout.width * 0.5f, 0f)));

                painter.MoveTo(start);
                painter.LineTo(end);
            }

            painter.Stroke();
        }

        /// <summary>Builds one node's box: shape by category, label, and ConditionGuard its condition badge.</summary>
        private VisualElement CreateNodeBox(Node node)
        {
            VisualElement box = new VisualElement();
            box.style.flexDirection = FlexDirection.Row;
            box.style.alignItems = Align.Center;
            box.style.borderTopWidth = 2;
            box.style.borderBottomWidth = 2;
            box.style.borderLeftWidth = 2;
            box.style.borderRightWidth = 2;
            box.style.paddingLeft = 6;
            box.style.paddingRight = 6;
            box.style.paddingTop = 3;
            box.style.paddingBottom = 3;

            ApplyShapeForCategory(box, node);
            box.Add(new Label(GetDisplayName(node)));

            // The guard's own border already reflects the combined guard+child result;
            // this dot separately shows the condition's own live true/false value, so
            // "gate closed" and "child ran and failed" don't look identical.
            if (node is ConditionGuard guard)
                box.Add(CreateConditionBadge(guard.Condition));

            nodeBoxes[node] = box;
            ApplyInitialStatusColor(box, node);

            return box;
        }

        /// <summary>Builds a small status dot for a guard's condition and registers it for live updates.</summary>
        private VisualElement CreateConditionBadge(ConditionNode condition)
        {
            VisualElement badge = CreateDot(8f);
            badge.style.marginLeft = 5;

            conditionBadges[condition] = badge;
            ApplyInitialBadgeColor(badge, condition);

            return badge;
        }

        /// <summary>Creates a small filled circle of the given diameter (no color set yet).</summary>
        private static VisualElement CreateDot(float diameter)
        {
            VisualElement dot = new VisualElement();
            dot.style.width = diameter;
            dot.style.height = diameter;

            float radius = diameter / 2f;
            dot.style.borderTopLeftRadius = radius;
            dot.style.borderTopRightRadius = radius;
            dot.style.borderBottomLeftRadius = radius;
            dot.style.borderBottomRightRadius = radius;

            return dot;
        }

        /// <summary>Applies the corner radius that signals a node's category (see the constants above).</summary>
        private static void ApplyShapeForCategory(VisualElement box, Node node)
        {
            float radius = node switch
            {
                Root or Composite => CompositeCornerRadius,
                Decorator => DecoratorCornerRadius,
                _ => LeafCornerRadius
            };

            box.style.borderTopLeftRadius = radius;
            box.style.borderTopRightRadius = radius;
            box.style.borderBottomLeftRadius = radius;
            box.style.borderBottomRightRadius = radius;
        }

        /// <summary>
        /// The text shown on a node's box: its NodeInfoAttribute.DisplayName if present, else its type name.
        /// A ConditionGuard has exactly one traversed child, its condition is folded into this label instead of shown as a separate node.
        /// </summary>
        private static string GetDisplayName(Node node)
        {
            if (node is ConditionGuard guard)
                return $"{GetDisplayName(guard.Condition)} ({GetOwnDisplayName(guard)})";

            return GetOwnDisplayName(node);
        }

        /// <summary>The display name for a node's own type</summary>
        private static string GetOwnDisplayName(Node node)
        {
            NodeInfoAttribute info = node.GetType().GetCustomAttribute<NodeInfoAttribute>();
            return info != null ? info.DisplayName : node.GetType().Name;
        }

        /// <summary>
        /// Sets a box's initial border color
        /// </summary>
        private static void ApplyInitialStatusColor(VisualElement box, Node node)
        {
            SetBorderColor(box, node.HasTicked ? StatusToColor(node.Status) : IdleColor);
        }

        /// <summary>Sets a box's border color for a known, real status</summary>
        private static void ApplyStatusColor(VisualElement box, NodeStatus status)
        {
            SetBorderColor(box, StatusToColor(status));
        }

        private static Color StatusToColor(NodeStatus status) => status switch
        {
            NodeStatus.Running => RunningColor,
            NodeStatus.Success => SuccessColor,
            NodeStatus.Failure => FailureColor,
            _ => IdleColor
        };

        private static void SetBorderColor(VisualElement box, Color color)
        {
            box.style.borderTopColor = color;
            box.style.borderBottomColor = color;
            box.style.borderLeftColor = color;
            box.style.borderRightColor = color;
        }

        /// <summary>Sets a condition badge's initial fill color</summary>
        private static void ApplyInitialBadgeColor(VisualElement badge, ConditionNode condition)
        {
            badge.style.backgroundColor = condition.HasTicked ? ConditionToColor(condition.Status) : IdleColor;
        }

        /// <summary>Sets a condition badge's fill color for a known, real status.</summary>
        private static void ApplyBadgeColor(VisualElement badge, NodeStatus status)
        {
            badge.style.backgroundColor = ConditionToColor(status);
        }

        /// <summary>A ConditionNode only ever resolves to Success or Failure (never Running).</summary>
        private static Color ConditionToColor(NodeStatus status) => status == NodeStatus.Success ? SuccessColor : FailureColor;

        /// <summary>Builds the bottom-right overlay explaining status colors, node shapes, and the condition dot.</summary>
        private static VisualElement CreateLegend()
        {
            VisualElement legend = new VisualElement();
            legend.style.position = Position.Absolute;
            legend.style.right = 8;
            legend.style.bottom = 8;
            legend.style.backgroundColor = new Color(0f, 0f, 0f, 0.6f);
            legend.style.paddingLeft = 8;
            legend.style.paddingRight = 8;
            legend.style.paddingTop = 6;
            legend.style.paddingBottom = 6;
            legend.style.borderTopLeftRadius = 4;
            legend.style.borderTopRightRadius = 4;
            legend.style.borderBottomLeftRadius = 4;
            legend.style.borderBottomRightRadius = 4;

            legend.Add(CreateLegendRow(RunningColor, "Running"));
            legend.Add(CreateLegendRow(SuccessColor, "Success"));
            legend.Add(CreateLegendRow(FailureColor, "Failure"));
            legend.Add(CreateLegendRow(IdleColor, "Idle / not yet run"));

            VisualElement divider = new VisualElement();
            divider.style.height = 1;
            divider.style.marginTop = 4;
            divider.style.marginBottom = 4;
            divider.style.backgroundColor = new Color(1f, 1f, 1f, 0.2f);
            legend.Add(divider);

            legend.Add(CreateShapeLegendRow(CompositeCornerRadius, "Composite / Root"));
            legend.Add(CreateShapeLegendRow(DecoratorCornerRadius, "Decorator"));
            legend.Add(CreateShapeLegendRow(LeafCornerRadius, "Leaf (Action/Condition)"));

            VisualElement dot = CreateDot(8f);
            dot.style.marginRight = 6;
            dot.style.backgroundColor = NeutralShapeColor;

            VisualElement dotRow = CreateLegendRowContainer();
            dotRow.Add(dot);
            dotRow.Add(new Label("Dot = guard's condition value"));
            legend.Add(dotRow);

            return legend;
        }

        private static VisualElement CreateLegendRowContainer()
        {
            VisualElement row = new VisualElement();
            row.style.flexDirection = FlexDirection.Row;
            row.style.alignItems = Align.Center;
            row.style.marginBottom = 2;
            return row;
        }

        /// <summary>Builds a legend row with a solid colored square swatch (used for status colors).</summary>
        private static VisualElement CreateLegendRow(Color color, string label)
        {
            VisualElement row = CreateLegendRowContainer();

            VisualElement swatch = new VisualElement();
            swatch.style.width = 10;
            swatch.style.height = 10;
            swatch.style.marginRight = 6;
            swatch.style.backgroundColor = color;
            swatch.style.borderTopLeftRadius = 2;
            swatch.style.borderTopRightRadius = 2;
            swatch.style.borderBottomLeftRadius = 2;
            swatch.style.borderBottomRightRadius = 2;

            row.Add(swatch);
            row.Add(new Label(label));

            return row;
        }

        /// <summary>Builds a legend row with an outlined swatch matching a node-category shape (used for the shape legend).</summary>
        private static VisualElement CreateShapeLegendRow(float radius, string label)
        {
            VisualElement row = CreateLegendRowContainer();

            VisualElement swatch = new VisualElement();
            swatch.style.width = 16;
            swatch.style.height = 10;
            swatch.style.marginRight = 6;
            swatch.style.borderTopWidth = 1.5f;
            swatch.style.borderBottomWidth = 1.5f;
            swatch.style.borderLeftWidth = 1.5f;
            swatch.style.borderRightWidth = 1.5f;
            swatch.style.borderTopColor = NeutralShapeColor;
            swatch.style.borderBottomColor = NeutralShapeColor;
            swatch.style.borderLeftColor = NeutralShapeColor;
            swatch.style.borderRightColor = NeutralShapeColor;
            swatch.style.borderTopLeftRadius = radius;
            swatch.style.borderTopRightRadius = radius;
            swatch.style.borderBottomLeftRadius = radius;
            swatch.style.borderBottomRightRadius = radius;

            row.Add(swatch);
            row.Add(new Label(label));

            return row;
        }

        /// <inheritdoc/>
        void IBehaviorTreeDebugger.OnNodeEnter(Node node)
        {
            if (nodeBoxes.TryGetValue(node, out VisualElement box))
            {
                ApplyStatusColor(box, NodeStatus.Running);
                Repaint();
            }
        }

        /// <inheritdoc/>
        void IBehaviorTreeDebugger.OnNodeExit(Node node, NodeStatus status)
        {
            if (nodeBoxes.TryGetValue(node, out VisualElement box))
            {
                ApplyStatusColor(box, status);
                Repaint();
            }

            if (conditionBadges.TryGetValue(node, out VisualElement badge))
            {
                ApplyBadgeColor(badge, status);
                Repaint();
            }
        }
    }
}