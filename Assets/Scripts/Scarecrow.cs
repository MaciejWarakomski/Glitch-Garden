using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if(attacker)
        {
            myAnimator.SetBool("isDamaged", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myAnimator.SetBool("isDamaged", false);
    }
}
