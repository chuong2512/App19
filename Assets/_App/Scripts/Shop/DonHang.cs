using System;
using UnityEngine;

[Serializable]
public class DonHang : SanPham
{
    public int donHangID;
}

[Serializable]
public class SanPham
{
    public int ID;
    public Sprite anh;
    public Sprite anhHai;
    public string thongTin;
    public string gia;
    public string name;
}


