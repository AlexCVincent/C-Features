using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopsArrays
{
    public class Loops : MonoBehaviour
    {
        public GameObject[] spawnPrefabs;
        public float frequency = 5;
        public float amplitude = 6;
        public int spawnAmount = 50;
        public float spawnRadius = 5f;
        public string message = "Print This";
        public float printTime = 2f;

        private float timer = 0;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            /*  
            while (condition) 
            {
                // Statement
            } 
            */
            SpawnObjectsWithSine();
        }

        // Update is called once per frame
        void Update()
        {
            // Loop through until timer gets to printTime
            while (timer <= printTime) // STICK AROUND
            {
                // Count up timer in seconds
                timer += Time.deltaTime;
                print("PUT THE COOKIE DOWN!");
            }
        }

        void SpawnObjectsWithSine()
        {
            /*
            for (initialization; condition; iteration) 
            {
                // Statement(s)
            }
            */

            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                int randomIndex = Random.Range(0, spawnPrefabs.Length);
                GameObject randomPrefab = spawnPrefabs[randomIndex];
                GameObject clone = Instantiate(randomPrefab);
                //Grab the MeshRenderer
                Renderer rend = clone.GetComponent<Renderer>();
                //Change colour
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                float a = 1;
                rend.material.color = new Color(r, g, b);
                // Generated random position within circle (sphere actually)
                float x = Mathf.Sin(i * frequency) * amplitude;
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                Vector3 randomPos = transform.position + new Vector3(x, y, z);
                // Cancel out the Z
                randomPos.z = 0;
                // Set spawned object's position 
                clone.transform.position = randomPos;
            }
        }

        void SpawnObjects()
        {
            /*
            for (initialization; condition; iteration) 
            {
                // Statement(s)
            }
            */

            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                //GameObject clone = Instantiate(randomPrefab);
                // Generated random position within circle (sphere actually)
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                // Cancel out the Z
                randomPos.z = 0;
                // Set spawned object's position 
                //clone.transform.position = randomPos;
            }
        }
    }
}