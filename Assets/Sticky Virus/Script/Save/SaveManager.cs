using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    // coin
    public int bacteriaCoin = 0;
    // score
    private const string HighestSceneKey = "HighestSceneIndex";

    public int highestSceneIndex;

    private int currentLevel;


    public static SaveManager Instance
    {
        get
        {
            // If the instance is null, try to find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<SaveManager>();

                // If it's still null, create a new instance
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveManager).Name);
                    instance = singletonObject.AddComponent<SaveManager>();
                }
            }
            return instance;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    [RuntimeInitializeOnLoadMethod]
    private static void InitLevel()
    {
        GameObject obj = new GameObject("level");
        instance = obj.AddComponent<SaveManager>();
        DontDestroyOnLoad(obj);
    }

    private void Awake()
    {
        highestSceneIndex = PlayerPrefs.GetInt(HighestSceneKey, highestSceneIndex);
        //PlayerPrefs.SetInt(HighestSceneKey, currentLevel);

        Debug.Log("Highest Scene Index: " + highestSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if the current scene index is higher than the stored highest scene index
        if (currentSceneIndex > highestSceneIndex)
        {
            // Update the highest scene index to the current scene index
            highestSceneIndex = currentSceneIndex;

            // Save the new highest scene index to PlayerPrefs
            PlayerPrefs.SetInt(HighestSceneKey, highestSceneIndex);
            PlayerPrefs.Save();
        }
        //PlayerPrefs.SetInt(HighestSceneKey, currentLevel);
    }

    [RuntimeInitializeOnLoadMethod]
    private static void InitCoin()
    {
        GameObject obj = new GameObject("duit");
        instance = obj.AddComponent<SaveManager>();
        DontDestroyOnLoad(obj);
    }

    public void IncreaseBacteriaCoin(int coin)
    {
        bacteriaCoin += coin;
    }

    public void DecreaseBacteriaCoin(int coin)
    {
        bacteriaCoin -= coin;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coin", bacteriaCoin);
    }

    public void LoadData()
    {
        bacteriaCoin = PlayerPrefs.GetInt("coin", 0);
    }

}
