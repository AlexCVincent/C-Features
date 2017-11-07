using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone
{
    [RequireComponent(typeof(Animator))]
    public class MarioAnimator : MonoBehaviour
    {
        private Animator anim;
        private PlayerController pController;


        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            pController = GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 inputDir = pController.inputDir;
            if (inputDir.x > 0)
            {
                anim.SetBool("isFlipped", false);
            }
            else if(inputDir.x < 0)
            {
                anim.SetBool("isFlipped", true);
            }
        }
    }
}
