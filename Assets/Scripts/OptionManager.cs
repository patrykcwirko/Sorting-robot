using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.InputField input;

    private void Awake()
    {
        input.text = GameManager.instance.algorithData.ToString();
    }

    public void Save()
    {
        GameManager.instance.algorithData.ballAmount = Int32.Parse( input.text);
        GameManager.instance.PreperScene();
        GameManager.instance.Reset();
    }
}
