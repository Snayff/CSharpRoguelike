
namespace CSharpRoguelike.Controller
{
    public class ControllerContainer
    {

        public static EntityController EntityController;
        public static MapController MapController;
        public static ScreenController ScreenController;
        public static InputController InputController;

        public ControllerContainer()
        {
            MapController = new MapController();
            ScreenController = new ScreenController();
            EntityController = new EntityController();
            InputController = new InputController();
        }
    }
}
