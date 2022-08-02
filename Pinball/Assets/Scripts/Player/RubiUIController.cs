using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RubiUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text cristalText;
    private void OnEnable()
    {
        PlayerObserverManager.OnCristalChanged += UpdateCoinText;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCristalChanged -= UpdateCoinText;
    }

    private void UpdateCoinText(int newCristalValue)
    {
        cristalText.text = newCristalValue.ToString();
    }
}
