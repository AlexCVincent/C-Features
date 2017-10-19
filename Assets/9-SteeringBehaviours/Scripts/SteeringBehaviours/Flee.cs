using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GGL;

namespace AI
{
    [RequireComponent(typeof(AIAgent))]
    public class Flee : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance = 1f;
        public Vector3 velocity;
        public float maxVelocity;
        public List<SteeringBehaviour> behaviours;
        void ComputeForces()
        {
            //SET force to vector3 zero
            Vector3 force = Vector3.zero;

            for (int i = 0; i < behaviours.Count; i++)
            {
                SteeringBehaviour behaviour = behaviours[i];
                if (behaviour.isActiveAndEnabled == false)
                {
                    continue;
                }
                force = force + behaviour.GetForce() * behaviour.weighting;
            }
            if (force.magnitude > maxVelocity)
            {
                force = force.normalized * maxVelocity;
            }
        }
        void ApplyVelocity()
        {
            velocity = velocity + force * Time.deltaTime;

            if (velocity.magnitude > maxVelocity)
            {
                velocity = velocity.normalized * maxVelocity;
            }
            if (velocity.magnitude > 0)
            {
                transform.position += velocity * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation(velocity);
            }
        }
        void FixedUpdate()
        {
            //IF target = null
            if (target == null)
            {
                //return force
                return;
            }

            //LET desiredforce = target position - transform position
            Vector3 desiredForce = transform.position - target.position;

            //IF desiredForce magnitude  > stoppingDistance
            if (desiredForce.magnitude > stoppingDistance)
            {
                //SET desiredForce = desiredForce normalised * weighting
                desiredForce = desiredForce.normalized * weighting;
                //SET force = desiredForce - owner.velocity
                force = desiredForce - owner.velocity;
            }

            #region GizmosGL

            GizmosGL.color = Color.red;
            GizmosGL.AddLine(transform.position, transform.position + desiredForce, 0.25f, 0.25f);
            GizmosGL.color = Color.red;
            GizmosGL.AddLine(transform.position, transform.position + force, 0.25f, 0.25f);

            #endregion

            //Return force
            return;
        }
    }

}
