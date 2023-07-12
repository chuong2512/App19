using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class ButtonGroup : MonoBehaviour
{
    public ButtonPage[] btns;
    public HorizontalScrollSnap HorizontalScrollSnap;

    void OnValidate()
    {
        btns = GetComponentsInChildren<ButtonPage>();
    }

    void Start()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            var i1 = i;
            btns[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                ChooseButton(i1);
                Choose(i1);
            });
        }
    }

    public void ChooseButton(int i)
    {
        for (int j = 0; j < btns.Length; j++)
        {
            if (i == j)
            {
                btns[j].Select();
            }
            else
            {
                btns[j].UnSelect();
            }
        }

        if (i == 2)
        {
            QuanLyDonHang.Instance.Refresh();
        }
    }

    void Choose(int i)
    {
        HorizontalScrollSnap.ChangePage(i);
    }
}