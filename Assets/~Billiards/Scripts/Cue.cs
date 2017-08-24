using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class Cue : MonoBehaviour
    {
        public Ball targetBall; //Target ball selected to strike with cue
        public float minPower = 0f; //The minimum force that maps the distance
        public float maxPower = 20f; ////The maximum force that maps to the distance
        public float maxDistance = 5f; //The max distance in units the cue can be dragged back

        private float hitPower; //The final calculated hit power to fire the ball
        private Vector3 aimDirection; //The aim direction the ball should fire
        private Vector3 prevMousePos; //The position of the mouse obtained when left clicking
        private Ray mouseRay; //The ray of the mouse

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(targetBall.transform.position, targetBall.transform.position + aimDirection * hitPower);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Check if left mouse button pressed
            if (Input.GetMouseButtonDown(0))
            {
                //store click position as the prevMousePos
                prevMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            //Check if left mouse button is pressed
            if (Input.GetMouseButton(0))
            {
                //Perform drag mechanic
                Drag();
            }
            else
            {
                //Perform aim mechanic
                Aim();
            }
            //Check if left mouse button is up
            if (Input.GetMouseButtonUp(0))
            {
                Fire();
            }           
        }
        void Aim()
        {
            //Calculate mouse ray before performing raycast
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Raycast Hit cointainer for the hit information
            RaycastHit hit;
            //Perform the Raycast
            if (Physics.Raycast(mouseRay, out hit))
            {
                //Obtain direction from the cue's position to the raycast's hit point
                Vector3 dir = transform.position - hit.point;
                //Convert direction to angle in degrees
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                //Rotate towards that angle
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                //Position cue to the ball's position
                transform.position = targetBall.transform.position;
            }
        }
        public void Deactivate()
        {
            //deactivates the cue
            gameObject.SetActive(false);
        }
        public void Activate()
        {
            //Activates the Cue
            Aim();
            gameObject.SetActive(true);
        }
        void Drag()
        {
            //Store target ball's position in smaller variable
            Vector3 targetPos = targetBall.transform.position;
            //Get mouse position in world units
            Vector3 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Calculate distance from previouse mous position to current mouse position
            float distance = Vector3.Distance(currMousePos, prevMousePos);
            //calculate a percentage for the distance
            float distPercentage = distance / maxDistance;
            //Use percentage of distance to map to the minPower - maxPower values
            hitPower = Mathf.Lerp(minPower, maxPower, distPercentage);
            //Position the cue back using distance
            transform.position = targetPos - transform.forward * distance;
            //Get direction to target ball
            aimDirection = (targetPos - transform.position).normalized;
        }
        void Fire()
        {
            //Hit the ba;; with direction and power
            targetBall.Hit(aimDirection, hitPower);
            //Deactivate the Cue when done
            Deactivate();
        }

    }
}
