using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rgb;

    public float movementSpeed = 1000f;
    public bool confIsMoving;
    public bool frmCtrIsDead;

    public float xfrmCtrInput;
    public float yfrmCtrInput;

    public int playerDirection;

    public int lastPlayerDirection;
    private Vector3 lastPosition;



    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
        

    }

    private void FixedUpdate()
    {
        GetDirection();


        if (this.transform.position == lastPosition)
        {
            confIsMoving = false;
        }
        else
        {
            confIsMoving = true;
        }
        lastPosition = transform.position;

        if (frmCtrIsDead == true)
        {
            rgb.velocity = new Vector2(0, 0);

        }
    }

    public void Move(float xInput, float yInput)
    {
        xfrmCtrInput = xInput;
        yfrmCtrInput = yInput;

        rgb.velocity = new Vector2(0, 0);

        rgb.velocity = new Vector2(movementSpeed * Time.deltaTime * xfrmCtrInput,
            movementSpeed * Time.deltaTime * yfrmCtrInput);
    }

    private void GetDirection()
    {
        //voir cadran pour référence, mais on trouve la direction que le jouer veut se déplacer
        //1->droite  2-> gauche  3-> haut  4->bas  0->erreur

        if (playerDirection != 0)
        {
            lastPlayerDirection = playerDirection;
        }

        if (xfrmCtrInput > 0 && yfrmCtrInput >= -0.45 && yfrmCtrInput <= 0.45)
        {
            playerDirection = 1;
        }
        else if (xfrmCtrInput < 0 && yfrmCtrInput <= 0.45 && yfrmCtrInput >= -0.45)
        {
            playerDirection = 2;
        }
        else if (yfrmCtrInput > 0 && xfrmCtrInput <= 0.45 && xfrmCtrInput >= -0.45)
        {
            playerDirection = 3;
        }
        else if (yfrmCtrInput < 0 && xfrmCtrInput <= 0.45 && xfrmCtrInput >= -0.45)
        {
            playerDirection = 4;
        }
        else
        {
            playerDirection = 0;

        }
    }

}

