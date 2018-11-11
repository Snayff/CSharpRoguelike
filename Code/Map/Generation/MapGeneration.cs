using CSharpRoguelike.Map.Tile;
using CSharpRoguelike.Controller;

namespace CSharpRoguelike.Map
{

    public class MapGeneration
    {
        
        public static void CreateMap(int maxRooms, int roomMinSize, int roomMaxSize, int attemptsPerRoom)
        {
            ///use MapData for dimensions of map and store values in same (MapData)
            
            //create rooms on map
            GoRogue.MapGeneration.Generators.RandomRoomsGenerator.Generate(ControllerContainer.MapController.MapData, maxRooms, roomMinSize, roomMaxSize, attemptsPerRoom);

            int width = ControllerContainer.MapController.MapData.Width;
            int height = ControllerContainer.MapController.MapData.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
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

