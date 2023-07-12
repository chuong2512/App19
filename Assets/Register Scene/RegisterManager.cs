using System;
using TimDoVat;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterManager : Singleton<RegisterManager>
{

    public TextMeshProUGUI textRemain;

    private TimeSpan checkTime;

    void Start()
    {
        checkTime = TimeSpan.FromSeconds(GameDataManager.Instance.playerData.time);

        TimeSpan test =
            DateTime.Now.Subtract(DateTime.FromBinary(Convert.ToInt64(GameDataManager.Instance.playerData.timeRegister)));

        checkTime = checkTime.Subtract(test);

        string answer = string.Format("Tài khoản của bạn còn" +
                                      "\n{0:D2} ngày" +
                                      "\n{1:D2} giờ:{2:D2} phút:{3:D2} giây",
            checkTime.Days,
            checkTime.Hours,
            checkTime.Minutes,
            checkTime.Seconds);

        Debug.Log(answer);

        if (checkTime.TotalSeconds <= 0)
        {
            checkTime = TimeSpan.Zero;
            GameDataManager.Instance.playerData.ResetTime();
        }

        UpdateTimeRemain();
    }

    public void OnPressDown(int i)
    {
        switch (i)
        {
            case 1:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(1);
                IAPManager.Instance.BuyProductID(Key.PACK1_REGISTER);
                break;
            case 2:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(7);
                IAPManager.Instance.BuyProductID(Key.PACK2_REGISTER);
                break;
            case 3:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(30);
                IAPManager.Instance.BuyProductID(Key.PACK3_REGISTER);
                break;
            case 4:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(90);
                IAPManager.Instance.BuyProductID(Key.PACK4_REGISTER);
                break;
            case 5:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(180);
                IAPManager.Instance.BuyProductID(Key.PACK5_REGISTER);
                break;
        }
    }

    private void AddTime(int i)
    {
        checkTime = checkTime.Add(TimeSpan.FromSeconds(i * 24 * 60 * 60));

      GameDataManager.Instance.playerData.SetTimeRegister((long) checkTime.TotalSeconds);
        UpdateTimeRemain();
    }

    private float time = 1;

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (checkTime > TimeSpan.Zero)
            {
                checkTime = checkTime.Subtract(TimeSpan.FromSeconds(1));
            }

            UpdateTimeRemain();
            time = 1;
        }
    }

    public void Test()
    {
        checkTime = TimeSpan.FromSeconds(7);
    }


    public void TestLogTime()
    {
        TimeSpan test =
            DateTime.Now.Subtract(DateTime.FromBinary(Convert.ToInt64(GameDataManager.Instance.playerData.timeRegister)));

        string answer = string.Format("Tài khoản của bạn còn" +
                                      "\n{0:D2} ngày" +
                                      "\n{1:D2} giờ:{2:D2} phút:{3:D2} giây",
            checkTime.Days,
            checkTime.Hours,
            checkTime.Minutes,
            checkTime.Seconds);

        string answer1 = string.Format("Tài khoản của bạn còn" +
                                      "\n{0:D2} ngày" +
                                      "\n{1:D2} giờ:{2:D2} phút:{3:D2} giây",
            checkTime.Days,
            checkTime.Hours,
            checkTime.Minutes,
            checkTime.Seconds);
    }

    private void UpdateTimeRemain()
    {
        if (checkTime.TotalSeconds < 1)
        {
            textRemain.text = "You need to pay to continue";
          GameDataManager.Instance.playerData.ResetTime();
        }
        else
        {
            string answer = string.Format("Tài khoản của bạn còn" +
                                          "\n{0:D2} ngày" +
                                          "\n{1:D2} giờ:{2:D2} phút:{3:D2} giây",
                checkTime.Days,
                checkTime.Hours,
                checkTime.Minutes,
                checkTime.Seconds);

            textRemain.text = answer;
        }
    }
}