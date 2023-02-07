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


    [SerializeField] Button Confirm;
    [SerializeField] Button Cancel;

    private static ConfirmPoup _instance;

    public static ConfirmPoup Get()
    {
        return _instance;

    }

    private void Start()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

    }

    public void Open(string message, string itemName, Sprite icon, UnityAction onConfirm, UnityAction onCancel)
    {
        if (popup.activeInHierarchy) return;
        popup.SetActive(true);
        bg.SetActive(true);

        PopupText.text = message;
        ItemName.text = itemName;
        Icon.sprite = icon;

        Confirm.onClick.RemoveAllListeners();
        Confirm.onClick.AddListener(delegate
        {
            popup.SetActive(false);
            bg.SetActive(false);
            onConfirm();
        });

        Cancel.onClick.RemoveAllListeners();
        Cancel.onClick.AddListener(delegate
        {
            bg.SetActive(false);
            popup.SetActive(false);
            onCancel();
        });
    }
}
