using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public static class SceneHierarchyUtility
	{
        private static readonly Type sceneHierarchyWindowType;
        private static readonly Type sceneHierarchyType;

        private static readonly PropertyInfo sceneHierarchyProp;
        private static readonly MethodInfo getExpandedMethod;
        private static readonly MethodInfo setExpandedMethod;

        static SceneHierarchyUtility()
        {
            sceneHierarchyWindowType = typeof(Editor).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
            if (sceneHierarchyWindowType == null)
                throw new NullReferenceException("Couldn't find the reference to the SceneHierarchyWindow");

            sceneHierarchyType = typeof(Editor).Assembly.GetType("UnityEditor.SceneHierarchy");
            if (sceneHierarchyType == null)
                throw new NullReferenceException("Couldn't find the reference to the SceneHierarchy");

            sceneHierarchyProp = sceneHierarchyWindowType.GetProperty("sceneHierarchy");
            if (sceneHierarchyProp == null)
                throw new NullReferenceException("Couldn't find the reference to the SceneHierarchy in the SceneHierarchyWindow");

            getExpandedMethod = sceneHierarchyType.GetMethod("GetExpandedIDs");
            if (getExpandedMethod == null)
                throw new NullReferenceException("Couldn't find the reference to the GetExpandedIDs method in the SceneHierarchy");

            setExpandedMethod = sceneHierarchyType.GetMethod("SetExpandedRecursive");
            if (setExpandedMethod == null)
                throw new NullReferenceException("Couldn't find the reference to the SetExpandedRecursive method in the SceneHierarchy");
        }

        public static bool GetExpanded(EntityId instanceID)
        {
            object sceneHierarchy = GetSceneHierarchy();
            EntityId[] ids = (EntityId[])getExpandedMethod.Invoke(sceneHierarchy, new object[] { });
            return ids.Contains(instanceID);
        }

        public static void SetExpanded(EntityId instanceID, bool expanded)
        {
            object sceneHierarchy = GetSceneHierarchy();
            setExpandedMethod.Invoke(sceneHierarchy, new object[] { instanceID, expanded });
        }

        private static EditorWindow GetHierarchyWindow()
        {
            return EditorWindow.GetWindow(sceneHierarchyWindowType);
        }

        private static object GetSceneHierarchy()
        {
            return sceneHierarchyProp.GetValue(GetHierarchyWindow());
        }
    }
}