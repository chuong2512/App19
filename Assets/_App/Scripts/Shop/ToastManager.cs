using System.Collections;
using System.Collections.Generic;
using TimDoVat;
using TMPro;
using UnityEngine;

public class ToastManager : Singleton<ToastManager>
{
    public GameObject GameObject;
    public TextMeshProUGUI text;

    public void ShowToast(string info)
    {
        StopAllCoroutines();
        
        GameObject.SetActive(true);
        text.SetText(info);
        StartCoroutine(Hide());

        IEnumerator Hide()
        {
            yield return new WaitForSeconds(2f);
            GameObject.SetActive(false);
        }
    }
}