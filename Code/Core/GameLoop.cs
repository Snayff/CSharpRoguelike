using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using CSharpRoguelike.CustomConsole;
using GoRogue.MapViews;


namespace CSharpRoguelike
{
    class GameLoop
    {

        //All sizes are in cells. Cell size is based on font dimensions/size. 
        //window info
        private static readonly int screenWidth = 200;
        private static readonly int screenHeight = 70;

        //border info
        private static readonly int borderSize = 1;

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
        private static readonly int viewportWidth = screenWidth - infoWidth - (borderSize * 2);
        private static readonly int viewportHeight = screenHeight -  messageHeight - (borderSize * 2 );
        private static readonly int mapWidth = viewportWidth + 20; 
        private static readonly int mapHeight = viewportHeight  + 20; 
        private static Point mapPosition = new Point(0 + borderSize, 0 + borderSize);
        public static EntityConsole mapConsole;

        //RNG seed
        private static readonly int seed = 123456789; //set the game seed

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
            //check for input
            if (Input.InputController.CheckKeyboard())
            {
                Input.InputController.ProcessInput();
            }
        }

        private static void Init()
        {
            //set seed for RNG
            GoRogue.Random.SingletonRandom.DefaultRNG = new Troschuetz.Random.Generators.XorShift128Generator(seed);

            // Set our new console as the thing to render and process
            Global.CurrentScreen = new ScreenObject();

            //map Console
            mapConsole = new EntityConsole(mapWidth, mapHeight, viewportWidth, viewportHeight);
            mapConsole.Position = mapPosition;
            Global.CurrentScreen.Children.Add(mapConsole);
            Global.FocusedConsoles.Set(mapConsole);

            //create the map and update the tileArray with Tile values
            Map.Generation.MapGeneration.CreateMap(mapWidth, mapHeight, 20, 7, 22, 10);
            mapConsole.SetCellsToTileArray();

            //move the player to a valid position
            var validPosition = Map.Generation.MapGeneration.mapData.RandomPosition(true);
            mapConsole.player.Position = new Point(validPosition.X, validPosition.Y);

            //Info Console
            infoConsole = new Console(infoWidth, infoHeight);
            infoConsole.Position = infoPosition;
            infoConsole.Fill(Color.White, Color.Orange, 0);
            infoConsole.Print(1, 1, "Info");
            Global.CurrentScreen.Children.Add(infoConsole);

            //Message Console
            messageConsole = new Window(messageWidth, messageHeight);
            messageConsole.Position = messagePosition;
            messageConsole.Fill(Color.White, Color.Purple, 0);
            messageConsole.Print(1, 1, "Message");
            Global.CurrentScreen.Children.Add(messageConsole);
            messageConsole.Show(); //as its a window need to declare its visible

            //centre view on player
            mapConsole.CenterViewPortOnPoint(mapConsole.player.Position);
        }
    }
}
