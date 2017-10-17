using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float splosionRadius = 5f;
        public float splosionRate = 3f;
        public float impactForce = 10f;
        public GameObject explosionParticles;
        public Rigidbody reggie;

        private float splosionTimer = 0f;

        protected override void Update()
        {
            base.Update();
            //Start ignition timer now
            splosionTimer += Time.deltaTime;
        }

        void Splode()
        {
            reggie = GetComponent<Rigidbody>();
            //Perform Physics OverlapSphere with splosionRadius
            Collider[] hits = Physics.OverlapSphere(transform.position, splosionRadius);
            //Loop through all hits
            foreach (var hit in hits)
            {
                //If player
                Health h = hit.GetComponent<Health>();
                if (h != null)
                {
                    h.TakeDamage(damage);
                }
                Rigidbody r = hit.GetComponent<Rigidbody>();
                if (r != null)
                {
                    Vector3 dir = hit.transform.position - transform.position;
                    r.AddExplosionForce(impactForce, transform.position, splosionRadius);
                }
            }
        }
        protected override void Attack()
        {
            base.Attack();
            
        }
        protected override void OnAttackEnd()
        {
            base.OnAttackEnd();
            //If splosionTimer > splosionRate
            if (splosionTimer > splosionRate)
            {
                //Call Explode()
                Splode();
                Destroy(gameObject);
            }
            //Destroy self
            
        }
    }

    }

