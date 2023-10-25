using System;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.Events;

public class Player : MonoBehaviour {
  public InventoryObject inventory;

  public void OnButtonClick(Item item) {
    var _item = item;
    if (_item) {
      inventory.AddItem(new Item.ItemObject(item),1);
    }
  }

  private void OnApplicationQuit() {
    inventory.Container.Items.Clear();
  }
}