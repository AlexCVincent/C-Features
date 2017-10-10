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

		public void FFuncover(int x, int y, bool[,] visited)
		{
			if(x >= 0 && y>= 0 && x < width && y < height)
			{
				if (visited[x, y])
				{
					return;
				}
				Tile tile = tiles[x, y];
				int adjacentMines = GetAdjacentMineCountAt(tile);
				tile.Reveal(adjacentMines);

				if(adjacentMines > 0)
				{
					return;
				}

				visited[x, y] = true;

				FFuncover(x-1, y, visited);
				FFuncover(x + 1, y, visited);
				FFuncover(x, y - 1, visited);
				FFuncover(x, y + 1, visited);
			}
			}

		public void UncoverMines(int mineState)
		{
            
			for(int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					Tile currentTile = tiles[x, y];
					if (currentTile.isMine) 
					{
						int adjacentMines = GetAdjacentMineCountAt (currentTile);
						currentTile.Reveal (adjacentMines, mineState);
					}
				}
			}
		}

		bool NoMoreEmptyTiles()
		{
			int emptyTileCount = 0;
			for(int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					Tile currentTIle = tiles [x, y];
					if(!currentTIle.isRevealed && !currentTIle.isMine)
					{
						emptyTileCount++;
					}
					
				}
                
            }
            return emptyTileCount == 0;
        }

		public void SelectTile(Tile selectedTile)
		{
			int adjacentMines = GetAdjacentMineCountAt (selectedTile);
			selectedTile.Reveal (adjacentMines);
			if (selectedTile.isMine) 
			{
				UncoverMines(0);
				//Put gameover challenge here
			}
			else if(adjacentMines == 0)
			{
				int x = selectedTile.x;
				int y = selectedTile.y;
				FFuncover(x, y, new bool[width, height]);
			}
			if(NoMoreEmptyTiles())
			{
				UncoverMines(1);
				//Put win challenge here
			}
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
			if (Input.GetKeyDown (KeyCode.Mouse0)) 
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
				if (hit.collider != null) 
				{
					Tile hitTile = hit.collider.GetComponent<Tile> ();
					if (hitTile != null) 
					{
						SelectTile (hitTile);
					}
				}
			}
        }
    }
}
