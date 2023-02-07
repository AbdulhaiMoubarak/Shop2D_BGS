using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellItem : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI ItemName;
    [SerializeField] TMPro.TextMeshProUGUI ItemPrice;
    [SerializeField] Image ItemIcon;

    SkinData _skin;
    public void SetData(SkinData skin)
    {
        _skin = skin;
        ItemName.text = _skin.PublicName;
        ItemPrice.text = (_skin.price * .5).ToString();
        ItemIcon.sprite = _skin.icon;
    }
    public void OnClick()
    {
        DataManager.AddGold((int)(_skin.price * .5));
        DataManager.RemoveItemFromInventory(_skin.name);

        Debug.Log(_skin.name);
        DataManager.SetDefaultSkinData(_skin.GetSkinType());
        CharSpirteManager.Get().UpdateSkin();

        ShopPopup.Get().UpdateData();
    }
}
