using Microsoft.Xna.Framework;
using SadConsole;
using CSharpRoguelike.Controller;

namespace CSharpRoguelike.EntityType
{
    public class Player : Actor
    {

        public Player() : base(Color.White, Color.Transparent, 1)
        {
            font = FontController.playerFontMaster.GetFont(Font.FontSizes.One);
            Animation.Font = font;
        }
    }
}
