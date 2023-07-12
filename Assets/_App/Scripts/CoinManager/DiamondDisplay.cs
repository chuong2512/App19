using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondDisplay : MonoBehaviour
{
   public TextMeshProUGUI diamondTmp;

   void OnValidated()
   {
      diamondTmp = GetComponent<TextMeshProUGUI>();
   }

   void Start()
   {
   }
   
   void OnDestroy()
   {
   }

   private void OnChangeDiamond(int i)
   {
      diamondTmp.text = $"{i}";
   }
}
