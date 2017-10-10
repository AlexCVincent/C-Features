using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Enemy : MonoBehaviour
    {
        public int health;
        public int damage;
        public float attackRate = .5f;

        private float attackTimer = 0f;

        public virtual void Attack()
        {
            print("Ya dun goofded it all up");
        }
    }
}
