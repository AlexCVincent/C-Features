using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Seek : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance = 1f;
        public override Vector3 GetForce()
        {
            //SET force to vector3 zero
            force = Vector3.zero;
            //IF target = null
            if (target == null)
            {
                //return force
                return force;
            }

            //LET desiredforce = target position - transform position
            Vector3 desiredForce = target.position - transform.position;
            //IF desiredForce magnitude  > stoppingDistance
            if (desiredForce.magnitude > stoppingDistance)
            {
                //SET desiredForce = desiredForce normalised * weighting
                desiredForce = desiredForce.normalized * weighting;
                //SET force = desiredForce - owner.velocity
                force = desiredForce - owner.velocity;
            }
            //Return force
            return force;
        }

    }
}