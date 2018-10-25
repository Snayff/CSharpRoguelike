using System;
using SadConsole;
using Console = SadConsole.Console;
using GoRogue;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSharpRoguelike.Code.CustomConsoles;

namespace CSharpRoguelike
{
    class Game
    {

        //All sizes are in cells. Cell size is based on font dimensions/size. 
        //window info
        private static readonly int screenWidth = 200;
        private static readonly int screenHeight = 70;

        //info console info
        private static readonly int infoWidth = 30;
        private static readonly int infoHeight = screenHeight;
        private static Point infoPosition = new Point(screenWidth - infoWidth, 0);
        private static Console infoConsole;


        //message console info
        private static readonly int messageWidth = screenWidth - infoWidth;
        private static readonly int messageHeight = 15;
        private static Point messagePosition = new Point(0, screenHeight - messageHeight);
        private static Window messageConsole;

        //map console info
        private static readonly int viewportWidth = screenWidth - infoWidth;
        private static readonly int viewportHeight = screenHeight -  messageHeight;
        private static readonly int mapWidth = 100;
        private static readonly int mapHeight = 100;
        private static Point mapPosition = new Point(0, 0);
        private static Console mapConsole;



        static void Main(string[] args)
        {
            
            
            // Setup the engine and creat the main window.
            SadConsole.Game.Create("Graphics/Fonts/IBM.font", screenWidth, screenHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;
                        
            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //
            
            SadConsole.Game.Instance.Dispose();
        }
        
        private static void Update(GameTime time)
        {
            // Called each logic update.
        }

        private static void Init()
        {
            // Set our new console as the thing to render and process
            SadConsole.Global.CurrentScreen = new ScreenObject();

            //Map Console
            mapConsole = new EntityConsole(); //mapWidth, mapHeight
            mapConsole.ViewPort = new Microsoft.Xna.Framework.Rectangle(mapPosition.X, mapPosition.Y, viewportWidth, viewportHeight);
            mapConsole.Position = mapPosition;
            mapConsole.Fill(Color.White, Color.Black, 0);
            SadConsole.Global.CurrentScreen.Children.Add(mapConsole);
            mapConsole.IsVisible = true;
            Global.FocusedConsoles.Set(mapConsole);

            //Info Console
            infoConsole = new Console(infoWidth, infoHeight);
            infoConsole.Position = infoPosition;
            infoConsole.Fill(Color.White, Color.Orange, 0);
            infoConsole.Print(1, 1, "Info");
            SadConsole.Global.CurrentScreen.Children.Add(infoConsole);

            //Message Console
            messageConsole = new SadConsole.Window(messageWidth, messageHeight);
            messageConsole.Position = messagePosition;
            messageConsole.Fill(Color.White, Color.Purple, 0);
            messageConsole.Print(1, 1, "Message");
            SadConsole.Global.CurrentScreen.Children.Add(messageConsole);
            messageConsole.Show(); //as its a window need to declare its visible
            
        }


    }
}
