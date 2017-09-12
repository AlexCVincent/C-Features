using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDilfense
{
    public class Projectile : MonoBehaviour
    {
        public float damage = 50f;
        public float speed = 50f;
        public Vector3 direction;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //LET velocity = direction.normalized * speed
            Vector3 velocity = direction.normalized * speed;
            //SET projectile's position += velocity * deltaTime
            transform.position += velocity * Time.deltaTime;

        }
        void OnTriggerEnter(Collider col)
        {
            //LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();
            // IF e != null
                //CALL e.DealDamage(damage)
                //Destroy gameObject

            //IF col's name == "Ground"
                //Destroy the projectile
        }
    }
}