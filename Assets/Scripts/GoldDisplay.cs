using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI goldCount;


    private static GoldDisplay _instance;
    private void Start()
    {
        _instance = this;
        DataManager.GetGold();
    }

    public static void SetGold(int gold)
    {
        if (_instance != null)
            _instance.goldCount.text = gold.ToString();
    }
}
