using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections.Generic;

public class BackgroundItemUI : MonoBehaviour
{
	[SerializeField] Color itemNotSelectedColor;
	[SerializeField] Color itemSelectedColor;

	[Space (20f)]
	[SerializeField] Image backgroundImage;
	[SerializeField] Image bacteriaCoinImage;
	[SerializeField] TMP_Text backgroundPriceText;
	[SerializeField] Button backgroundPurchaseButton;

	[Space (20f)]
	[SerializeField] Button itemButton;
	[SerializeField] Image itemImage;
	[SerializeField] Outline itemOutline;

	//--------------------------------------------------------------
	public void SetItemPosition (Vector2 pos)
	{
		GetComponent <RectTransform> ().anchoredPosition += pos;
	}

	public void SetBackgroundImage (Sprite sprite)
	{
		backgroundImage.sprite = sprite;
	}

	public void SetBacteriaCoin(Sprite sprite)
	{
		bacteriaCoinImage.sprite = sprite;
	}
	public void SetBackgroundPrice (int price)
	{
		backgroundPriceText.text = price.ToString ();
	}

	public void SetCharacterAsPurchased ()
	{
		backgroundPurchaseButton.gameObject.SetActive (false);
		itemButton.interactable = true;

		itemImage.color = itemNotSelectedColor;
	}

	//public List<BackgroundShopDatabase> db = new List<BackgroundShopDatabase>();
	//public void LoadDatabaseBg()
    //{
    //    foreach (var bg in BackgroundShopDatabase.)
    //    {
	//
    //    }
    //}
}
