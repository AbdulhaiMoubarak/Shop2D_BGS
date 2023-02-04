using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideOutsideEffect : MonoBehaviour
{

    [SerializeField] bool Inside;
    [SerializeField] GameObject OutsideParent;
    [SerializeField] Camera MainCamera;
    [SerializeField] Color GrassColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (Inside)
            {
                MainCamera.backgroundColor = Color.black;
                OutsideParent.SetActive(false);
            }
            else
            {
                MainCamera.backgroundColor = GrassColor;
                OutsideParent.SetActive(true);
            }
        }
    }



}
