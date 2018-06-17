﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { //This script experiments with moving with the help of a rigidbody and character controller

    Rigidbody rb; // rigidbody
    CharacterController controller; //character controller
    public float rotateSpeed=60;
    public float moveSpeed=10;
    public float inAirSpeed = 10;
    public float jumpSpeed=0;
    public float gravity = 20;

    private float lastYSpeed = 0;//need this for in air movement
    private float storedYValue=0;

    private float cooldown = 0;
    private bool wasjumping;
    private float originalMoveSpeed;
    private float helperSpeed;
    private AudioSource audio;
    

    Vector3 moveValues = Vector3.zero;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        originalMoveSpeed = moveSpeed;
        helperSpeed = moveSpeed / 2;
        audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
        //moveAddForce(); //pretty bad imo

        moveController(); //move with the help of the CController

	}

    void Rotate()
    {
        if (Input.GetAxis("Mouse X")!=0)//input gegeben
        {
            Vector3 turnVector = new Vector3(0.0f, Input.GetAxis("Mouse X"), 0.0f);//neuer richtungsvektor anhand des mouseInputs
            transform.Rotate(turnVector * rotateSpeed * Time.deltaTime);//rotieren des players mit hilfe der Rotate funktion
        }
    }

    void moveController()//this method utilized the Move() method of the character controller
    {
        storedYValue = transform.position.y;//zu beginn wird immer die momentane position gespeichert. Diese wird zur Berechnung der Gravity wichtig, da schneller gefallen werden soll

        if (controller.isGrounded)
        {
           /* if (wasjumping==true)
            {
                cooldown = cooldown-Time.deltaTime;//runterzaehlen
                moveSpeed = helperSpeed+(Time.deltaTime*10);//movespeed anpassen nach der landung
                if (cooldown<=0)
                {
                    cooldown = 0;
                    wasjumping = false;
                    moveSpeed = originalMoveSpeed;
                    helperSpeed = moveSpeed / 2;
                }
            }*/

            moveValues = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, 0.0f, Input.GetAxis("Vertical")*moveSpeed);
            moveValues = transform.TransformDirection(moveValues); //transforms vector from world into local space, therefore making the Rotatation of the player count
            audio.Play();
            if (Input.GetButton("Jump")&&cooldown<=0)
            {
               /* moveValues.y = jumpSpeed;//making the player jump
                wasjumping = true;
                cooldown = 1;*/
            }
        }
        else
        {
            //in air movement
            moveValues = new Vector3(Input.GetAxis("Horizontal") * inAirSpeed, lastYSpeed, Input.GetAxis("Vertical") * inAirSpeed); //use the stored y speed here, otherwise the jump won't work
            moveValues = transform.TransformDirection(moveValues); //transforms vector from world into local space, therefore making the Rotatation of the player count

        }


        if (!Input.GetButton("Jump")&&moveValues.y>storedYValue)//this is used to make low or high jumps. In the jumping phase, the y value is bigger than the stored y value. if the jump button is only pressed shortly, additional gravity will be applied, thus making a shorter jump
        {
            moveValues.y -= gravity * 2 * Time.deltaTime;
        }
        if (moveValues.y<storedYValue)//better jump: fall faster: if the y value is lower than the stored y value, the peak of the jump is over. Thus, additional gravity is added
        {
            moveValues.y -= gravity * 2 * Time.deltaTime;
           
        }
        else
        {
            moveValues.y -= gravity * Time.deltaTime;// using the defined gravity to let the player fall down
            
        }
        lastYSpeed = moveValues.y;//saving the y speed for the calculation in air movement. this is important, because Move() uses global worldspace

        controller.Move(moveValues*Time.deltaTime);
    }

}
