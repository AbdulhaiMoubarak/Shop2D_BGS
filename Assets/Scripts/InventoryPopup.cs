using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : MonoBehaviour
{
    [SerializeField] GameObject popup;
    [SerializeField] GameObject bg;
    [SerializeField] Transform content;
    [SerializeField] GameObject pf_InvetoryItem;

    private static InventoryPopup _instance;

    public static InventoryPopup Get()
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

        foreach (var item in GetInventory())
        {
            var NewItem = Instantiate(pf_InvetoryItem, content);
            NewItem.GetComponent<InventoryItem>().SetData(item);
        }
    }

    public List<SkinData> GetInventory()
    {
        List<SkinData> skins = new List<SkinData>();
        Debug.Log(DataManager.GetInventory().Count);
        foreach (var item in DataManager.GetInventory())
        {
            skins.Add(SkinManager.Get().GetSkinbyID(item));
        }
        Debug.Log(skins.Count);
        return skins;

    }
}
