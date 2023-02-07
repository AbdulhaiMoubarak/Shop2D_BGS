using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager
{

    static string TOP_SKIN_KEY = "TOPSKIN";
    static string PANTS_SKIN_KEY = "PANTS_SKIN";
    static string SHOES_SKIN_KEY = "SHOES_SKIN";


    public static void SetSkinData(string skinID, SkinType type)
    {
        switch (type)
        {
            case SkinType.Top:
                PlayerPrefs.SetString(TOP_SKIN_KEY, skinID);
                break;
            case SkinType.Pants:
                PlayerPrefs.SetString(PANTS_SKIN_KEY, skinID);
                break;
            case SkinType.Shoes:
                PlayerPrefs.SetString(SHOES_SKIN_KEY, skinID);
                break;
        }
    }

    public static string GetSkinData(SkinType type)
    {
        switch (type)
        {
            case SkinType.Top:
                return PlayerPrefs.GetString(TOP_SKIN_KEY,"CyanTShirt");
            case SkinType.Pants:
                return PlayerPrefs.GetString(PANTS_SKIN_KEY,"BrownPants");
            case SkinType.Shoes:
                return PlayerPrefs.GetString(SHOES_SKIN_KEY,"WhiteShoes");
        }
        return null;
    }
}
