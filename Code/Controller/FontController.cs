using SadConsole;

namespace CSharpRoguelike.Controller
{
    public static class FontController
    {
        public static FontMaster PlayerFontMaster = Global.LoadFont("Graphics/Entities/Player/RogueLikeChar.font");
        public static FontMaster ActorFontMaster = Global.LoadFont("Graphics/Entities/Player/RogueLikeChar.font");
        public static FontMaster MapFontMaster = Global.LoadFont("Graphics/Tiles/DungeonTiles.font");
        public static FontMaster BorderFontMaster = Global.LoadFont("Graphics/Fonts/C64.font");
    }
}
