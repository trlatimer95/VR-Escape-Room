using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class NumberPad : MonoBehaviour
{
    public TextMeshProUGUI textOutput;
    public GameObject keycardPrefab;
    public Transform keycardSpawnPos;

    private string currentInput;
    private string secretCode;

    void Start()
    {
        currentInput = string.Empty;
    }

    public void AddInput(int numInput)
    {
        currentInput += numInput.ToString();
        UpdateOutputText();
        CheckCodeIsCorrect();
    }

    public void ResetInput()
    {
        currentInput = string.Empty;
        UpdateOutputText();
    }

    private void UpdateOutputText()
    {
        textOutput.text = currentInput;
    }

    private void CheckCodeIsCorrect()
    {
        if (currentInput == secretCode)
            Instantiate(keycardPrefab, keycardSpawnPos.position, keycardPrefab.transform.rotation);
        else if (currentInput.Length == secretCode.Length)
            ResetInput();
    }
}
