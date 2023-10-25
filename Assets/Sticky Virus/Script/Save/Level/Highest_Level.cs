using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highest_Level : MonoBehaviour
{
    public Text highestLeveltxt;
    //private GameManager gmng;

    

    public void Start()
    {
        highestLeveltxt.text = $"{SaveManager.Instance.highestSceneIndex}";
    }
}
