using System;

namespace Extensions
{
    /// <summary>
    /// Extend methods for array types
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Returns whether an index is within the bounds of an array
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="array">The array to check</param>
        /// <param name="index">The index to check</param>
        /// <returns>Wheter the index is inside of the array or not</returns>
        public static bool HasIndex<T>(this T[] array, int index) => index.InRange(0, array.Length - 1);

        /// <summary>
        /// Return the first element of an array
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="array">The array to get the first element</param>
        /// <returns>The first element of the array</returns>
        public static T First<T>(this T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length <= 0)
                throw new ArgumentException("Array should contain at least one element");

            return array[0];
        }

        /// <summary>
        /// Return the last element of an array
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="array">The array to get the last element</param>
        /// <returns>The last element of the array</returns>
        public static T Last<T>(this T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length <= 0)
                throw new ArgumentException("Array should contain at least one element");

            return array[^1];
        }

        /// <summary>
        /// Return the minimum element of an array
        /// </summary>
        /// <param name="array">The array to get the minimum element from</param>
        /// <returns>The minimum element of the array</returns>
        public static float Minimum(this float[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length <= 0)
                throw new ArgumentException("Array should contain at least one element");

            float curMinimum = float.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < curMinimum)
                    curMinimum = array[i];
            }

            return curMinimum;
        }

        /// <summary>
        /// Return the maximum element of an array
        /// </summary>
        /// <param name="array">The array to get the maximum element from</param>
        /// <returns>The maximum element of the array</returns>
        public static float Maximum(this float[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length <= 0)
                throw new ArgumentException("Array should contain at least one element");

            float curMaximum = float.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > curMaximum)
                    curMaximum = array[i];
            }

            return curMaximum;
        }

        /// <summary>
        /// Swap the value in the "firstIndex" with the one in the "secondIndex"
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="array">The array to swap the values</param>
        /// <param name="firstIndex">The first index</param>
        /// <param name="secondIndex">The second index</param>
        public static void Swap<T>(this T[] array, int firstIndex, int secondIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length < 2)
                throw new ArgumentException("Array should contain at least two elements");

            if (!array.HasIndex(firstIndex))
                throw new ArgumentException("The array does not contain firstIndex");

            if (!array.HasIndex(secondIndex))
                throw new ArgumentException("The array does not contain secondIndex");

            T firstValue = array[firstIndex];

            array[firstIndex] = array[secondIndex];
            array[secondIndex] = firstValue;
        }

        /// <summary>
        /// Shuffle an array by using Fisher-Yates
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="array">The array to be shuffled</param>
        public static void Shuffle<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = UnityEngine.Random.Range(i, array.Length);
                Swap(array, randomIndex, i);
            }
        }

        /// <summary>
        /// Normalize an array of float between the values of 0 and 1
        /// </summary>
        /// <param name="array">The array to be normalized</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        public static void NormalizeArray(this float[] array, float min, float max)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
            {
                float value = array[i];
                array[i] = value.Normalize(min, max);
            }
        }

        /// <summary>
        /// Normalize an array of float between the values of 0 and 1
        /// </summary>
        /// <param name="array">The array to be normalized</param>
        public static void NormalizeArray(this float[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            float min = array.Minimum();
            float max = array.Maximum();

            for (int i = 0; i < array.Length; i++)
            {
                float value = array[i];
                array[i] = value.Normalize(min, max);
            }
        }

        /// <summary>
        /// Map an array to a new range
        /// </summary>
        /// <param name="array">The array to be mapped</param>
        /// <param name="min">The current minimum range</param>
        /// <param name="max">The current maximum range</param>
        /// <param name="targetMin">The new target minimum range</param>
        /// <param name="targetMax">The new target maximum range</param>
        public static void MapArray(this float[] array, float min, float max, float targetMin, float targetMax)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
            {
                float value = array[i];
                array[i] = value.Map(min, max, targetMin, targetMax);
            }
        }

        /// <summary>
        /// Change all values of the array to its complement (1 - value)
        /// </summary>
        /// <param name="array">The array to calculate the complement</param>
        public static void ComplementArray(this float[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
            {
                float value = array[i];
                array[i] = value.Complement();
            }
        }

        /// <summary>
        /// Inverse the signal of all elements in the array
        /// </summary>
        /// <param name="array">The array to calculate the inverted signal</param>
        public static void InverseArray(this float[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
            {
                float value = array[i];
                array[i] = value.Inverse();
            }
        }
    }
}
