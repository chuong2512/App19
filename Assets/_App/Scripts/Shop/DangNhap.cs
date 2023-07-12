using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class DangNhap : MonoBehaviour
{
    public TMP_InputField tdn, mk;
    public TMP_InputField tdnDangKi, mkDangKi;

    public Button dangNhap, dangKi;

    public HorizontalScrollSnap HorizontalScrollSnap;

    void Start()
    {
        dangNhap.onClick.AddListener(Login);
        dangKi.onClick.AddListener(Register);
    }

    private void Register()
    {
        ThongTinDangNhap newInfo = new ThongTinDangNhap(tdnDangKi.text, mkDangKi.text);

        if (GameDataManager.Instance.LuuThongTinDangNhap(newInfo, out string info))
        {
            HorizontalScrollSnap.ChangePage(0);
        }
        
        ToastManager.Instance.ShowToast(info);
    }

    private void Login()
    {
        ThongTinDangNhap newInfo = new ThongTinDangNhap(tdn.text, mk.text);

        if (GameDataManager.Instance.KiemTraDangNhap(newInfo, out string info))
        {
            gameObject.SetActive(false);
        }
        else
        {
            ToastManager.Instance.ShowToast(info);
        }
    }
}

[Serializable]
public class ThongTinDangNhap
{
    public string tenDangNhap;
    public string matKhau;

    public ThongTinDangNhap(string tdn, string mk)
    {
        tenDangNhap = tdn;
        matKhau = mk;
    }
}