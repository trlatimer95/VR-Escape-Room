using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class NumberPad : MonoBehaviour
{
    public TextMeshProUGUI textOutput;

    private string currentInput;

    void Start()
    {
        currentInput = string.Empty;
    }

    void Update()
    {
        
    }

    public void AddInput(int numInput)
    {
        currentInput += numInput.ToString();
    }
}
