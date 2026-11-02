using System;

namespace BehaviorTree
{
    /// <summary>
    /// Node metadata
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class NodeInfoAttribute : Attribute
    {
        /// <summary>The display name for this node type</summary>
        public string DisplayName { get; }

        /// <summary>The category this node type is grouped under</summary>
        public string Category { get; }

        /// <summary>Description of what this node does</summary>
        public string Description { get; }

        /// <summary>Creates the attribute</summary>
        /// <param name="displayName">The display name for this node</param>
        /// <param name="category">The category this node type is grouped under</param>
        /// <param name="description">Description of what this node does</param>
        public NodeInfoAttribute(string displayName, string category = "General", string description = "")
        {
            DisplayName = displayName;
            Category = category;
            Description = description;
        }
    }
}