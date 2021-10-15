using System.Collections;
using UnityEngine;

public abstract class SortingAlgorith : ScriptableObject
{
    public abstract IEnumerator Sort(int[] array);

    protected IEnumerator exchange(int[] data, int m, int n)
    {
        int tmp;

        yield return GameManager.instance.GetRobot().SwapBall(m, n);
        tmp = data[m];
        data[m] = data[n];
        data[n] = tmp;
    }

    public void DisplayArray(int[] data, string name)
    {
        string massage = name + ": ";

        for (int i = 0; i < data.Length; i++)
        {
            massage += data[i].ToString() + ", ";
        }

        Debug.Log(massage);
    }

}
