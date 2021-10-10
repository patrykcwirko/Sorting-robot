using System.Collections.Generic;
using UnityEngine;

public class SortingMenager : MonoBehaviour
{
    [SerializeField] private SortingAlgorith[] algoriths;

    public void StartAlgorith(int index)
    {
        int[] array = GameManager.instance.GetArrayOfNumber();
        algoriths[0].DisplayArray(array, "UnSort");
        float time = algoriths[index].Sort(array);
        Debug.Log(time);
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
