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
        ItemName.text = _skin.name;
        ItemPrice.text = _skin.price.ToString();
        ItemIcon.sprite = _skin.icon;
    }
    public void OnClick()
    {
        Debug.Log(_skin.name);
        DataManager.SetSkinData(_skin.name, _skin.GetSkinType());
        CharSpirteManager.Get().UpdateSkin();
    }
}
