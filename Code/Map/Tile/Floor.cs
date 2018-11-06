
namespace CSharpRoguelike.Map.Tile
{
    class Floor : TileBase
    {
        public Floor() : base()
        {

            Name = "Floor";
            //Foreground = Color.Transparent;
            //Background = Color.Transparent;
            Glyph = 6;

            IsBlockingMove = false;
            IsBlockingSight = false;
        }
    }
}
