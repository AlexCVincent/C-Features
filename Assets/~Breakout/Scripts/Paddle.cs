using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Paddle : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public Ball currentBall;
        // Use this for initialization
        public Vector2[] directions = new Vector2[]
        {
            new Vector2(-.5f, .5f),
            new Vector2(.5f,-.5f)
        };
        void Start()
        {
            currentBall = GetComponentInChildren<Ball>();
        }

        public void Fire()
        {
            //Detach as child
            currentBall.transform.SetParent(null);
            //Generate random dir from list of directions
            Vector3 randomDir = directions[Random.Range(0, directions.Length)];
            //Fire off a ball in randomDirection
            currentBall.Fire(randomDir);
        }

        // Update is called once per frame
        void Update()
        {
            checkInput();
            Movement();
        }
        void checkInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            } 

        }
        void Movement()
        {
            // Get input on horizontal axis
            float inputH = Input.GetAxis("Horizontal");
            //Set force to direction (inputH to decide which direction)
            Vector3 force = transform.right * inputH;
            //Apply movement seed to force
            force *= movementSpeed;
            //Apply deltaTime to force
            force *= Time.deltaTime;
            //Add force to position
            transform.position += force;
        }
    }
}
