using SadConsole;

namespace CSharpRoguelike.Controller
{
    public static class FontController
    {
        public static FontMaster playerFontMaster = Global.LoadFont("Graphics/Entities/Player/RogueLikeChar.font");
        public static FontMaster actorFontMaster = Global.LoadFont("Graphics/Entities/Player/RogueLikeChar.font");
        public static FontMaster mapFontMaster = Global.LoadFont("Graphics/Tiles/DungeonTiles.font");
        public static FontMaster borderFontMaster = Global.LoadFont("Graphics/Fonts/C64.font");
    }
}
