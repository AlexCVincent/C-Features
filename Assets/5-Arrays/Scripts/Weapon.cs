using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{
    public class Weapon : MonoBehaviour
    {
        public int damage = 10;
        public int maxBullets = 30;
        public float bulletSpeed = 20f;
        public float fireInterval = .2f;
        public GameObject bulletPrefab;
        public Transform spawnPoint;

        private Bullet[] spawnedBullets;
        private int currentBullets = 0;
        private bool isFired = false;
        private Transform target;

        // Use this for initialization
        void Start()
        {
            spawnedBullets = new Bullet[maxBullets];
        }

        // Update is called once per frame
        void Update()
        {
            if (!(isFired && currentBullets < maxBullets))  //IF !isFired AND currentBullets < maxBullets
            {
                //StartCoroutine Fire
                StartCoroutine(Fire());
            }
             
        }

        void SpawnBullet()
        {
            /*  1. Instatiate a bullet clone
                2. Make a direction that goes to target
                3. Grab bullet script from clone
                4. Send bullet to target
                5. Store bullet in Array
                6. Increment currentBullets
            */
            GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            Vector3 eulerAngles = transform.eulerAngles;
            float angle = Vector3.Angle(Vector3.right, direction);
            eulerAngles.z = angle;
            transform.eulerAngles = eulerAngles;
            Bullet bullet = clone.GetComponent<Bullet>();
            bullet.direction = direction;
            spawnedBullets[currentBullets] = bullet;
            currentBullets++; 
        }
        IEnumerator Fire()
        {
            //Run whatever is here first
            isFired = true;

            SpawnBullet();

            yield return new WaitForSeconds(fireInterval);//wait a few seconds
            isFired = false;

            //Run whatever is here last 
        }
        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
