using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{
    public class Enemy : MonoBehaviour
    {
        public int health;
        public int damage;
        public float attackRate = .5f;
        public float attackRange = 2f;
        public float attackDuration = 1f;
        public Transform target;
        public NavMeshAgent nav;

        private float attackTimer = 0f;
        

        protected virtual void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        protected virtual void Attack()
        {
            print("Ya dun goofded it all up");
        }
        protected virtual void OnAttackEnd()
        { }

        IEnumerator AttackDelay(float delay)
        {
            //stop navigation
            nav.Stop();
            yield return new WaitForSeconds(delay);
            if (nav.isOnNavMesh)
            {
                //resume navigation
                nav.Resume();
            }
            
            //CALL OnAttackEnd()
        }

        protected virtual void Update()
        {
            if (target == null) { return; }
            //Increase attack timer
            attackTimer += Time.deltaTime;
            //IF attackTimer > attackRate
            if (attackTimer > attackRate)
            {
                //Get distance from enemy to target
                float distance = Vector3.Distance(transform.position, target.position);
                //IF distance < attack range
                if (distance <= attackRange)
                {
                    //Call Attack()
                    Attack();
                    //Reset attackTimer
                    attackTimer = 0;
                    //StartCoroutine for attack delay
                    StartCoroutine("AttackDelay");
                }
            }
        }
    }
}
