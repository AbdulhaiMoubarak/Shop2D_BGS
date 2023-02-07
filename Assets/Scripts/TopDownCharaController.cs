using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharaController : MonoBehaviour
{
    public float scaleSize = 0.1f;
    public float speed;

    private Animator animator;

    [SerializeField] LayerMask _interactableMask;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.Play("WalkBackward");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.Play("WalkForward");
        }
        else
        {

            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                transform.localScale = new Vector3(-scaleSize, scaleSize, scaleSize);
                animator.Play("WalkSide");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
                dir.x = 1;
                animator.Play("WalkSide");
                //animator.SetInteger("Direction", 2);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            transform.localScale = new Vector3(-scaleSize, scaleSize, scaleSize);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
            dir.x = 1;
        }


        if (Input.GetKey(KeyCode.E))
        {
            Collider2D[] collider2Ds = new Collider2D[3];
            int _numFound = Physics2D.OverlapCircleNonAlloc(transform.position, .5f, collider2Ds, _interactableMask);
            if (_numFound > 0)
            {
                collider2Ds[0].GetComponent<IInteractable>().Interact();
            }
        }

        if (Input.GetKey(KeyCode.I))
        {
            InventoryPopup.Get().Open();
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}
