using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManHinh : MonoBehaviour
{
    public string title;
    public TextMeshProUGUI tieuDe;
    public Button buttonBack;

    protected virtual void Start()
    {
        tieuDe.SetText(title);
        buttonBack.onClick.AddListener(Back);
    }

    public void SetActive(bool b)
    {
        gameObject.SetActive(b);
    }

    protected virtual void Back()
    {
        SetActive(false);
    }
}