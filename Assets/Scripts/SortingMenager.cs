using System.Collections.Generic;
using UnityEngine;

public class SortingMenager : MonoBehaviour
{
    [SerializeField] private SortingAlgorith[] algoriths;
    [SerializeField] private TMPro.TextMeshProUGUI countText;

    private int _sortingStep = 0;

    public void StartAlgorith(int index)
    {
        _sortingStep = 0;
        int[] array = GameManager.instance.GetArrayOfNumber();
        algoriths[0].DisplayArray(array, "UnSort");
        StartCoroutine( algoriths[index].Sort(array));
    }

    public void AddStep()
    {
        _sortingStep++;
        UpdateText();
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    private void UpdateText()
    {
        countText.text = "Step: " + _sortingStep.ToString();
    }
}
