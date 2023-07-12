using System.Collections;
using System.Collections.Generic;
using TimDoVat;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public ThongTinBaiViet ThongTinBaiViet;
    public ThongTinSanPham ThongTinSanPham;
    public AllBaiViet AllBaiViet;
    public AllSanPham AllSanPham;
    public ManHinh Pri;


    void OnValidate()
    {
    }

    public void ShowSanPham(int id)
    {
        ThongTinSanPham.SetActive(true);
        ThongTinSanPham.ShowInfo(id);
    }

    public void ShowTTSanPham()
    {
        ThongTinSanPham.SetActive(true);
    }

    public void ShowAllSanPham()
    {
        AllSanPham.SetActive(true);
    }

    public void ShowTTBaiViet(int id)
    {
        ThongTinBaiViet.SetActive(true);
        ThongTinBaiViet.ShowInfo(id);
    }

    public void ShowAllBaiViet()
    {
        AllBaiViet.SetActive(true);
    }
}