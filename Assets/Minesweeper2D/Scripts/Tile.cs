using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        //Store x and y coordinate in array for later use
        public int x = 0;
        public int y = 0;
        public bool isMine = false;
        public bool isRevealed = false;
        [Header("References")]
        public Sprite[] emptySprites;
        public Sprite[] mineSprites;

        private SpriteRenderer rend;

        void Awake()
        {
            //grab reference to sprite renderer
            rend = GetComponent<SpriteRenderer>();
        }
        // Use this for initialization
        void Start()
        {
            //Randomly decide if it's a mine or not
            isMine = Random.value < .05f;
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            isRevealed = true;
            if (isMine)
            {
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                rend.sprite = emptySprites[adjacentMines];
            }
        }

		/*public void flag()
		{
			if (isRevealed == false) 
			{
				rend.sprite = mineSprites
			}
		}*/

        // Update is called once per frame
        void Update()
        {

        }
    }
}
