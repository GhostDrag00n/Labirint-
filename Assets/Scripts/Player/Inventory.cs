using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public int slots = 200;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More that one inventory");
        }
        else
        {
            instance = this;
            items = new List<Item>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            string str = ".";
            foreach (Item item in items)
            {
                str += item.name.ToString() + " ";
            }
            Debug.Log(str + " " + items.Count);
        }
    }

    public bool Add(Item item)
    {
        if (item != null)
        {
            if (items.Count >= slots)
            {
                return false;
            }
			Debug.Log(item.name);
			items.Add(item);
            if (onItemChangedCallback != null)
            {
				onItemChangedCallback.Invoke();
            }
        }
		return true;

    }

    public bool Exist(Item item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        return false;
    }

    public void Delete(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
