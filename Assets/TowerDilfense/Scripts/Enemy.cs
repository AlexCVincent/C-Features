using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDilfense
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f;
        // Use this for initialization
        public void takeDamage()
        {
            //SET health -= damage
            health -= damage;
            //IF health <= 0
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            //Destroy the enemy
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
