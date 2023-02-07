using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager
{

    static string TOP_SKIN_KEY = "TOPSKIN";
    static string PANTS_SKIN_KEY = "PANTS_SKIN";
    static string SHOES_SKIN_KEY = "SHOES_SKIN";


    public static void SetSkinData(int skinID, SkinType type)
    {
        switch (type)
        {
            case SkinType.Top:
                PlayerPrefs.SetInt(TOP_SKIN_KEY, skinID);
                break;
            case SkinType.Pants:
                PlayerPrefs.SetInt(PANTS_SKIN_KEY, skinID);
                break;
            case SkinType.Shoes:
                PlayerPrefs.SetInt(SHOES_SKIN_KEY, skinID);
                break;
        }
    }

    public static int GetSkinData(SkinType type)
    {
        switch (type)
        {
            case SkinType.Top:
                return PlayerPrefs.GetInt(TOP_SKIN_KEY);
            case SkinType.Pants:
                return PlayerPrefs.GetInt(PANTS_SKIN_KEY);
            case SkinType.Shoes:
                return PlayerPrefs.GetInt(SHOES_SKIN_KEY);
        }
        return -1;
    }

    public void CheckInvetory()
    {

    }



}
