using UnityEngine;

[CreateAssetMenu(menuName = "Sorting Algorith/SelectionSort")]
public class SelectionSort : SortingAlgorith
{
    public override void Sort(int[] array)
    {
        SelectionSorting(array);
        DisplayArray(array, "SelectionSort");
    }

    private void SelectionSorting(int[] array)
    {
        int i;
        int N = array.Length;

        for (i = 0; i < N - 1; i++)
        {
            int k = MinValue(array, i);
            if (i != k)
                exchange(array, i, k);
        }
    }

    private int MinValue(int[] data, int start)
    {
        int minPos = start;
        for (int pos = start + 1; pos < data.Length; pos++)
            if (data[pos] < data[minPos])
                minPos = pos;
        return minPos;
    }
}
