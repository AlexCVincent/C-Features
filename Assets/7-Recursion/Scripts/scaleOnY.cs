using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recursion
{
    

    public class scaleOnY : MonoBehaviour
    {
        public float maxScale = 100f;

        private float originalY = 0f;
        private float percentY = 0f;
        // Use this for initialization
        void Start()
        {
            originalY = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 scale = transform.localScale;
            Vector3 position = transform.position;
            //e.g. 0.8 = 80/100
            percentY = position.y / originalY;
            //e.g.             .2 = 1 - .8
            float inversePercentY = 1 - percentY;
            //e.g.         20 = 100 * 0.2
            float scaleFactor = maxScale * inversePercentY;
            //e.g. (20, 20, 20) = (1, 1, 1) * 20
            scale = Vector3.one * scaleFactor;

            transform.localScale = scale;
        }
    }
}
