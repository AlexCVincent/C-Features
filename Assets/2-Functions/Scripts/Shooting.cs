using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions
{
    public class Shooting : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public float projectileSpeed = 10;
        public float shootRate = 0.1f;

        private float shootTimer = 0f;

        // Update is called once per frame
        void Update()
        {
            // Increase shootTimer with deltaTime
            shootTimer += Time.deltaTime;
            // Check IF space bar is pressed AND IF shootTimer >= shootRate
            if (Input.GetKey(KeyCode.Space) && shootTimer >= shootRate)
            {
                // CALL Shoot()
                Shoot();
                // SET shootTimer = 0
                shootTimer = 0;
            }
        }

        void Shoot()
        {
            // Instantiate a new projectile
            GameObject clone = Instantiate(projectilePrefab);
            // Set position to player
            clone.transform.position = transform.position;
            // Grab Rigidbody from clone
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
            // Send it flying!
            rigid.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
        }
    }
}