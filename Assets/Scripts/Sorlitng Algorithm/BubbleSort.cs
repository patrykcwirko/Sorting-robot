using UnityEngine;

[CreateAssetMenu(menuName = "Sorting Algorith/BubbleSort")]
public class BubbleSort : SortingAlgorith
{
    public override void Sort(int[] array)
    {
        BubbleSorting(array);
        DisplayArray(array, "bubbleSort");
    }

    private void BubbleSorting(int[] array)
    {
        int i, j;
        int N = array.Length;

        for (j = N - 1; j > 0; j--)
        {
            for (i = 0; i < j; i++)
            {
                if (array[i] > array[i + 1])
                    exchange(array, i, i + 1);
            }
        }
    }
}
