using System.Collections.Generic;
using UnityEngine;

public class SortingMenager : MonoBehaviour
{
    [SerializeField] private SortingAlgorith[] algoriths;

    private void Start()
    {
        int[] array = GenerateArray(10, 0, 100);
        Debug.Log($"UnSort { array }");

        for (int i = 0; i < algoriths.Length; i++)
        {
            algoriths[i].Sort(array);
        }
    }

    private int[] GenerateArray(int length, int minValue, int maxValue)
    {
        List<int> tmp = new List<int>();

        for (int i = 0; i < length; i++)
        {
            tmp.Add(UnityEngine.Random.Range(minValue, maxValue));
        }

        return tmp.ToArray();
    }
}
