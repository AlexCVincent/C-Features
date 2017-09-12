using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;

        Tile SpawnTile(Vector3 pos)
        {
            //Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();
            return currentTile;
        }

        public int GetAdjacentMineCountAt(Tile t)
        {
            int count = 0;
            // Loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    //Calculate desired coordinates from ones attained
                    int desiredX = t.x + x;
                    int desiredY = t.y + y;

                    // IF desiredX is within range of tiles array length
                    if (desiredX >= 0 && desiredY >= 0 && desiredX < width && desiredY < height)

                    {
                        // IF the element at index is a mine
                        Tile tile = tiles[desiredX, desiredY];
                        if (tile.isMine == true)
                        {
                            count++;
                        }

                        // Increment count by 1
                    }
                }
            }
            return count;
        }

        void GenerateTiles()
        {
            //Create new 2D array of size width x height
            tiles = new Tile[width, height];

            //loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //Store halfSize for later use
                    Vector2 halfSize = new Vector3(width / 2, height / 2);
                    //Pivot tiles around Grid
                    Vector2 pos = new Vector2(x - halfSize.x + .5f, y - halfSize.y + .5f);
                    // Apply spacing
                    pos *= spacing;
                    //Spawn the tile
                    Tile tile = SpawnTile(pos);
                    //Attached newly spawned tile to
                    tile.transform.SetParent(transform);
                    // Store it's array  coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    //Store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }
        }

        // Use this for initialization
        void Start()
        {
            GenerateTiles();
        }

        // Update is called once per frame
        void Update()
        {
            
            //LET mouseRay = Camera ScreenPointToRay mousePosition
       Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //LET hit = Physics2D Raycast from mouse ray
            RaycastHit2D hit =
            //IF hit collider != null
                // LET hitTile = hit collider's Tile component
                // IF hitTile != null
                    //LET adjacentMines = GetAdjacentMineCountAt hitTile
                    //CALL hitTile.Reveal(adjacentMines)
        }
    }
}
