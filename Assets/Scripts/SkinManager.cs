using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public List<SkinData> Skins;

    private static SkinManager _instance;

    public static SkinManager Get()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    public SkinData GetSkinbyID(string skinID)
    {
        return Skins.Where(obj => obj.name == skinID).SingleOrDefault();
    }
}