using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDilfense
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIAgent : MonoBehaviour
    {
        public Transform target;
        
        private NavMeshAgent nav;
        // Use this for initialization
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //If targe != null
            if (target != null)
            //Set destination to target's position
            {
                nav.SetDestination(target.position); 
            }
               
        }
    }
}
