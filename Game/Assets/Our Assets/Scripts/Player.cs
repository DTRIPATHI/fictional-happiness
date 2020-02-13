﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement
    [SerializeField] public float movespeed;
    Rigidbody r;
    float deltaX;
    public bool isGrounded = true;

    

    //animation
    public Animator anime;
    private float speedPercent;
    private bool crouch;
    public int count = 0;


    public void Start()
    {
        r = GetComponent<Rigidbody>();
       
    }
    void Update()
    {
        
        //movement
        if (isGrounded)
        {
            movement();

            //animation
            speedPercent = Math.Abs(Input.GetAxis("Horizontal"));
            anime.SetFloat("speedPercent", speedPercent);


        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            if (deltaX < 0)
            {
                r.AddForce(new Vector3(-3 * movespeed / 4, 5, 0), ForceMode.Impulse);
                movespeed = 0;
            }

            if (deltaX > 0)
            {
                r.AddForce(new Vector3(3 * movespeed / 4, 5, 0), ForceMode.Impulse);
                movespeed = 0;
            }
            else if (deltaX == 0)
                r.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isGrounded = false;
            
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            crouch = true;
            anime.SetBool("crouch", crouch);
            count++; 

        }
        if (count == 2)
        {
            crouch = false;
            anime.SetBool("crouch", crouch);
            count = 0;
        }
        



    }

    //For Smooth movement
    public void movement()
    {
        deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = new Quaternion(transform.rotation.x, 90f, transform.rotation.z, 90f);
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                deltaX = 0;

            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = new Quaternion(transform.rotation.x, -90f, transform.rotation.z, 90f);
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                deltaX = 0;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 90f);
            if (Input.GetKey(KeyCode.DownArrow))
            {
                deltaX = 0;

            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {   
            transform.rotation = new Quaternion(transform.rotation.x, - 600, transform.rotation.z, 90f);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                deltaX = 0;

            }
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            movespeed = 7f;
        }
        else
        {
            movespeed = 3f;
        }
        var newXPos = transform.position.x + deltaX;
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
            movespeed = 0;
        }

    }
}
