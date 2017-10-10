using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDilfense
{
    public class Tower : MonoBehaviour
    {
        public Cannon cannon;
        public float attackRate = 0.25f;
        public float attackRadius = 5f;
        public float attackTimer = 0f;
        private List<Enemy> enemies = new List<Enemy>();
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            attackTimer = attackTimer + Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0;
            }
        }
        void OnTriggerEnter(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {
                enemies.Add(e);
            }
        }
        void OnTriggerExit(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e == null)
            {
                enemies.Remove(e);
            }
        }
        Enemy GetClosestEnemy()
        {
            //LET closest = null
            Enemy closest = null;
            //LET minDistance = float.MaxValue
            float minDistance = float.MaxValue;
            //FOREACH enemy in enemies
            foreach (var e in enemies)
            {
                float distance = Vector3.Distance(this.transform.position, e.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = e;
                }
            }
            return closest;
        }
        void Attack()
        {
            Enemy closest = GetClosestEnemy();
            if (closest != null)
            {
                cannon.Fire(closest);
            }
        }
        //List<Enemy> RemoveAllNulls(List<Enemy> listWithNulls)
        
    }
}
