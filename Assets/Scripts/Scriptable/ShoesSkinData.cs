
using UnityEngine;


[CreateAssetMenu(menuName = "Shoes Skin Data")]
public class ShoesSkinData : SkinData
{
    public SpriteAllSides Shoe;
    public override SkinType GetSkinType()
    {
        return SkinType.Shoes;
    }
}
