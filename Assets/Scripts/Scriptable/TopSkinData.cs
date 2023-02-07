using UnityEngine;

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