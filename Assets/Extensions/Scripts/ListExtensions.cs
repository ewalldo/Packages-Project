using System;
using System.Collections.Generic;

namespace Extensions
{
    /// <summary>
    /// Extend methods for list types
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns whether an index is within the bounds of a list
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list to check</param>
        /// <param name="index">The index to check</param>
        /// <returns>Wheter the index is inside of the list or not</returns>
        public static bool HasIndex<T>(this IList<T> list, int index) => index.InRange(0, list.Count - 1);

        /// <summary>
        /// Return the first element of a list
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list to get the first element</param>
        /// <returns>The first element of the list</returns>
        public static T First<T>(this IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Count <= 0)
                throw new ArgumentException("List should contain at least one element");

            return list[0];
        }

        /// <summary>
        /// Return the last element of a list
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list to get the last element</param>
        /// <returns>The last element of the list</returns>
        public static T Last<T>(this IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Count <= 0)
                throw new ArgumentException("List should contain at least one element");

            return list[^1];
        }

        /// <summary>
        /// Return the minimum element of a list
        /// </summary>
        /// <param name="list">The list to get the minimum element from</param>
        /// <returns>The minimum element of the list</returns>
        public static float Minimum(this IList<float> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Count <= 0)
                throw new ArgumentException("List should contain at least one element");

            float curMinimum = float.MaxValue;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < curMinimum)
                    curMinimum = list[i];
            }

            return curMinimum;
        }

        /// <summary>
        /// Return the maximum element of a list
        /// </summary>
        /// <param name="list">The list to get the maximum element from</param>
        /// <returns>The maximum element of the list</returns>
        public static float Maximum(this IList<float> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Count <= 0)
                throw new ArgumentException("List should contain at least one element");

            float curMaximum = float.MinValue;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > curMaximum)
                    curMaximum = list[i];
            }

            return curMaximum;
        }

        /// <summary>
        /// Swap the value in the "firstIndex" with the one in the "secondIndex"
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list to swap the values</param>
        /// <param name="firstIndex">The first index</param>
        /// <param name="secondIndex">The second index</param>
        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Count < 2)
                throw new ArgumentException("List should contain at least two elements");

            if (!list.HasIndex(firstIndex))
                throw new ArgumentException("The list does not contain firstIndex");

            if (!list.HasIndex(secondIndex))
                throw new ArgumentException("The list does not contain secondIndex");

            T firstValue = list[firstIndex];

            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstValue;
        }

        /// <summary>
        /// Move all items of a list "amount" spaces to the left
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list to be rotated</param>
        /// <param name="amount">The number of spaces to rotate to the left</param>
        public static void RotateLeft<T>(this IList<T> list, int amount = 1)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Count < 2)
                return;

            for (int current = 0; current < amount; current++)
            {
                T first = list[0];
                list.RemoveAt(0);
                list.Add(first);
            }
        }

        /// <summary>
        /// Move all items of a list "amount" spaces to the right
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list to be rotated</param>
        /// <param name="amount">The number of spaces to rotate to the right</param>
        public static void RotateRight<T>(this IList<T> list, int amount = 1)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Count < 2)
                return;

            int lastIndex = list.Count - 1;
            for (int current = 0; current < amount; current++)
            {
                T last = list[lastIndex];
                list.RemoveAt(lastIndex);
                list.Insert(0, last);
            }
        }

        /// <summary>
        /// Remove all null entries in a list
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list which will have the null entries removed from</param>
        public static void RemoveNullValues<T>(this IList<T> list) where T: class
        {
            for (int i = list.Count - 1; i >= 0; i--)
                if (Equals(list[i], null))
                    list.RemoveAt(i);
        }

        /// <summary>
        /// Shuffle a list by using Fisher-Yates
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list to be shuffled</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = UnityEngine.Random.Range(i, list.Count);
                Swap(list, randomIndex, i);
            }
        }

        /// <summary>
        /// Normalize a list of float between the values of 0 and 1
        /// </summary>
        /// <param name="list">The list to be normalized</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        public static void NormalizeList(this IList<float> list, float min, float max)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            for (int i = 0; i < list.Count; i++)
            {
                float value = list[i];
                list[i] = value.Normalize(min, max);
            }
        }

        /// <summary>
        /// Normalize a list of float between the values of 0 and 1
        /// </summary>
        /// <param name="list">The list to be normalized</param>
        public static void NormalizeList(this IList<float> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            float min = list.Minimum();
            float max = list.Maximum();

            for (int i = 0; i < list.Count; i++)
            {
                float value = list[i];
                list[i] = value.Normalize(min, max);
            }
        }

        /// <summary>
        /// Map a list to a new range
        /// </summary>
        /// <param name="list">The list to be mapped</param>
        /// <param name="min">The current minimum range</param>
        /// <param name="max">The current maximum range</param>
        /// <param name="targetMin">The new target minimum range</param>
        /// <param name="targetMax">The new target maximum range</param>
        public static void MapList(this IList<float> list, float min, float max, float targetMin, float targetMax)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            for (int i = 0; i < list.Count; i++)
            {
                float value = list[i];
                list[i] = value.Map(min, max, targetMin, targetMax);
            }
        }

        /// <summary>
        /// Change all values of the list to its complement (1 - value)
        /// </summary>
        /// <param name="list">The list to calculate the complement</param>
        public static void ComplementList(this IList<float> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            for (int i = 0; i < list.Count; i++)
            {
                float value = list[i];
                list[i] = value.Complement();
            }
        }

        /// <summary>
        /// Inverse the signal of all elements in the list
        /// </summary>
        /// <param name="list">The list to calculate the inverted signal</param>
        public static void InverseList(this IList<float> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            for (int i = 0; i < list.Count; i++)
            {
                float value = list[i];
                list[i] = value.Inverse();
            }
        }
    }
}
