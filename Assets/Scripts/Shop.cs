using UnityEngine;
using UnityEngine.UI;

public class Shop : Interactable {

    public GameObject ShopUI;
    public GameObject ShopItemsUI;
    public GameObject ShopBuyButton;
    public Item[] shopItems;
    public GameObject closeButton;
    public GameObject ShopItemPrefab;

    public ShopItemUI currentItem = null;

    public override void Activate()
    {
        ShopUI.SetActive(true);
        ActivateButton.gameObject.SetActive(false);
    }

    public override void DeActivate()
    {
        Debug.Log("Exiting");
    }

    private void Start()
    {
        closeButton.GetComponent<Button>().onClick.AddListener(CloseShop);
        ShopBuyButton.GetComponent<Button>().onClick.AddListener(BuyButton);

        // Initializing shop items
        foreach (Item item in shopItems)
        {
            Debug.Log(item.name);
            GameObject CurrentItem = Instantiate(ShopItemPrefab, parent:ShopItemsUI.transform);
            CurrentItem.GetComponent<ShopItemUI>().ShopInitiate(item.icon, item.name, item.price, item.Desctiption);
            CurrentItem.GetComponent<ShopItemUI>().ShopGO = this;
            CurrentItem.GetComponent<ShopItemUI>().curItem = item;
        }
    }

    public void CloseShop()
    {
        ShopUI.SetActive(false);
        ActivateButton.gameObject.SetActive(true);
    }

    public void BuyButton()
    {
        GameObject player = PlayerController.instance.gameObject;
        CoinManager cm = player.GetComponent<CoinManager>();

        if (currentItem != null)
        {
            if (cm.GetMoney() >= currentItem.curItem.price)
            {
                cm.Substract(currentItem.curItem.price);
                player.GetComponent<Inventory>().Add(currentItem.curItem);
                Destroy(currentItem.gameObject);
            }
        }
    }
}
