using System;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
	public static class HexGridExtensions
	{
        /// <summary>
        /// Instantiate a game object in a certain grid position
        /// </summary>
        /// <param name="axialCoord">The grid position to instantiate the object on</param>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for the instantiated object</param>
        /// <param name="onGameObjectSpawned">Action to execute when the object is instantiated</param>
        /// <returns>The instantiated game object</returns>
        public static GameObject InstantiateGameObjectAtAxialCoord<T>(this HexGrid<T> hexGrid, AxialCoord axialCoord, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null)
        {
            GameObject spawnedGameObject = GameObject.Instantiate(gameObjectPrefab, hexGrid.GetWorldPositionFromAxialCoord(axialCoord), Quaternion.identity, objectParent);

            onGameObjectSpawned?.Invoke(spawnedGameObject);
            return spawnedGameObject;
        }

        /// <summary>
        /// Instantiate a game object on the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position to instantiate the object</param>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for the instantiated object</param>
        /// <param name="onGameObjectSpawned">Action to execute when the object is instantiated</param>
        /// <returns>The instantiated game object</returns>
        public static GameObject InstantiateGameObjectAtWorldPosition<T>(this HexGrid<T> hexGrid, Vector3 worldPosition, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null)
        {
            AxialCoord axialCoord = hexGrid.GetAxialCoordFromWorldPosition(worldPosition);
            return hexGrid.InstantiateGameObjectAtAxialCoord(axialCoord, gameObjectPrefab, objectParent, onGameObjectSpawned);
        }

        /// <summary>
        /// Instantiate a game object on every grid position
        /// </summary>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for all objects</param>
        /// <param name="onEachGameObjectSpawned">Action to execute when one object is instantiated (params GameObject: the instantiated game object)</param>
        /// <param name="onAllGameObjectSpawned">Action to execute after all objecta are instantiated (params List<GameObject>: all the instantiated game objects)</param>
        /// <returns>A list containing all the instantiated game objects</returns>
        public static List<GameObject> InstantiateGameObjectAtEveryAxialCoord<T>(this HexGrid<T> hexGrid, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onEachGameObjectSpawned = null, Action<List<GameObject>> onAllGameObjectSpawned = null)
        {
            List<GameObject> spawnedGameObjectList = new List<GameObject>();

            hexGrid.IterateOverAllGridPositions((axialCoord, _) =>
            {
                GameObject spawnedGameObject = hexGrid.InstantiateGameObjectAtAxialCoord(axialCoord, gameObjectPrefab, objectParent, onEachGameObjectSpawned);
                spawnedGameObjectList.Add(spawnedGameObject);
            });

            onAllGameObjectSpawned?.Invoke(spawnedGameObjectList);

            return spawnedGameObjectList;
        }
    }
}
