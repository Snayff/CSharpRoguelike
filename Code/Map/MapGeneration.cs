using CSharpRoguelike.Map.Tile;
using GoRogue.MapViews;

namespace CSharpRoguelike.Map.Generation
{

    class MapGeneration
    {
        public static ArrayMap<bool> mapData;
        public static TileBase[] tileArray;

        public static void CreateMap(int mapWidth, int mapHeight, int maxRooms, int roomMinSize, int roomMaxSize, int attemptsPerRoom)
        {

            //create tile array
            tileArray = new TileBase[mapWidth * mapHeight];

            //create mapview
            mapData = new ArrayMap<bool>(mapWidth, mapHeight);
            //var mapView = new LambdaSettableMapView<bool>(mapWidth, mapHeight, pos => tileArray[pos.X, pos.Y].IsBlockingMove, (pos, val) => tileArray[pos.X, pos.Y].IsBlockingMove = val);

            //create rooms on map
            GoRogue.MapGeneration.Generators.RandomRoomsGenerator.Generate(mapData, maxRooms, roomMinSize, roomMaxSize, attemptsPerRoom);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    //mapview contains true for a passable tile (floor) and false for a non passable tile (wall)
                    if (mapData[x, y])
                    {
                        tileArray[GoRogue.Coord.ToIndex(x, y, mapWidth)] = new Floor();
                    }
                    else
                    {
                        tileArray[GoRogue.Coord.ToIndex(x, y, mapWidth)] = new Wall();
                    }
                }
            }
        }
    }
}

        //public static void UpdateMapOnConsole(int mapWidth, int mapHeight)
        //{   
        //    //update console
        //    for (int y = 0; y < mapHeight; y++)
        //    {
        //        for (int x = 0; x < mapWidth; x++)
        //        {
        //            //mapview contains true for a passable tile (floor) and false for a non passable tile (wall)
        //            if (mapView[x, y])
        //            {
        //                GameLoop.mapConsole[x, y] = new Wall();
        //            }
        //            else
        //            {
        //                GameLoop.mapConsole.SetGlyph(x, y, '#');
        //                GameLoop.mapConsole.SetForeground(x, y, Color.Gray);
        //            }
        //        }
        //    }
        //}

