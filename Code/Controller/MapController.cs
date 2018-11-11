using Microsoft.Xna.Framework;
using CSharpRoguelike.Map.Tile;
using GoRogue;
using GoRogue.MapViews;

namespace CSharpRoguelike.Controller
{
    public class MapController
    {
        public TileBase[,] TileArray;
        public TileBase[] CellArray;
        public ArrayMap<bool> MapData;
        public int MapWidth = 200;
        public int MapHeight = 200;

        public MapController()
        {
            //tile array holds all tile info and receives mapgen's converted output
            CreateTileArray(MapWidth, MapHeight);
            CreateCellArray(MapWidth, MapHeight);
            CreateMapData(MapWidth, MapHeight);
        }


        public void CreateMapData(int width, int height)
        {
            //create mapview
            MapData = new ArrayMap<bool>(width, height);
        }


        private void CreateTileArray(int width, int height)
        {
            //create tile array
            TileArray = new TileBase[width, height];
        }

        private void CreateCellArray(int width, int height)
        {
            //create the 1d cell array for passing to console
            CellArray = new TileBase[width * height];
        }

        public void InitialiseFoV()
        {
            var player = ControllerContainer.EntityController.Player;
            Coord playerCoord = Coord.Get(player.Position.X, player.Position.Y);
            int visionRange = 5; //***update to take from player stat

            FOV fov = new FOV(MapData);
            fov.Calculate(playerCoord, visionRange);
        }

        public bool IsTileWalkable(Point newPoint)
        {
            int x = newPoint.X;
            int y = newPoint.Y;

            //check if target point is within array bounds
            if (x < 0 || y < 0 || x > TileArray.GetLength(0) || y > TileArray.GetLength(1))
            {
                return false;
            }
            else
            {
                //check if target tile blocks movement
                return !TileArray[x,y].IsBlockingMove;
            }

        }

        public void ConvertTileArrayToCellArray()
        {
            int width = TileArray.GetLength(0);
            int height = TileArray.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    CellArray[x * width + y] = TileArray[x,y];
                }
            }
        }
    }
}

