using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DataManager
{

    static string TOP_SKIN_KEY = "TOPSKIN";
    static string PANTS_SKIN_KEY = "PANTS_SKIN";
    static string SHOES_SKIN_KEY = "SHOES_SKIN";
    static string Inventory_KEY = "INVENTORY";
    static string Gold_KEY = "GOLD";


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
    public static void SetDefaultSkinData(SkinType type)
    {
        switch (type)
        {
            case SkinType.Top:
                PlayerPrefs.SetString(TOP_SKIN_KEY, "CyanTShirt");
                break;
            case SkinType.Pants:
                PlayerPrefs.SetString(PANTS_SKIN_KEY, "BrownPants");
                break;
            case SkinType.Shoes:
                PlayerPrefs.SetString(SHOES_SKIN_KEY, "WhiteShoes");
                break;
        }
    }

    public static string GetSkinData(SkinType type)
    {
        switch (type)
        {
            case SkinType.Top:
                return PlayerPrefs.GetString(TOP_SKIN_KEY, "CyanTShirt");
            case SkinType.Pants:
                return PlayerPrefs.GetString(PANTS_SKIN_KEY, "BrownPants");
            case SkinType.Shoes:
                return PlayerPrefs.GetString(SHOES_SKIN_KEY, "WhiteShoes");
        }
        return null;
    }

    public static string GetInventoryRaw()
    {
        return PlayerPrefs.GetString(Inventory_KEY, "CyanTShirt,BrownPants,WhiteShoes");
    }

    public static List<string> GetInventory()
    {
        string inv = GetInventoryRaw();
        return inv.Split(",").ToList();
    }

    public static void AddItemToInventory(string SkinID)
    {
        string inv = GetInventoryRaw();
        inv += "," + SkinID;
        PlayerPrefs.SetString(Inventory_KEY, inv);
    }

    public static void RemoveItemFromInventory(string name)
    {
        string inv = GetInventoryRaw();
        inv = inv.Replace("," + name, "");
        PlayerPrefs.SetString(Inventory_KEY, inv);
    }

    public static bool HasItemInInventory(string id)
    {
        return GetInventoryRaw().IndexOf(id) >= 0;
    }

    public static int GetGold()
    {
        var g = PlayerPrefs.GetInt(Gold_KEY, 3000);
        GoldDisplay.SetGold(g);
        return g;
    }

    public static void SubtractGold(int amount)
    {
        var g = GetGold();
        g -= amount;

        GoldDisplay.SetGold(g);
        PlayerPrefs.SetInt(Gold_KEY, g);
    }

    public static void AddGold(int amount)
    {
        var g = GetGold();
        g += amount;

        GoldDisplay.SetGold(g);
        PlayerPrefs.SetInt(Gold_KEY, g);
    }

}
