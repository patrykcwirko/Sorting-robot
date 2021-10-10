using System.Collections.Generic;
using UnityEngine;

public class SortingMenager : MonoBehaviour
{
    [SerializeField] private SortingAlgorith[] algoriths;

    public void StartAlgorith(int index)
    {
        int[] array = GenerateArray(10, 0, 100);
        algoriths[0].DisplayArray(array, "UnSort");
        algoriths[index].Sort(array);
    }

    public void ExitApp()
    {
        Application.Quit();
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
