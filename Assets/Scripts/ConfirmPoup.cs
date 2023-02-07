using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConfirmPoup : MonoBehaviour
{
    [SerializeField] GameObject popup;
    [SerializeField] GameObject bg;
    [SerializeField] Image Icon;
    [SerializeField] TMPro.TextMeshProUGUI PopupText;
    [SerializeField] TMPro.TextMeshProUGUI ItemName;


    private static ConfirmPoup _instance;

    public static ConfirmPoup Get()
    {
        return _instance;
    }

    private void Start()
    {
        _instance = this;
    }
    UnityAction _onConfirm;
    UnityAction _onCancel;


    public void Open(string message, string itemName, Sprite icon, UnityAction onConfirm = null, UnityAction onCancel = null)
    {
        if (popup.activeInHierarchy) return;
        popup.SetActive(true);
        bg.SetActive(true);

        PopupText.text = message;
        ItemName.text = itemName;
        Icon.sprite = icon;

        _onConfirm = onConfirm;
        _onCancel = onCancel;
    }

    public void Cancel()
    {
        _onCancel();
        popup.SetActive(false);
        bg.SetActive(false);
    }
    
    public void Confirm()
    {
        _onConfirm();
        popup.SetActive(false);
        bg.SetActive(false);
    }



}
