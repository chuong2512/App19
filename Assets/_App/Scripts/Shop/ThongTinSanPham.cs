using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThongTinSanPham : ManHinh
{
    public Image image;
    public TextMeshProUGUI name, thongTin, gia;
    public Button button;
    public Button buttonSave;
    private int ID;
    
    protected override void Start()
    {
        base.Start();
        button.onClick.AddListener(ShowInfoShop);
        buttonSave.onClick.AddListener(Save);
    }

    protected override void Back()
    {
        base.Back();
    }

    private void Save()
    {
        GameDataManager.Instance.TickSave(ID);
    }

    public void ShowInfoShop()
    {
        PurchasingManager.Instance.Show(ID);
    }

    public void SetInfo(SanPham product)
    {
        ID = product.ID;
        image.sprite = product.anh;
        name?.SetText(product.name);
        gia?.SetText(product.gia);
        thongTin?.SetText(product.thongTin);
    }

    public void ShowInfo(int id)
    {
        var sanPham = GameDataManager.Instance.SanPhamSo.GetSanPhamWithID(id);

        SetInfo(sanPham);
    }
}