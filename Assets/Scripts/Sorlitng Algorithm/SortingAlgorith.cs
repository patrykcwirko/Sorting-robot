using UnityEngine;

public abstract class SortingAlgorith : ScriptableObject
{
    public abstract void Sort(int[] array);

    protected static void exchange(int[] data, int m, int n)
    {
        int tmp;

        tmp = data[m];
        data[m] = data[n];
        data[n] = tmp;
    }

}
