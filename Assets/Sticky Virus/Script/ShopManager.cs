using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private static ShopManager instance;

    public static ShopManager Instance
    {
        get
        {
            // If the instance is null, try to find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<ShopManager>();

                // If it's still null, create a new instance
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(ShopManager).Name);
                    instance = singletonObject.AddComponent<ShopManager>();
                }
            }

            return instance;
        }
    }
    //=============================================================================//
    //SOLUSI 1
    [SerializeField]
    public List<string> itemShopList = new List<string>();
    [SerializeField]
    public List<int> itemShopPrice = new List<int>();

    //SOLUSI 2
    public Dictionary<string, int> itemShopList2 = new Dictionary<string, int>();

    //=============================================================================//

    //DATAMANAGER===================================================================//
    public Dictionary<string, string> dataItem = new Dictionary<string, string>();

    public void LoadBackground()
    {
        string key = "";//SaveManager.equippedBackground;
        string equippedBackgroundPath = "/Resources/aa/safa";// Cari FilePath gambarnya. dari variable dataItem

        SpriteRenderer comp = GetComponent<SpriteRenderer>();
        byte[] fileData = System.IO.File.ReadAllBytes(equippedBackgroundPath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);

        // Create a Sprite from the Texture2D
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        comp.sprite = sp;
    }
    //



    public void TryBuyItem(string key)
    {
        //cari key di SaveManager.Instance.purchasedItem apakah ada. (sudah terbeli atau tidak)
        // jika belum kebeli, lanjut, jika sudah, return.

        // cari key apakah ada di itemShopList
        // jika ketemu, catat index nya.
        // cari harga dengan index yang sama.



        // Jika berhasil kebeli:
        // SaveManager.Instance.purchasedItem.Add("");
    }

    public void TryUseItem(string key)
    {
        //SaveManager.Instance.equippedBackgroundKey = key;
    } 
}
