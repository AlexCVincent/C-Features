using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDilfense
{
    public class AIAgentSpawner : MonoBehaviour
    {
        public GameObject aiAgentPrefab;
        public Transform target; //Target each AI agent should travel to.\
        public float spawnRate = 1f;
        public float spawnRadius = 1f;


        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            //draw a sphere to indicate the spawn radius
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        void Spawn()
        {
            //LET clone = new instance of aiAgentPrefab
            GameObject clone = Instantiate(aiAgentPrefab);
            //LET rand = random Inside Unit Sphere
            Vector3 rand = Random.insideUnitSphere;
            //SET rand.y = 0
            rand.y = 0;
            //SET clone's position to transform's position + rand * spawnRadius
            clone.transform.position = transform.position + rand * spawnRadius;
            //SET aiAgent = clone's AIAgent component
            AIAgent aiAgent = clone.GetComponent<AIAgent>();
            //SET aiAgent.target = target
            aiAgent.target = target; 
        }
        // Use this for initialization
        void Start()
        {
            //InvokeRepeating(functionName, time, repeatRate)
            //FunctionName = name of the function you want to call in the class
            //time         = delay for when the function gets called the first time
            //repeatRate   = how often the function gets called
            InvokeRepeating("Spawn", 0, spawnRate);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}