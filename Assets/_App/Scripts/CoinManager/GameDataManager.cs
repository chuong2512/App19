using System;
using Sirenix.OdinInspector;
using TimDoVat;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameDataManager : PersistentSingleton<GameDataManager>
{
    /*----Scriptable data-----------------------------------------------------------------------------------------------*/

    /*----Data variable-------------------------------------------------------------------------------------------------*/
    [HideInInspector] public PlayerData playerData;

    [InlineEditor()] public SanPhamSO SanPhamSo;
    [InlineEditor()] public SanPhamSO BaiVietSO;

    private void Start()
    {
        Application.targetFrameRate = Mathf.Max(60, Screen.currentResolution.refreshRate);
    }

    private void OnEnable()
    {
        playerData = new GameObject(Constant.DataKey_PlayerData).AddComponent<PlayerData>();
        playerData.transform.parent = transform;
        playerData.Init();
    }

    public void ResetData()
    {
        playerData.ResetData();
    }

    public bool LuuThongTinDangNhap(ThongTinDangNhap thongTin, out string info)
    {
        info = String.Empty;

        if (thongTin.tenDangNhap == String.Empty)
        {
            info = "Vui lòng nhập tên đăng nhập !!!";
            return false;
        }

        if (thongTin.matKhau == String.Empty)
        {
            info = "Vui lòng nhập mật khẩu !!!";
            return false;
        }


        if (playerData.accounts.Count == 0)
        {
            info = "Tạo tài khoản thành công !!!";
            playerData.ThemTaiKhoan(thongTin);
            return true;
        }

        if (playerData.CheckTrungTaiKhoan(thongTin))
        {
            info = "Tên đăng nhập đã tồn tại !!!";
            return false;
        }

        info = "Tạo tài khoản thành công !!!";
        playerData.ThemTaiKhoan(thongTin);
        return true;
    }

    public bool KiemTraDangNhap(ThongTinDangNhap thongTin, out string info)
    {
        info = String.Empty;
        return true;

        if (thongTin.tenDangNhap == String.Empty)
        {
            info = "Vui lòng nhập tên đăng nhập !!!";
            return false;
        }

        if (thongTin.matKhau == String.Empty)
        {
            info = "Vui lòng nhập mật khẩu !!!";
            return false;
        }

        var result = playerData.accounts.Find(info => info.tenDangNhap == thongTin.tenDangNhap);

        if (result != null)
        {
            if (result.matKhau != thongTin.matKhau)
            {
                info = "Sai mật khẩu !!!";
                return false;
            }

            return true;
        }

        info = "Tài khoản không tồn tại trên hệ thống";
        return false;
    }

    public void TaoDonHang(int buyId)
    {
        var sanPham = SanPhamSo.GetSanPhamWithID(buyId);
        playerData.TaoDon(sanPham);
    }

    public bool TickSave(int id)
    {
        var sanPham = SanPhamSo.GetSanPhamWithID(id);
        
        if (playerData.save.Contains(sanPham))
        {
            playerData.RemoveSanPham(sanPham);
            return false;
        }
        else
        {
            playerData.SaveSanPham(sanPham);
            return true;
        }
    }
}