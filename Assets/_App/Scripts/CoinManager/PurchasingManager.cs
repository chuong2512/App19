using TimDoVat;
using UnityEngine;
using UnityEngine.UI;

public class PurchasingManager : Singleton<PurchasingManager>
{
    public Button huyBtn, datCocBtn;
    public GameObject shipCod, datCoc, go;

    void Start()
    {
        huyBtn.onClick.AddListener(Huy);
        datCocBtn.onClick.AddListener(DatCoc);
    }

    private void Huy()
    {
        go.SetActive(false);
    }
    
    private void DatCoc()
    {
        shipCod.SetActive(false);
        datCoc.SetActive(true);
    }

    public void OnPressDown(int i)
    {
        IAPManager.OnPurchaseSuccess = () =>
        {
            Debug.Log($"Mua san pham id : {ButtonBuy.buyID}");
            GameDataManager.Instance.TaoDonHang(ButtonBuy.buyID);
            go.SetActive(false);
        };

        switch (i)
        {
            case 1:
                IAPManager.Instance.BuyProductID(Key.PACK1);
                break;
            case 2:
                IAPManager.Instance.BuyProductID(Key.PACK2);
                break;
            case 3:
                IAPManager.Instance.BuyProductID(Key.PACK3);
                break;
            case 4:
                IAPManager.Instance.BuyProductID(Key.PACK4);
                break;
        }
    }

    public void Show(int id)
    {
        ButtonBuy.buyID = id;
        go.SetActive(true);
        shipCod.SetActive(true);
        datCoc.SetActive(false);
    }



    public void Sub(int i)
    {
    }
}