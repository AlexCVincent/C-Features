using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float impactForce = 10f;
        public float knockBack = 5f;

        public Rigidbody reggie;

        protected override void Awake()
        {
            base.Awake();
        }
        protected override void Attack()
        {
            // Add force to self
            base.Attack();
        }

        void OnCollisionEnter(Collision col)
        {
            //If collision hits player
                //Add impactForce to player
        }
    }
}