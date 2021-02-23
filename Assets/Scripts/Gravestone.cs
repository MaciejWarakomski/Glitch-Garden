using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && !otherCollider.GetComponent<Fox>() && !otherCollider.GetComponent<Butterfly>())
        {
            myAnimator.SetBool("isDamaged", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myAnimator.SetBool("isDamaged", false);
    }
}
