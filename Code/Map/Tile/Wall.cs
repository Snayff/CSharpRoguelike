

namespace CSharpRoguelike.Map.Tile
{
    class Wall : TileBase
    {
        public Wall() : base()
        {

            Name = "Wall";
            //Foreground = Color.White; 
            //Background = Color.Transparent;
            Glyph = 175;

            IsBlockingMove = true;
            IsBlockingSight = true;
        }
    }
}
