using CSharpRoguelike.Map.Tile;
using GoRogue.MapViews;


namespace CSharpRoguelike.Map.Generation
{

    class MapGeneration
    {
        public static ArrayMap<bool> mapData;

        public static void CreateMap(int mapWidth, int mapHeight, int maxRooms, int roomMinSize, int roomMaxSize, int attemptsPerRoom)
        {
            //create mapview
            mapData = new ArrayMap<bool>(mapWidth, mapHeight);

            //create rooms on map
            GoRogue.MapGeneration.Generators.RandomRoomsGenerator.Generate(mapData, maxRooms, roomMinSize, roomMaxSize, attemptsPerRoom);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    //mapData contains true for a passable tile (floor) and false for a non passable tile (wall)
                    if (mapData[x, y])
                    {
                        GameLoop.mapConsole.tileArray[GoRogue.Coord.ToIndex(x, y, mapWidth)] = new Floor();
                    }
                    else
                    {
                        GameLoop.mapConsole.tileArray[GoRogue.Coord.ToIndex(x, y, mapWidth)] = new Wall();
                    }
                }
            }
        }
    }
}

