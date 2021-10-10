using UnityEngine;

[CreateAssetMenu(menuName = "Sorting Algorith/BubbleSort")]
public class BubbleSort : SortingAlgorith
{
    public override float Sort(int[] array)
    {
        float startTime = Time.time;
        BubbleSorting(array);
        DisplayArray(array, "bubbleSort");
        return Time.time - startTime;
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
