using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperInteract : MonoBehaviour, IInteractable
{

    [SerializeField] GameObject KeyBind;

    private void Start()
    {
        KeyBind.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            KeyBind.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag.Equals("Player"))
        {
            KeyBind.SetActive(false);
        }
    }

    public void Interact()
    {
        ShopPopup.Get().Open();
    }
}
