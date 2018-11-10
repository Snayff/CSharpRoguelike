
namespace CSharpRoguelike.Controller
{
    public class ControllerManager
    {

        public static EntityController entityController;
        public static MapController mapController;
        public static ScreenController screenController;
        public static InputController inputController;

        public ControllerManager()
        {
            mapController = new MapController();
            screenController = new ScreenController();
            entityController = new EntityController();
            inputController = new InputController();
        }
    }
}
