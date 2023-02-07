using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI ItemName;
    [SerializeField] TMPro.TextMeshProUGUI ItemPrice;
    [SerializeField] Image ItemIcon;

    CharacterSkin _skin;
    public void SetData(CharacterSkin skin)
    {
        _skin = skin;
        ItemName.text = _skin.name;
        ItemPrice.text = _skin.price.ToString();
        ItemIcon.sprite = _skin.icon;
    }
    public void OnClick()
    {
        DataManager.SetSkinData(_skin.SkinID, _skin.GetSkinType());
        CharSpirteManager.Get().UpdateSkin();
    }
}
