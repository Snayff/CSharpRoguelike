using System;
using SadConsole;
using GoRogue;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSharpRoguelike
{
    class Program
    {

        //All sizes are in cells. Cell size is based on font dimensions/size. 
        //window info
        private static readonly int screenWidth = 200;
        private static readonly int screenHeight = 70;
        private static Console defaultConsole;

        //info console info
        private static readonly int infoWidth = 20;
        private static readonly int infoHeight = screenHeight;
        private static Point infoPosition = new Point(screenWidth - infoWidth, 0);
        private static Console infoConsole;


        //message console info
        private static readonly int messageWidth = screenWidth - infoWidth;
        private static readonly int messageHeight = 10;
        private static Point messagePosition = new Point(0, screenHeight - messageHeight);
        private static Console messageConsole;

        //map console info
        private static readonly int mapWidth = screenWidth - infoWidth;
        private static readonly int mapHeight = screenHeight -  messageHeight;
        private static Point mapPosition = new Point(0, 0);
        private static Console mapConsole;



        static void Main(string[] args)
        {
            
            
            // Setup the engine and creat the main window.
            SadConsole.Game.Create("Graphics/Fonts/IBM.font", screenWidth, screenWidth);

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

            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }
        }

        private static void Init()
        {
            // Set our new console as the thing to render and process
            defaultConsole = new Console(screenWidth, screenHeight);
            SadConsole.Global.CurrentScreen = defaultConsole;

            //Map Console
            mapConsole = new Console(mapWidth, mapHeight);
            mapConsole.Position = mapPosition;
            mapConsole.Fill(Color.White, Color.Pink, 0);
            mapConsole.Print(1, 1, "Map");
            SadConsole.Global.CurrentScreen.Children.Add(mapConsole);

            //Info Console
            infoConsole = new Console(infoWidth, infoHeight);
            infoConsole.Position = infoPosition;
            infoConsole.Fill(Color.White, Color.Orange, 0);
            infoConsole.Print(1, 1, "Stat");
            SadConsole.Global.CurrentScreen.Children.Add(infoConsole);

            //Message Console
            messageConsole = new Console(messageWidth, messageHeight);
            messageConsole.Position = messagePosition;
            messageConsole.Fill(Color.White, Color.Purple, 0);
            messageConsole.Print(1, 1, "Message");
            SadConsole.Global.CurrentScreen.Children.Add(messageConsole);
        }
    }
}
