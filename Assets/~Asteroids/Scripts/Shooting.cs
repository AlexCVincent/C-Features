using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;
        public float shootRate = .2f;

        float shootTimer = 0f;

        void Shoot()
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletReggie = bulletPrefab.GetComponent<Rigidbody2D>();
            bulletReggie.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > shootRate)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Shoot();
                    shootTimer = 0f;
                }
            }
        }
    }
}
