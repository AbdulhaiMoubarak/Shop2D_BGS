using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpirteManager : MonoBehaviour
{


    [SerializeField] CharacterSprites character;
    [SerializeField] List<CharacterSkinTop> SkinsTop;
    [SerializeField] List<CharacterSkinPants> SkinsPants;
    [SerializeField] List<CharacterSkinShoe> SkinsShoes;


    public void SetSkin()
    {
        SetTopSkin(Random.Range(0, SkinsTop.Count));
        SetPantsSkin(Random.Range(0, SkinsPants.Count));
        SetShoesSkin(Random.Range(0, SkinsShoes.Count));
    }
    void SetTopSkin(int index)
    {
        if (SkinsTop[index].UpperTorso.front != null)
            character.UpperTorso.front.sprite = SkinsTop[index].UpperTorso.front;

        if (SkinsTop[index].UpperTorso.back != null)
            character.UpperTorso.back.sprite = SkinsTop[index].UpperTorso.back;
        else
            character.UpperTorso.back.sprite = SkinsTop[index].UpperTorso.front;

        if (SkinsTop[index].UpperTorso.side != null)
            character.UpperTorso.side.sprite = SkinsTop[index].UpperTorso.side;

        if (SkinsTop[index].UpperArm != null)
            foreach (var item in character.UpperArm)
            {
                item.sprite = SkinsTop[index].UpperArm;
            }

        if (SkinsTop[index].Arm != null)
            foreach (var item in character.Arm)
            {
                item.sprite = SkinsTop[index].Arm;
            }



    }
    void SetPantsSkin(int index)
    {
        if (SkinsPants[index].Torso.front != null)
            character.Torso.front.sprite = SkinsPants[index].Torso.front;
        if (SkinsPants[index].Torso.back != null)
            character.Torso.back.sprite = SkinsPants[index].Torso.back;
        if (SkinsPants[index].Torso.side != null)
            character.Torso.side.sprite = SkinsPants[index].Torso.side;

        if (SkinsPants[index].UpperLeg != null)
            foreach (var item in character.UpperLeg)
            {
                item.sprite = SkinsPants[index].UpperLeg;
            }

        if (SkinsPants[index].Leg != null)
            foreach (var item in character.Leg)
            {
                item.sprite = SkinsPants[index].Leg;
            }

    }
    void SetShoesSkin(int index)
    {
        //public SpriteAllSides Shoe;

        if (SkinsShoes[index].Shoe.front != null)
        {
            character.LShoe.front.sprite = SkinsShoes[index].Shoe.front;
            character.RShoe.front.sprite = SkinsShoes[index].Shoe.front;

        }
        if (SkinsShoes[index].Shoe.back != null)
        {
            character.LShoe.back.sprite = SkinsShoes[index].Shoe.back;
            character.RShoe.back.sprite = SkinsShoes[index].Shoe.back;

        }
        if (SkinsShoes[index].Shoe.side != null)
        {
            character.LShoe.side.sprite = SkinsShoes[index].Shoe.side;
            character.RShoe.side.sprite = SkinsShoes[index].Shoe.side;
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
public class CharacterSkinTop
{
    public bool avalibleInShop = true;
    public string name;
    public int price;
    public Sprite icon;
    public SpriteAllSides UpperTorso;
    public Sprite UpperArm;
    public Sprite Arm;
}

[System.Serializable]
public class CharacterSkinPants
{
    public bool avalibleInShop = true;
    public string name;
    public int price;
    public Sprite icon;
    public SpriteAllSides Torso;
    public Sprite UpperLeg;
    public Sprite Leg;
}

[System.Serializable]
public class CharacterSkinShoe
{
    public bool avalibleInShop = true;
    public string name;
    public int price;
    public Sprite icon;
    public SpriteAllSides Shoe;
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