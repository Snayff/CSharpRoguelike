using Microsoft.Xna.Framework;
using CSharpRoguelike.Map.Tile;
using GoRogue;
using GoRogue.MapViews;

namespace CSharpRoguelike.Controller
{
    public class MapController
    {
        public TileBase[,] tileArray;
        public TileBase[] cellArray;
        public ArrayMap<bool> mapData;
        public int mapWidth = 200;
        public int mapHeight = 200;

        public MapController()
        {
            //tile array holds all tile info and receives mapgen's converted output
            CreateTileArray(mapWidth, mapHeight);
            CreateCellArray(mapWidth, mapHeight);
            CreateMapData(mapWidth, mapHeight);
        }


        public void CreateMapData(int width, int height)
        {
            //create mapview
            mapData = new ArrayMap<bool>(width, height);
        }


        private void CreateTileArray(int width, int height)
        {
            //create tile array
            tileArray = new TileBase[width, height];
        }

        private void CreateCellArray(int width, int height)
        {
            //create the 1d cell array for passing to console
            cellArray = new TileBase[width * height];
        }

        public void InitialiseFoV()
        {
            var player = ControllerManager.entityController.player;
            Coord playerCoord = Coord.Get(player.Position.X, player.Position.Y);
            int visionRange = 5; //***update to take from player stat

            FOV fov = new FOV(mapData);
            fov.Calculate(playerCoord, visionRange);
        }

        public bool IsTileWalkable(Point newPoint)
        {
            int x = newPoint.X;
            int y = newPoint.Y;

            //check if target point is within array bounds
            if (x < 0 || y < 0 || x > tileArray.GetLength(0) || y > tileArray.GetLength(1))
            {
                return false;
            }
            else
            {
                //check if target tile blocks movement
                return !tileArray[x,y].IsBlockingMove;
            }

        }

        public void ConvertTileArrayToCellArray()
        {
            int width = tileArray.GetLength(0);
            int height = tileArray.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cellArray[x * width + y] = tileArray[x,y];
                }
            }
        }
    }
}

