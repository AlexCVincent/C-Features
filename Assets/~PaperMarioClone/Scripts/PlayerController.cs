﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float walkSpeed = 20f;
        public float runSpeed = 30f;
        public float jumpHeight = 10f;
        public bool moveInJump = false;
        public bool isRunning = false;
        private CharacterController controller;
        public bool isGrounded
        {
            get { return controller.isGrounded; }
        }
        private Vector3 gravity;
        private Vector3 movement;
        [HideInInspector] public Vector3 inputDir;
        private bool jump = false;

        // Use this for initialization
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            //Is the controller running
            if (isRunning)
                movement *= runSpeed; //Run Forrest
            else
                movement *= walkSpeed;//Walk!
            //Is the controller grounded?
            if (isGrounded)
            {
                //Cancel out gravity only if you're grounded
                gravity = Vector3.zero;
                //.Is controller jumping
                if (jump)
                {
                    //Make character jump
                    gravity.y = jumpHeight;
                    jump = false;
                }
            }
            else
            {
                //Applying gravity
                gravity += Physics.gravity * Time.deltaTime;
            }


            //Apply movement
            movement += gravity;
            controller.Move(movement * Time.deltaTime);
        }
        //Controller Jump
        public void Jump()
        {
            //Jump!
            jump = true;
        }

        public void Move(float inputH, float inputV)
        {
            //Is moveinjump enabled OR is moveinjump disabled and isGrounded is true
            if (moveInJump || (moveInJump == false && isGrounded))
            {
                inputDir = new Vector3(inputH, 0, inputV);
            }

            //Transform direction of movement based on input
            movement = transform.TransformDirection(inputDir);
        }
        }
    }

