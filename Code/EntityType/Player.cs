using Microsoft.Xna.Framework;
using SadConsole;

namespace CSharpRoguelike.EntityType
{
    public class Player : Actor
    {

        public Player() : base(Color.White, Color.Transparent, 1)
        {
            font = FontManager.playerFontMaster.GetFont(Font.FontSizes.One);
            Animation.Font = font;
        }
    }
}
