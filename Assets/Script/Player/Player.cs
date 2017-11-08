using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float speed = 33.0f;
    private float jumpSpeed = 1f;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        isGrounded();

        //Selection du joueur
        string select = "";
        if(gameObject.tag == "Player1")
        {
            select = "P1";
        }
        else
        {
            select = "P2";
        }
        //On récupère la vitesse actuel
        Vector3 actualVelocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

        //On récupère la direction (normalisé) des joystick dans l'axe x et y
        float horizontalMoove = Input.GetAxis("Horizontal" + select);
        float verticalMoove = Input.GetAxis("Vertical" + select);

        //■■■■■■■■■■Moove■■■■■■■■■■■
        //On ajoute à la vitesse actuel sa propre vitesse plus celle du joystick * speed * temps entre deux frames
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(actualVelocity.x + Input.GetAxis("Horizontal" + select) * speed * Time.deltaTime, actualVelocity.y, 0);

        //Mise à jour de la vitesse actuel
        actualVelocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

        //■■■■■■■■■■SAUT■■■■■■■■■■■■
        if (Input.GetButton("Fire1" + select))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(actualVelocity.x, actualVelocity.y + jumpSpeed, 0);
        }
    }

    private bool isGrounded()
    {
        Vector3 target = Vector3.down;

        Debug.DrawRay(gameObject.GetComponent<Transform>().position + Vector3.down, target, Color.red);
        bool result = false;     
        if (Physics.Linecast(transform.position + Vector3.down, target))
        {
            //Debug.Log("IS grounded !!!");
        }
        else
        {
            Debug.Log("NOT GROUNDED !!!!");
        }
        return result;
    }
}
