using SadConsole;
using Microsoft.Xna.Framework;


namespace CSharpRoguelike.Map.Tile
{
    //Tilebase inherits from SadConsole.Cell which is a class that all surfaces use in rendering
    abstract class TileBase : Cell
    {
        public bool IsBlockingMove;
        public bool IsBlockingSight;

        public TileBase(Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {

        }
    }

    class Wall : TileBase
    {
        public Wall() : base(Color.White, Color.Gray, '#' )
        {
            IsBlockingMove = true;
            IsBlockingSight = true; 
        }
    }

    class Floor : TileBase
    {
        public Floor() : base(new Color(25, 25, 25), Color.Black, ' ')
        {
            IsBlockingMove = false;
            IsBlockingSight = false;
            
        }
    }
} 