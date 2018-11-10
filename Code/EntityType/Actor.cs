using CSharpRoguelike.Controller;
using Microsoft.Xna.Framework;


namespace CSharpRoguelike.EntityType
{
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
            if (ControllerManager.mapController.IsTileWalkable(Position + relativePosition))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
