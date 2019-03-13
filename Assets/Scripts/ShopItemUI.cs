using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopItemUI : MonoBehaviour {
    
    public Sprite coinImg;
    public Image icon;
    public TextMeshProUGUI UIname;
    public TextMeshProUGUI UIprice;

    private void Start()
    {
        
    }

    public void ShopDisplay(Sprite Icon, string name, int price)
    {
        icon.sprite = Icon;
        UIname.text = name;
        UIprice.text = price.ToString();
    }

}
