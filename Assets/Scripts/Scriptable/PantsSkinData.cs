using UnityEngine;

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