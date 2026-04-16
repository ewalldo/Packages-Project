using System;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public static class Grid2DExtensions
    {
        /// <summary>
        /// Instantiate a game object in a certain grid position
        /// </summary>
        /// <param name="gridPosition2D">The grid position to instantiate the object on (will be instantiatd at its center)</param>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for the instantiated object</param>
        /// <param name="onGameObjectSpawned">Action to execute when the object is instantiated (params GameObject: the instantiated game object)</param>
        /// <returns>The instantiated game object</returns>
        public static GameObject InstantiateGameObjectAtGridPosition<T>(this Grid2D<T> grid, GridPosition2D gridPosition2D, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null)
        {
            GameObject spawnedGameObject = GameObject.Instantiate(gameObjectPrefab, grid.GetWorldPositionFromCenterGridPosition2D(gridPosition2D), Quaternion.identity, objectParent);

            onGameObjectSpawned?.Invoke(spawnedGameObject);
            return spawnedGameObject;
        }

        /// <summary>
        /// Instantiate a game object in the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position to instantiate the object</param>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for the instantiated object</param>
        /// <param name="onGameObjectSpawned">Action to execute when the object is instantiated (params GameObject: the instantiated game object)</param>
        /// <returns>The instantiated game object</returns>
        public static GameObject InstantiateGameObjectAtWorldPosition<T>(this Grid2D<T> grid, Vector3 worldPosition, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null)
        {
            GridPosition2D gridPosition2D = grid.GetGridPosition2DFromWorldPosition(worldPosition);

            return grid.InstantiateGameObjectAtGridPosition(gridPosition2D, gameObjectPrefab, objectParent, onGameObjectSpawned);
        }

        /// <summary>
        /// Instantiate a game object on every grid position
        /// </summary>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for all objects</param>
        /// <param name="onEachGameObjectSpawned">Action to execute when one object is instantiated (params GameObject: the instantiated game object)</param>
        /// <param name="onAllGameObjectSpawned">Action to execute after all objecta are instantiated (params List<GameObject>: all the instantiated game objects)</param>
        /// <returns>A list containing all the instantiated game objects</returns>
        public static List<GameObject> InstantiateGameObjectsAtEveryGridPosition<T>(this Grid2D<T> grid, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onEachGameObjectSpawned = null, Action<List<GameObject>> onAllGameObjectSpawned = null)
        {
            List<GameObject> spawnedGameObjectList = new List<GameObject>();

            for (int x = 0; x < grid.Width; x++)
            {
                for (int z = 0; z < grid.Height; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);
                    GameObject spawnedGameObject = grid.InstantiateGameObjectAtGridPosition(gridPosition2D, gameObjectPrefab, objectParent, onEachGameObjectSpawned);

                    spawnedGameObjectList.Add(spawnedGameObject);
                }
            }

            onAllGameObjectSpawned?.Invoke(spawnedGameObjectList);

            return spawnedGameObjectList;
        }
    }
}
