using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Skin Item Data")]
public class SkinData : ScriptableObject
{
    public string PublicName;
    public int price;
    public Sprite icon;
    public virtual SkinType GetSkinType()
    {
        return SkinType.Top;
    }
}

[CreateAssetMenu(menuName = "Top Skin Data")]
public class TopSkinData : SkinData
{
    public SpriteAllSides UpperTorso;
    public Sprite UpperArm;
    public Sprite Arm;
    
    public override SkinType GetSkinType()
    {
        return SkinType.Top;
    }
}

[CreateAssetMenu(menuName = "Pants Skin Data")]
public class PantsSkinData : SkinData
{
    public SpriteAllSides Torso;
    public Sprite UpperLeg;
    public Sprite Leg;
    public override SkinType GetSkinType()
    {
        return SkinType.Pants;
    }
}

[CreateAssetMenu(menuName = "Shoes Skin Data")]
public class ShoesSkinData : SkinData
{
    public SpriteAllSides Shoe;
    public override SkinType GetSkinType()
    {
        return SkinType.Shoes;
    }
}



public enum SkinType
{
    Top,
    Pants,
    Shoes
}