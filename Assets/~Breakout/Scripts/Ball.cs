using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        public float speed = 5f;
        private Vector3 velocity;

        public void Fire(Vector3 direction)
        {
            velocity = direction * speed;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            //Grab contact point of collision
            ContactPoint2D contact = other.contacts[0];
            //Calculate the reflection point of the ball using velocity and contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            //calculate new velocity from reflection multiply by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
            //velocity = direction X speed
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Moves ball using velocity & deltaTime
            transform.position += velocity * Time.deltaTime;
        }
    }
}
