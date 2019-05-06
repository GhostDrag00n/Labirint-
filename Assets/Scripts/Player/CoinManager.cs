using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour {

    public TextMeshProUGUI UIcoins;
    public int startingMoney;
    private int money;

    private void Start()
    {
        money = startingMoney;
    }

    public int GetMoney()
    {
        return money;
    }

    public void Add(int amount)
    {
        money += amount;
        UIcoins.text = money.ToString();
    }

    public int Substract(int amount)
    {
        if (money - amount >= 0)
        {
            money -= amount;
            UIcoins.text = money.ToString();
            return money;
        }
        else
        {
            return 0;
        }
    }
}
