using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI ItemName;
    [SerializeField] TMPro.TextMeshProUGUI ItemPrice;
    [SerializeField] Image ItemIcon;

    SkinData _skin;
    public void SetData(SkinData skin)
    {
        _skin = skin;
        ItemName.text = _skin.PublicName;
        ItemPrice.text = _skin.price.ToString();
        ItemIcon.sprite = _skin.icon;
    }
    public void OnClick()
    {
        if (DataManager.GetGold() >= _skin.price)
        {
            ConfirmPoup.Get().Open("Buy this item?", _skin.PublicName, _skin.icon, delegate
            {

                DataManager.SubtractGold(_skin.price);
                DataManager.AddItemToInventory(_skin.name);

                Debug.Log(_skin.name);
                DataManager.SetSkinData(_skin.name, _skin.GetSkinType());

                CharSpirteManager.Get().UpdateSkin();
                ShopPopup.Get().UpdateData();
            }, delegate
            {
                ShopPopup.Get().UpdateData();
            });
        }
    }
}
