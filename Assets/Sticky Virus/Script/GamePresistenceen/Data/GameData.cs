using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameData : MonoBehaviour
{
    public Text bacteriaCoinTXT;

    public int coinVal { get { return SaveManager.Instance.bacteriaCoin; } set { SaveManager.Instance.bacteriaCoin = value; } }
    
    //Set Data
    public void SetData()
    {
        if (bacteriaCoinTXT != null)
        {
            bacteriaCoinTXT.text = coinVal.ToString();
        }
    }

    //Save Data
    

    public void Start()
    {
        SaveManager.Instance.LoadData();
        SetData();
    }
}
