using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Source
{
    public static class IEnumerableHealper
    {
        public static int GetRandomIndexFromIEnumerable<T>(IEnumerable<T> Enumerable)
        {
            return Random.Range(0 , Enumerable.Count());
        }
        public static T GetRandomObjFromList<T>(List<T> List)
        {
            return List[GetRandomIndexFromIEnumerable(List)];
        }
    }
}