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
    [SerializeField] GameObject pf_SellItem;

    [SerializeField] Image buyBg;
    [SerializeField] Image sellBg;

    
    [SerializeField] Color selectedColor;
    [SerializeField] Color unselectedColor;


    bool isSell;

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
        if (popup.activeInHierarchy) return;
        popup.SetActive(true);
        bg.SetActive(true);
        SwitchToBuy();
    }

    public void Close()
    {
        popup.SetActive(false);
        bg.SetActive(false);
    }

    public void SwitchToSell()
    {
        isSell = true;
        buyBg.color = unselectedColor;
        sellBg.color = selectedColor;
        sellBg.transform.SetAsLastSibling();

        UpdateData();
    }

    public void SwitchToBuy()
    {
        isSell = false;
        buyBg.color = selectedColor;
        sellBg.color = unselectedColor;
        buyBg.transform.SetAsLastSibling();
        
        UpdateData();
    }

    public void UpdateData()
    {
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        if (!isSell)
        {
            foreach (var item in SkinManager.Get().Skins)
            {
                if (item.price > 0)
                {
                    if (!DataManager.HasItemInInventory(item.name))
                    {
                        var NewItem = Instantiate(pf_ShopItem, content);
                        NewItem.GetComponent<ShopItem>().SetData(item);
                    }
                }
            }
        }
        else
        {
            foreach (var item in SkinManager.Get().Skins)
            {
                if (item.price > 0)
                {
                    if (DataManager.HasItemInInventory(item.name))
                    {
                        var NewItem = Instantiate(pf_SellItem, content);
                        NewItem.GetComponent<SellItem>().SetData(item);
                    }
                }
            }
        }

    }
}
