using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")] 
public class InventoryObject : ScriptableObject {
  public Inventory Container;
  
  public void AddItem(Item.ItemObject _item, int _count) {
    
    for (int i = 0; i < Container.Items.Count; i++) { 
      if (Container.Items[i].item.Name == _item.Name) {
        Container.Items[i].AddAmount(_count);
        return;
      }
    }
    Container.Items.Add(new InventorySlot( _item, _count));
  }

  [System.Serializable]
  public class Inventory {
    public List<InventorySlot> Items = new List<InventorySlot>();
  }

  [System.Serializable]
  public class InventorySlot {
    public Item.ItemObject item;
    public int amount;

    public InventorySlot(Item.ItemObject _item, int _amount) {
      item = _item;
      amount = _amount;
    }

    public void AddAmount(int value) {
      amount += value;
    }
  }
}