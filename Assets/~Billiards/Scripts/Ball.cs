using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{

    public class Ball : MonoBehaviour
    {
        public float stopSpeed = 0.2f;

        private Rigidbody rigid;

        public GameObject ball;

        public int score = 0;
        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            //Check if vel is going up
            if (vel.y > 0) //If y-axis velocity is not 0
            {
                vel.y = 0; //Y-axis velocity is 0
            }
            if (vel.magnitude < stopSpeed) //If x-axis velocity is less than stopSpeed
            {
                vel = Vector3.zero; //X-axis velcoity is 0
            }
            rigid.velocity = vel;
            if (rigid.transform.position.y < -1)
            {
                gameObject.SetActive(false);
                score++;
            }
        }
           
        public void Hit(Vector3 dir, float impactForce)
        {
            rigid.AddForce(dir * impactForce, ForceMode.Impulse);
        }
    }
}
