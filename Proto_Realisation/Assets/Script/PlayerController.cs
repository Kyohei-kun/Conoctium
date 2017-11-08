using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float vitesseP1;
    private float vitesseP2;

    public float vitesseMaxP1;
    public float vitesseMaxP2;

    private bool player1CanJump;
    private bool player2CanJump;

    public float puissanceDeSaut;

    private GameObject player1;
    private GameObject player2;

    
    

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        player1CanJump = false;
        player2CanJump = false;
    }

    // Update is called once per frame
    void Update ()
    {
        //■■■■■■■■■■■■■■■■■■■ JUMP ■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if(player1CanJump)
            {
                player1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, puissanceDeSaut));
                player1CanJump = false;
            }
        }   
        else if(Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            if(player2CanJump)
            {
                player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, puissanceDeSaut));
                player2CanJump = false;
            }
        }

        
        
        player1CanJump = player1.GetComponent<AuSol>().GetAuSol();
                        
        player2CanJump = player2.GetComponent<AuSol>().GetAuSol();
        
        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■


        //Joueur 1
        float moveHorizontal1 = Input.GetAxis("Horizontal1");//On récupère la valeur du joystick en 0 et 1 
            Vector2 movement1 = new Vector2((moveHorizontal1 * vitesseMaxP1) * Time.deltaTime, player1.GetComponent<Rigidbody2D>().velocity.y); // On créer un vecteur mouvement ou on ramène la valeur du joystick de 0-1 à 0_vitesseMax
            player1.GetComponent<Rigidbody2D>().velocity = movement1; //On applique ce mouvement au player 1

        //Joueur 2
        float moveHorizontal2 = Input.GetAxis("Horizontal2");//On récupère la valeur du joystick en 0 et 1 
        Vector2 movement2 = new Vector2((moveHorizontal2 * vitesseMaxP2) * Time.deltaTime, player2.GetComponent<Rigidbody2D>().velocity.y); // On créer un vecteur mouvement ou on ramène la valeur du joystick de 0-1 à 0_vitesseMax
        player2.GetComponent<Rigidbody2D>().velocity = movement2; //On applique ce mouvement au player 2

    }
}
