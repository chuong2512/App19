using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SanphamSO", order = 1)]
public class SanPhamSO : ScriptableObject
{
    public string name = "";
    public string infor = "";
    public string folderPath = "Assets/App19";

    [InlineProperty] public SanPham[] SanPham;

    [Button]
    public void SetID()
    {
        for (int i = 0; i < SanPham.Length; i++)
        {
            SanPham[i].ID = i;
            SanPham[i].name = String.Empty;
        }
    }

#if UNITY_EDITOR
    private Sprite LoadSpritesFromFolder(string folderPath, int id)
    {
        var spriteGUIDs =
            UnityEditor.AssetDatabase.FindAssets("t:sprite",
                new[] {folderPath}); // Tìm tất cả GUID của sprite trong thư mục
        var sprites = new Sprite[spriteGUIDs.Length];

        for (int i = 0; i < spriteGUIDs.Length; i++)
        {
            string spritePath =
                UnityEditor.AssetDatabase.GUIDToAssetPath(spriteGUIDs[i]); // Chuyển đổi GUID sang đường dẫn
            sprites[i] = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(spritePath); // Tải sprite từ đường dẫn
        }

        if (id < sprites.Length) return sprites[id];
        return null;
    }

    [Button]
    public void addNew()
    {
        SanPham newSP = new SanPham();
        newSP.ID = SanPham.Length;

        newSP.name = (name == "" && SanPham.Length > 0) ? SanPham[^1].name : name;

        if (Random.Range(0, 2) == 0)
        {
            newSP.gia = Random.Range(20, 100) * 10 + ".000 đ";
        }
        else
        {
            newSP.gia = Random.Range(1, 21) + ".000.000 đ";
        }

        newSP.thongTin = infor;

        newSP.anh = LoadSpritesFromFolder(folderPath, newSP.ID);
        Array.Resize(ref SanPham, SanPham.Length + 1);
        SanPham[SanPham.Length - 1] = newSP;
    }

    [Button]
    public void AddAll()
    {
        var spriteGUIDs =
            UnityEditor.AssetDatabase.FindAssets("t:sprite",
                new[] {folderPath});

        for (int i = 0; i < spriteGUIDs.Length; i++)
        {
            addNew();
        }
    }

#endif


    public SanPham GetSanPhamWithID(int id)
    {
        return SanPham[id];
    }
}