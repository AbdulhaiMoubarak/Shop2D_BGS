using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopup : MonoBehaviour
{

    [SerializeField] GameObject popup;
    [SerializeField] GameObject bg;
    [SerializeField] Transform content;
    [SerializeField] GameObject pf_ShopItem;

    private CharSpirteManager charSpirteManager;

    
    private static ShopPopup _instance;

    public static ShopPopup Get()
    {
        return _instance;
    }

    private void Start()
    {
        _instance = this;
    }

    public void Open()
    {
        charSpirteManager = CharSpirteManager.Get();
        popup.SetActive(true);
        bg.SetActive(true);
        UpdateData();
    }

    public void Close()
    {
        popup.SetActive(false);
        bg.SetActive(false);
    }


    public void UpdateData()
    {
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        foreach (var item in charSpirteManager.SkinsTop)
        {
            if (item.avalibleInShop)
            {
                var NewItem = Instantiate(pf_ShopItem, content);
                NewItem.GetComponent<ShopItem>().SetData(item);
            }
        }

        foreach (var item in charSpirteManager.SkinsPants)
        {
            if (item.avalibleInShop)
            {
                var NewItem = Instantiate(pf_ShopItem, content);
                NewItem.GetComponent<ShopItem>().SetData(item);
            }
        }

        foreach (var item in charSpirteManager.SkinsShoes)
        {
            if (item.avalibleInShop)
            {
                var NewItem = Instantiate(pf_ShopItem, content);
                NewItem.GetComponent<ShopItem>().SetData(item);
            }
        }


    }
}
