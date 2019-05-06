using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopItemUI : MonoBehaviour {

    public Item curItem;
    public Sprite coinImg;
    public Image icon;
    public TextMeshProUGUI UIname;
    public TextMeshProUGUI UIprice;
    public GameObject ItemImg;
    public GameObject ItemDesc;
    public string Desc;

    [HideInInspector]
    public Shop ShopGO;

    private void Start()
    {
        ItemImg = GameObject.Find("CurrentItemImg");
        ItemDesc = GameObject.Find("itemDesc");
    }

    public void ShopInitiate(Sprite Icon, string name, int price, string desc)
    {
        icon.sprite = Icon;
        UIname.text = name;
        UIprice.text = price.ToString();
        Desc = desc;
    }

    public void Display()
    {
        ItemImg.GetComponentInChildren<Image>().sprite = icon.sprite;
        ItemDesc.GetComponentInChildren<TextMeshProUGUI>().text = Desc;
        ShopGO.currentItem = this;
    }

}
