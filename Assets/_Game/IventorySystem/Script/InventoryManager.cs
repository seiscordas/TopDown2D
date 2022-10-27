using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public List<Item> Items { get; }

    [SerializeField] private List<Item> items = new();

    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject inventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItem()
    {
        CleanListItem();
        foreach (Item item in items)
        {
            print("item: "+ item.ItemName);
            GameObject obj = Instantiate(inventoryItem, itemContent);
            obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.ItemName;
            obj.transform.Find("ItemIcon").GetComponent<Image>().sprite = item.Icon;
        }
    }

    public Item GetItemById(string id)
    {
        Item item = CheckItemById(id);
        if (!item)
            return null;

        Remove(item);
        return item;
    }

    public Item CheckItemById(string id)
    {
        if (items.Count == 0)
            return null;
        Item item = items.Find(x => x.Id == id);
        if (item != null)
            return item;

        return null;
    }

    private void CleanListItem()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }
}
