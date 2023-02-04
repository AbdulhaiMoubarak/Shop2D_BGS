using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteController : MonoBehaviour
{
    [SerializeField] List<FrontBack> FrontAndBackSpriteRenderer;

    public void FaceFront()
    {
        foreach (var item in FrontAndBackSpriteRenderer)
        {
            item.front.SetActive(true);
            item.back.SetActive(false);
        }
    }

    public void FaceBack()
    {
        foreach (var item in FrontAndBackSpriteRenderer)
        {
            item.front.SetActive(false);
            item.back.SetActive(true);
        }
    }
    


}

[System.Serializable]
public class FrontBack
{
    public string name;
    public GameObject front;
    public GameObject back;
}

