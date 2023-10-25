using UnityEngine;

[CreateAssetMenu (fileName = "BackgroundShopDatabase", menuName = "Shopping/Background shop database")]
public class BackgroundShopDatabase : ScriptableObject
{
	public Background[] background;

	public int BackgroundCount {
		get{ return background.Length; }
	}

	public Background GetCharacter (int index)
	{
		return background[index];
	}

	public void PurchaseBackground (int index)
	{
		background[index].isPurchased = true;
	}
}
