using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharSpirteManager : MonoBehaviour
{

    [SerializeField] CharacterSprites character;

    private static CharSpirteManager _instance;

    public static CharSpirteManager Get()
    {
        return _instance;
    }

    private void Start()
    {
        _instance = this;
        UpdateSkin();
    }


    public void UpdateSkin()
    {
        SetSkin(DataManager.GetSkinData(SkinType.Top));
        SetSkin(DataManager.GetSkinData(SkinType.Pants));
        SetSkin(DataManager.GetSkinData(SkinType.Shoes));
    }



    void SetSkin(string SkinID)
    {
        SkinData skin = SkinManager.Get().GetSkinbyID(SkinID);

        if (skin == null) return;

        switch (skin.GetSkinType())
        {
            case SkinType.Top:
                SetTopSkin((TopSkinData)skin);
                break;
            case SkinType.Pants:
                SetPantsSkin((PantsSkinData)skin);
                break;
            case SkinType.Shoes:
                SetShoesSkin((ShoesSkinData)skin);
                break;
        }
    }


    void SetTopSkin(TopSkinData skin)
    {
        if (skin == null) return;


        if (skin.UpperTorso.front != null)
            character.UpperTorso.front.sprite = skin.UpperTorso.front;

        if (skin.UpperTorso.back != null)
            character.UpperTorso.back.sprite = skin.UpperTorso.back;
        else
            character.UpperTorso.back.sprite = skin.UpperTorso.front;

        if (skin.UpperTorso.side != null)
            character.UpperTorso.side.sprite = skin.UpperTorso.side;

        if (skin.UpperArm != null)
            foreach (var item in character.UpperArm)
            {
                item.sprite = skin.UpperArm;
            }

        if (skin.Arm != null)
            foreach (var item in character.Arm)
            {
                item.sprite = skin.Arm;
            }



    }
    void SetPantsSkin(PantsSkinData skin)
    {
        if (skin == null) return;


        if (skin.Torso.front != null)
            character.Torso.front.sprite = skin.Torso.front;
        if (skin.Torso.back != null)
            character.Torso.back.sprite = skin.Torso.back;
        if (skin.Torso.side != null)
            character.Torso.side.sprite = skin.Torso.side;

        if (skin.UpperLeg != null)
            foreach (var item in character.UpperLeg)
            {
                item.sprite = skin.UpperLeg;
            }

        if (skin.Leg != null)
            foreach (var item in character.Leg)
            {
                item.sprite = skin.Leg;
            }

    }
    void SetShoesSkin(ShoesSkinData skin)
    {
        if (skin == null) return;

        if (skin.Shoe.front != null)
        {
            character.LShoe.front.sprite = skin.Shoe.front;
            character.RShoe.front.sprite = skin.Shoe.front;

        }
        if (skin.Shoe.back != null)
        {
            character.LShoe.back.sprite = skin.Shoe.back;
            character.RShoe.back.sprite = skin.Shoe.back;

        }
        if (skin.Shoe.side != null)
        {
            character.LShoe.side.sprite = skin.Shoe.side;
            character.RShoe.side.sprite = skin.Shoe.side;
        }
    }


}


[System.Serializable]
public class CharacterSprites
{
    //Head
    //Neck
    public SpriteRenderAllSides UpperTorso;
    public SpriteRenderAllSides Torso;
    public List<SpriteRenderer> UpperArm;
    public List<SpriteRenderer> Arm;
    //public SpriteRenderGroup Hand;
    public List<SpriteRenderer> UpperLeg;
    public List<SpriteRenderer> Leg;
    public SpriteRenderAllSides LShoe;
    public SpriteRenderAllSides RShoe;
}

[System.Serializable]
public class SpriteRenderAllSides
{
    public SpriteRenderer front;
    public SpriteRenderer back;
    public SpriteRenderer side;
}

[System.Serializable]
public class SpriteAllSides
{
    public Sprite front;
    public Sprite back;
    public Sprite side;
}