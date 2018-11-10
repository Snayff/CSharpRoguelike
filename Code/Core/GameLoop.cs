using SadConsole;
using Microsoft.Xna.Framework;
using CSharpRoguelike.Controller;

namespace CSharpRoguelike
{
    class GameLoop
    {

        //RNG seed
        private static readonly int seed = 123456789; //set the game seed

        static void Main(string[] args)
        {
            
            
            // Setup the engine and creat the main window.
            SadConsole.Game.Create("Graphics/Fonts/IBM.font", ScreenController.screenWidth, ScreenController.screenHeight);

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
            if (ControllerManager.inputController.CheckKeyboard())
            {
                ControllerManager.inputController.ProcessInput();
                //ScreenController.mapConsole.CenterViewPortOnPoint(ControllerManager.entityController.player.Position);
            }
        }

        private static void Init()
        {
            //set seed for RNG
            GoRogue.Random.SingletonRandom.DefaultRNG = new Troschuetz.Random.Generators.XorShift128Generator(seed);

            //create controllers
            ControllerManager controllerManager = new ControllerManager();


            //create map
            Map.MapGeneration.CreateMap(ControllerManager.mapController.mapWidth, ControllerManager.mapController.mapHeight, 20, 7, 22, 10); //updates mapData and tileArray
            ControllerManager.entityController.MovePlayerToValidPosition();
            ScreenController.mapConsole.CenterViewPortOnPoint(ControllerManager.entityController.player.Position);

            //update tile info on map
            ScreenController.mapConsole.UpdateCellsToCellArray(); //move the cell data into the console
            ScreenController.mapConsole.CenterViewPortOnPoint(ControllerManager.entityController.player.Position);
        }
    }
}
