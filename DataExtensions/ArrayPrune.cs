using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Scripts.DataExtensions
{
    public static class ArrayPrune
    {
        public static Vector3[] PruneArray(Vector3[] arrayInput, int targetCount)
        {
            Vector3[] array = arrayInput.Select(x => new Vector3(x.x, x.y, 0)).Where(x => x.magnitude < 10f).ToArray();
            List<Vector3> result = new List<Vector3>();
            if (targetCount > array.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    result.Add(array[i]);
                }

                int j = 1;
                for (int i = 0; i < targetCount - array.Length; i++)
                {
                    result.Add((array[j] + array[j - 1]) * 0.5f);
                    j++;
                    if (j == array.Length)
                    {
                        j = 0;
                    }
                }
            }
            else
            {
                int step = array.Length / targetCount;
                for (int i = 0; i < array.Length; i += step)
                {
                    result.Add(array[i]);
                }

                int notEnought = targetCount - result.Count;
                for (int i = 0; i < notEnought; i++)
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }
    }
}