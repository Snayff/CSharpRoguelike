using Microsoft.Xna.Framework;

namespace CSharpRoguelike.EntityType
{
    public class EntityBase : SadConsole.Entities.Entity 
    {
        public EntityBase(Color foreground, Color background, int glyph, int width = 1, int height = 1) : base(width, height)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

    }

    public class Actor : EntityBase
    {

        public Actor(Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

        public bool MoveBy(Point newPosition)
        {

            // Check the map if we can move to this new position
            if (true) //(map.IsTileWalkable(newPosition.X, newPosition.Y))
            {
                Position += newPosition;
                return true;
            }
            else
                return false;
        }
    }

    public class Player : Actor
    {

        public Point PreviousPosition;

        public Player() : base(Color.WhiteSmoke, Color.Transparent, '@')
        {
            
        }
    }

}
