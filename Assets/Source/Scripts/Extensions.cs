using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public static class Extensions
    {
        public static T ToDeserialized<T>(this string json) => JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) => JsonUtility.ToJson(obj);

        public static List<T> Copy<T>(this IReadOnlyList<T> list)
        {
            List<T> copy = new List<T>();

            foreach (T copied in list)
                copy.Add(copied);

            return copy;
        }
    }
}
