using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Sorting Algorith/BubbleSort")]
public class BubbleSort : SortingAlgorith
{
    public override IEnumerator Sort(int[] array)
    {
        GameManager.instance.GetTimer().StartTimer();
        yield return BubbleSorting(array);
        DisplayArray(array, "bubbleSort");
    }

    private IEnumerator BubbleSorting(int[] array)
    {
        int i, j;
        int N = array.Length;

        for (j = N - 1; j > 0; j--)
        {
            for (i = 0; i < j; i++)
            {
                if (array[i] > array[i + 1])
                    yield return exchange(array, i, i + 1);
            }
        }
        GameManager.instance.GetTimer().EndTimer();
    }
}
