using CSharpRoguelike.Map.Tile;
using SadConsole;
using GoRogue;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Microsoft.Xna.Framework;

namespace CSharpRoguelike.Map.Generation
{

    class MapGeneration  
    {
        public static GoRogue.MapViews.ArrayMap<bool> mapData;

        public static void CreateMap(int mapWidth, int mapHeight, int maxRooms, int roomMinSize, int roomMaxSize, int attemptsPerRoom)
        {

            //create mapview
            mapData = new GoRogue.MapViews.ArrayMap<bool>(mapWidth, mapHeight);

            //create rooms on map
            GoRogue.MapGeneration.Generators.RandomRoomsGenerator.Generate(mapData, maxRooms, roomMinSize, roomMaxSize, attemptsPerRoom);

            //update console
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    //mapview contains true for a passable tile (floor) and false for a non passable tile (wall)
                    if (mapData[x, y])
                        GameLoop.mapConsole.SetGlyph(x, y, ' ');

                    else
                        GameLoop.mapConsole.SetGlyph(x, y, '#');
                        GameLoop.mapConsole.SetForeground(x, y, Color.Gray);
                }
            }
            
        }
    }
}
