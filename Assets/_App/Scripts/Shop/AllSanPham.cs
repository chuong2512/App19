using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSanPham : ManHinh
{
    public SanPhamUI sanPham;
    public Transform content;
    
    protected override void Start()
    {
        base.Start();
        var products = GameDataManager.Instance.SanPhamSo.SanPham;

        for (int i = 0; i < products.Length; i++)
        {
            var obj = Instantiate(sanPham, content);

            obj.SetInfo(products[i]);
        }
    }
}
