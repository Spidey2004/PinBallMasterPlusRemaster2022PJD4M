using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public PlayerController player;
    private void Update()
    {
        text.text = "" + player.coins;
    }
}
