using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public Text currencyText;
    public void Start()
    {
        currencyText.text = $"{SaveManager.Instance.bacteriaCoin}";
    }
}
