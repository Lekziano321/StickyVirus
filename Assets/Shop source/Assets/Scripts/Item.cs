using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Shop Item")]
public class Item : ScriptableObject {
  public string itemName;
  public Sprite sprite;
  public int inStock;
  public int cost;

  [System.Serializable]
  public class ItemObject {
    public string Name;
    public Sprite Sprite;

    public ItemObject(Item item) {
      Name = item.name;
      Sprite = item.sprite;
    }
  }
}

