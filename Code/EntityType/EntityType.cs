using Microsoft.Xna.Framework;
using SadConsole;
using CSharpRoguelike.Controller;

namespace CSharpRoguelike.EntityType
{
    public abstract class EntityBase : SadConsole.Entities.Entity 
    {
        public EntityBase(Color foreground, Color background, int glyph, int width = 1, int height = 1) : base(width, height, FontController.actorFontMaster.GetFont(Font.FontSizes.One))
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

    }





}
