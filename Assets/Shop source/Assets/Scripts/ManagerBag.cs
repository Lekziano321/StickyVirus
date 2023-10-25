using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerBag : MonoBehaviour {
    public GameObject reviveShopPanel;
    public GameObject reviveBagPanel;
    public GameObject reviveMenuPanel;
    [SerializeField]
    private Transform ContentBag;
    [SerializeField]
    private GameObject bagItemPrefab;
    public InventoryObject bag;
    GameObject[] gameObjects;
    public List<InventoryObject.InventorySlot> itemsDisplayed = new List<InventoryObject.InventorySlot>();
    public void GoToGameMenu()
    {
        SceneManager.LoadScene("Home");
    }
    public void RevivePanel(int i) {
        if (i == 0) {
            reviveShopPanel.SetActive(false);
            reviveBagPanel.SetActive(true);
            reviveMenuPanel.SetActive(false);
            UpdateBag();
        } else if (i == 1) {
            DestroyBag();
            reviveMenuPanel.SetActive(false);
            reviveBagPanel.SetActive(false);
            reviveShopPanel.SetActive(true);
        }
        else if (i == 2) {
            DestroyBag();
            reviveMenuPanel.SetActive(true);
            reviveBagPanel.SetActive(false);
            reviveShopPanel.SetActive(false);
        }
    }

    private void DestroyBag() {
        gameObjects = GameObject.FindGameObjectsWithTag("1");
        for (int i = 0; i < gameObjects.Length; ++i) {
            Destroy(gameObjects[i]);
        }
    }

    public void UpdateBag() {
        for (int i = 0; i < bag.Container.Items.Count; i++) {
            itemsDisplayed[i] = bag.Container.Items[i];
            var itemObject = Instantiate(bagItemPrefab, ContentBag);
            itemObject.transform.GetChild(2).GetComponent<Text>().text = itemsDisplayed[i].item.Name;
            itemObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = itemsDisplayed[i].item.Sprite;
            itemObject.transform.GetChild(1).GetComponent<Text>().text = itemsDisplayed[i].amount.ToString("n0");
        }
    }
}
