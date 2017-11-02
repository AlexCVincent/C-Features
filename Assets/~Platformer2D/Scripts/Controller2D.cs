using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller2D : MonoBehaviour
    {
        public float accelerate = 20f;
        public float jumpHeight = 10f;
        public float rayDistance = 1f;
        public LayerMask hitLayers;
        public bool isGrounded = false;

        private Rigidbody2D reggie2D;

        // Use this for initialization
        void Start()
        {
            reggie2D = GetComponent<Rigidbody2D>();
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position + -transform.up * rayDistance);
        }
        void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, rayDistance, hitLayers);
            if (hit.collider != null)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        public void Move(float inputH)
        {
            reggie2D.AddForce(transform.right * inputH * accelerate);
        }

        public void Jump()
        {
            reggie2D.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);

        }

        
    }
}
