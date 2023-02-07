using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPopup : MonoBehaviour
{
    [SerializeField] GameObject popup;
    [SerializeField] GameObject bg;
    [SerializeField] Transform content;
    [SerializeField] GameObject pf_ShopItem;



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

        foreach (var item in CharSpirteManager.Get().Skins)
        {
            if (item.price > 0)
            {
                var NewItem = Instantiate(pf_ShopItem, content);
                NewItem.GetComponent<ShopItem>().SetData(item);
            }
        }
    }
}
