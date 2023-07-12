using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public SanPhamUI[] sanPham;
    public SanPhamUI[] baiViet;

    public Button priBtn; 
    public Button xemThem1; 
    public Button xemThem2; 

    void Start()
    {
        priBtn.onClick.AddListener(ShowPri);
        xemThem1.onClick.AddListener(XemThem1);
        xemThem2.onClick.AddListener(XemThem2);
        
        for (int i = 0; i < sanPham.Length; i++)
        {
            var products = GameDataManager.Instance.SanPhamSo.SanPham[i];
            sanPham[i].SetInfo(products);
        }
        
        for (int i = 0; i < baiViet.Length; i++)
        {
            var products = GameDataManager.Instance.BaiVietSO.SanPham[i];
            baiViet[i].SetInfo(products);
        }
    }

    private void XemThem1()
    {
        UIManager.Instance.ShowAllSanPham();
    }

    private void XemThem2()
    {
        UIManager.Instance.ShowAllBaiViet();
    }

    private void ShowPri()
    {
        UIManager.Instance.Pri.SetActive(true);
    }
}