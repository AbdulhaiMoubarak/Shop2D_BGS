using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI ItemName;
    [SerializeField] Image ItemIcon;
    [SerializeField] GameObject isEquipped;

    SkinData _skin;
    public void SetData(SkinData skin)
    {
        _skin = skin;
        ItemName.text = _skin.PublicName;
        ItemIcon.sprite = _skin.icon;

        isEquipped.SetActive(DataManager.GetSkinData(skin.GetSkinType()) == _skin.name);
    }

    public void OnClick()
    {
        Debug.Log(_skin.name);
        DataManager.SetSkinData(_skin.name, _skin.GetSkinType());
        CharSpirteManager.Get().UpdateSkin();

        InventoryPopup.Get().UpdateData();
    }
}
