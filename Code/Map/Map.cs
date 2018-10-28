using System.Collections.ObjectModel;
using CSharpRoguelike.EntityType;
using CSharpRoguelike.Map.Tile;

namespace CSharpRoguelike.Map
{
    class MapBase
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ObservableCollection<EntityBase> Entities;

        public TileBase[] Tiles;

        public MapBase(int width, int height)
        {
            Width = width;
            Height = height;

            // Create our tiles for the map
            Tiles = new TileBase[width * height];

            // Fill the map with floors.
            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i] = new Floor();

            // Set some temp walls, will be replaced by random generation
            // y * width + x = index of that x,y combination
            Tiles[5 * width + 5] = new Wall();
            Tiles[2 * width + 5] = new Wall();
            Tiles[10 * width + 29] = new Wall();
            Tiles[17 * width + 44] = new Wall();

            // Holds all entities on the map
            Entities = new ObservableCollection<EntityBase>();
            
        }
    }
}