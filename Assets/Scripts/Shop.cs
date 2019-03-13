using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject ShopUI;
    public GameObject ShopItemsUI;
    public Item[] shopItems;
    public GameObject ShopItemPrefab;

    private void Start()
    {
        foreach (Item item in shopItems)
        {
            print(item.name);
            GameObject CurrentItem = Instantiate(ShopItemPrefab, parent:ShopItemsUI.transform);
            CurrentItem.GetComponent<ShopItemUI>().ShopDisplay(item.icon, item.name, item.price);
        }
    }
}
