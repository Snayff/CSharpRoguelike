using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using CSharpRoguelike.CustomConsole;

namespace CSharpRoguelike.Controller
{
    public class ScreenController
    {

        //All sizes are in cells. Cell size is based on font dimensions/size. 
        
        //window info
        public static readonly int ScreenWidth = 200;
        public static readonly int ScreenHeight = 70;

        //border info
        private static readonly int borderSize = 1;

        //info console info
        private static readonly int infoWidth = 30;
        private static readonly int infoHeight = ScreenHeight;
        private static Point infoPosition = new Point(ScreenWidth - infoWidth, 0);
        private static Console infoConsole;

        //message console info
        private static readonly int messageWidth = ScreenWidth - infoWidth;
        private static readonly int messageHeight = 15;
        private static Point messagePosition = new Point(0, ScreenHeight - messageHeight);
        private static Window messageConsole;

        //map console info
        private static readonly int viewportWidth = (ScreenWidth - infoWidth - (borderSize * 2)) / 2 - 1; //mapconsole  uses a square font which is twice the width of the other consoles
        private static readonly int viewportHeight = ScreenHeight - messageHeight - (borderSize * 2);
        private static Point mapPosition = new Point(0 + borderSize, 0 + borderSize);

        public static MapConsole MapConsole;  


        public ScreenController()
        {
            // Set our new console as the thing to render and process
            Global.CurrentScreen = new ScreenObject();

            CreateMapConsole();
            CreateInfoConsole();
            CreateMessageConsole();
        }

        public void CreateMapConsole()
        {
            //map Console
            MapConsole = new MapConsole(ControllerContainer.MapController.MapWidth, ControllerContainer.MapController.MapHeight, viewportWidth, viewportHeight);
            MapConsole.Position = mapPosition;
            Global.CurrentScreen.Children.Add(MapConsole);
            Global.FocusedConsoles.Set(MapConsole);
        }


        public void CreateInfoConsole()
        {
            //Info Console
            infoConsole = new Console(infoWidth, infoHeight);
            infoConsole.Position = infoPosition;
            infoConsole.Fill(Colour.DefaultTextColour, Colour.InfoConsoleFillColour, 0);
            infoConsole.Print(1, 1, "Info");
            Global.CurrentScreen.Children.Add(infoConsole);
        }

        public void CreateMessageConsole()
        {
            //Message Console
            messageConsole = new Window(messageWidth, messageHeight);
            messageConsole.Position = messagePosition;
            messageConsole.Fill(Colour.DefaultTextColour, Colour.MessageConsoleFillColour, 0);
            messageConsole.Print(1, 1, "Message");
            Global.CurrentScreen.Children.Add(messageConsole);
            messageConsole.Show(); //as its a window need to declare its visible
        }

    }
}
