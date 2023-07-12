using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SanPhamUI : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI name, thongTin, gia;
    public Button button;
    public Button buttonSave;
    private int ID;
    public GameObject saveObj;
    public bool isBaiViet;

    void Start()
    {
        button.onClick.AddListener(ShowInfo);
    }

    private void ShowInfo()
    {
        //UIManager.Instance.ShowSanPham(ID);
        if (isBaiViet)
        {
            UIManager.Instance.ShowSanPham(ID);
        }
        else
        {
            PurchasingManager.Instance.Show(ID);
        }
    }

    public void SetInfo(SanPham product)
    {
        ID = product.ID;
        image.sprite = product.anh;
        //image.SetNativeSize();
        name?.SetText(product.name);
        gia?.SetText(product.gia);
        thongTin?.SetText(product.thongTin);
        saveObj.SetActive(GameDataManager.Instance.playerData.save.Find(i => i.ID == this.ID) != null);
    }
}
