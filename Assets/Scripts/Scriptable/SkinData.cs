using UnityEngine;
public abstract class SkinData : ScriptableObject
{
    public string PublicName;
    public int price;
    public Sprite icon;
    public virtual SkinType GetSkinType()
    {
        return SkinType.Top;
    }

}

public enum SkinType
{
    Top,
    Pants,
    Shoes
}