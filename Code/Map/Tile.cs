using SadConsole;
using Microsoft.Xna.Framework;


namespace CSharpRoguelike.Map.Tile
{
    //Tilebase inherits from SadConsole.Cell which is a class that all surfaces use in rendering
    abstract class TileBase : Cell
    {
        public bool IsBlockingMove;
        public bool IsBlockingSight;
        public string Name;

        public TileBase() : base()
        {

        }
    }

    class Wall : TileBase
    {
        public Wall() : base()
        {
            
            Name = "Wall";
            Foreground = Color.White; 
            Background = Color.Transparent;
            Glyph = '#';

            IsBlockingMove = true;
            IsBlockingSight = true;
        }
    }

    class Floor : TileBase
    {
        public Floor() : base()
        {

            Name = "Wall";
            Foreground = Color.Transparent;
            Background = Color.Transparent;
            Glyph = ' ';

            IsBlockingMove = false;
            IsBlockingSight = false;
        }
    }
} 