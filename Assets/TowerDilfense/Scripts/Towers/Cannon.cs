using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDilfense
{
    public class Cannon : MonoBehaviour
    {

        public Transform barrel;
        public GameObject projectilePrefab;

        // Use this for initialization
        void Start()
        {

        }

        public void Fire(Enemy targetEnemy)
        {
            Vector3 targetPos = targetEnemy.transform.position;

            Vector3 barrelPos = barrel.transform.position;

            Quaternion barrelRot = barrel.transform.rotation;

            Vector3 fireDirection = targetPos - barrelPos;

            this.transform.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);

            GameObject clone = Instantiate(projectilePrefab, barrelPos, barrelRot);

            Projectile p = clone.GetComponent<Projectile>();

            p.direction = fireDirection;
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
