using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Shop : MonoBehaviour {
   [Header("List of items sold")]
   [SerializeField]
   public Item[] shopItem;

   [Header("References")]
   [SerializeField]
   private Transform shopContent;
   [Header("Prefabs")]
   [SerializeField]
   private GameObject shopItemPrefab;
   [Header("Game money")]
   [SerializeField]
   public int coins;
   [SerializeField]
   public Text Coins;
   [SerializeField]
   private Player _player;
   private void Start() {
      UpdateCoins();
      SpawnItem();
   }
   
   void UpdateCoins() {
      Coins.text = coins.ToString("n0");
   }
   
   public void SpawnItem() {
      for (int i = 0; i < shopItem.Length; i++) {
         Item si = shopItem[i];
         
         GameObject itemObject = Instantiate(shopItemPrefab, shopContent);

         itemObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => OnButtonClick(si, itemObject));

         itemObject.transform.GetChild(0).GetComponent<Text>().text = si.itemName;
         itemObject.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = si.sprite;
         itemObject.transform.GetChild(4).GetComponent<Text>().text = si.inStock.ToString();
         itemObject.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = si.cost.ToString("n0");
      }
   }

   private void OnButtonClick(Item item, GameObject index) {
      if (coins >= item.cost && item.inStock > 0) {
         coins -= item.cost;
         item.inStock--;
         index.transform.GetChild(4).GetComponent<Text>().text = item.inStock.ToString();
         _player.OnButtonClick(item);
         UpdateCoins();
      }
   }
}
 