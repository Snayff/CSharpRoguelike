using CSharpRoguelike.Map.Tile;
using CSharpRoguelike.Controller;

namespace CSharpRoguelike.Map
{

    public class MapGeneration
    {
        

        public static void CreateMap(int mapWidth, int mapHeight, int maxRooms, int roomMinSize, int roomMaxSize, int attemptsPerRoom)
        {

            //create rooms on map
            GoRogue.MapGeneration.Generators.RandomRoomsGenerator.Generate(ControllerManager.mapController.mapData, maxRooms, roomMinSize, roomMaxSize, attemptsPerRoom);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    //mapData contains true for a passable tile (floor) and false for a non passable tile (wall)
                    if (ControllerManager.mapController.mapData[x, y])
                    {
                        ControllerManager.mapController.tileArray[x, y] = new Floor();
                    }
                    else
                    {
                        ControllerManager.mapController.tileArray[x, y] = new Wall();
                    }
                }
            }
        }


    }
}

