using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuy : MonoBehaviour
{
    public static int buyID = -1;
    
    public int number;
    public TextMeshProUGUI TextMeshProUgui;
    public Button button;

    void OnValidate()
    {
        TextMeshProUgui = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponentInChildren<Button>();
    }

    void Start()
    {
        button.onClick.AddListener(Choose);

        SetTextDay();
    }

    private void SetTextDay()
    {
    }

    private void Choose()
    {
        PurchasingManager.Instance.OnPressDown(number);
    }
}