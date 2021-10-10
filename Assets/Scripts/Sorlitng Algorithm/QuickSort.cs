using UnityEngine;

[CreateAssetMenu(menuName ="Sorting Algorith/QuickSort")]
public class QuickSort : SortingAlgorith
{
    public override float Sort(int[] array)
    {
        float startTime = Time.time;
        QuickSorting(array, 0, array.Length - 1);
        DisplayArray(array, "QuickSort");
        return Time.time - startTime;
    }

    private void QuickSorting(int[] array, int start, int end)
    {
        int i;
        if (start < end)
        {
            i = Partition(array, start, end);

            QuickSorting(array, start, i - 1);
            QuickSorting(array, i + 1, end);
        }
    }

    private int Partition(int[] array, int start, int end)
    {
        int temp;
        int p = array[end];
        int i = start - 1;

        for (int j = start; j <= end - 1; j++)
        {
            if (array[j] <= p)
            {
                i++;
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        temp = array[i + 1];
        array[i + 1] = array[end];
        array[end] = temp;
        return i + 1;
    }
}
