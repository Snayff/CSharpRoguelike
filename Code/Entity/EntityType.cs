using Microsoft.Xna.Framework;

namespace CSharpRoguelike.EntityType
{
    public abstract class EntityBase : SadConsole.Entities.Entity 
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
        public Point PreviousPosition;

        public Actor(Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

        public void Move(Point newPosition)
        {
            PreviousPosition = Position;
            Position += newPosition;
        }

        public bool CheckTargetLocationIsValid(Point relativePosition)
        {
            // Check the map if we can move to this new position
            if (GameLoop.mapConsole.IsTileWalkable(Position + relativePosition))
            {
                return true;
            }
            else
            {
                return false;
            }
                

        }
    }

    public class Player : Actor
    {

        public Player() : base(Color.WhiteSmoke, Color.Transparent, '@')
        {

        }
    }

}
