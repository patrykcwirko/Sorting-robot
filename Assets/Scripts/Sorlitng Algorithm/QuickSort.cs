using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="Sorting Algorith/QuickSort")]
public class QuickSort : SortingAlgorith
{
    private int index;

    public override IEnumerator Sort(int[] array)
    {
        GameManager.instance.GetTimer().StartTimer();
        yield return QuickSorting(array, 0, array.Length - 1);
        DisplayArray(array, "QuickSort");
    }

    private IEnumerator QuickSorting(int[] array, int start, int end)
    {
        int[] stack = new int[end - start + 1];
        int top = -1;
        stack[++top] = start;
        stack[++top] = end;

        while (top >= 0)
        {
            end = stack[top--];
            start = stack[top--];

            yield return Partition(array, start, end);

            if (index - 1 > start)
            {
                stack[++top] = start;
                stack[++top] = index - 1;
            }

            if (index + 1 < end)
            {
                stack[++top] = index + 1;
                stack[++top] = end;
            }
        }
        GameManager.instance.GetTimer().EndTimer();
    }

    private IEnumerator Partition(int[] array, int start, int end)
    {
        int p = array[end];
        int i = start - 1;

        for (int j = start; j <= end - 1; j++)
        {
            if (array[j] <= p)
            {
                i++;
                yield return exchange(array, i, j);
            }
        }

        yield return exchange(array, i+1, end);
        index = i + 1;
    }
}
