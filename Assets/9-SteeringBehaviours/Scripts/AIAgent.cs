using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public Vector3 force;
        public Vector3 velocity;
        public float maxVelocity = 100f;
        public float maxDistance = 10f;
        public bool freezeRotation = false;

        private NavMeshAgent nav;
        private List<SteeringBehaviour> behaviours;

        void Start()
        {
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        void ComputeForces()
        {
            // SET force = Vector3 zero
            force = Vector3.zero;
            //FOR i = 0 to behaviours count
            for (int i = 0; i < behaviours.Count; i++)
            {
                //LET behaviour = behaviours[i]
                SteeringBehaviour behaviour = behaviours[i];
                //IF behaviour is not active
                if (behaviour.isActiveAndEnabled == false)
                {
                    //Continue
                    continue;
                }

                //SET force = force + behaviour's force() * weighting
                force = force + behaviour.force * behaviour.weighting;
                //IF force's magnitude is greater than maxVelocity
                if (force.magnitude > maxVelocity)
                {
                    //SET force = normalised force * maxVelocity
                    force = force.normalized * maxVelocity;
                    //break
                    break;
                }
                }
        }

        void ApplyVelocity()
        {
            //SET velocity = velocity + force * deltatime
            //IF velocity's magnitude > maxVelocity
                //SET velocity = mormalised velocity * maxVelocity
            // IF velocity's magnitude > 0
                // SET transform.position = transform.position + velocity * delta time
                //SET transform.rotation = Quaternion LookRotation (velocity)
        }

        void Update()
        {
            ComputeForces();
            ApplyVelocity();
        }
    }

}
