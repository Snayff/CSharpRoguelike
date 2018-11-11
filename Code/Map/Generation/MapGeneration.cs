using CSharpRoguelike.Map.Tile;
using CSharpRoguelike.Controller;

namespace CSharpRoguelike.Map
{

    public class MapGeneration
    {
        
        public static void CreateMap(int mapWidth, int mapHeight, int maxRooms, int roomMinSize, int roomMaxSize, int attemptsPerRoom)
        {
            //create rooms on map
            GoRogue.MapGeneration.Generators.RandomRoomsGenerator.Generate(ControllerContainer.MapController.MapData, maxRooms, roomMinSize, roomMaxSize, attemptsPerRoom);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    //mapData contains true for a passable tile (floor) and false for a non passable tile (wall)
                    if (ControllerContainer.MapController.MapData[x, y])
                    {
                        ControllerContainer.MapController.TileArray[x, y] = new Floor();
                    }
                    else
                    {
                        ControllerContainer.MapController.TileArray[x, y] = new Wall();
                    }
                }
            }
        }


    }
}

