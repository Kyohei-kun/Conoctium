using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuSol : MonoBehaviour {

    private bool auSol;
    // Use this for initialization
    void Start()
    {
        auSol = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Sol")
        {
            auSol = true;
        }      
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Sol")
        {
            auSol = false;
        }
    }

    public bool GetAuSol()
    {
        return auSol;
    }

}
