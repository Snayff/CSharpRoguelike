using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SadConsole;
using SadConsole.Entities;
using SadConsole.Surfaces;
using Console = SadConsole.Console;
using CSharpRoguelike.Map.Tile;


namespace CSharpRoguelike.CustomConsole
{
    

    class EntityConsole : Console
    {
        // The console here acts like a playing field for our entities. You could draw some sort of area for the
        // entity to walk around on. The console also gets focused with the keyboard and accepts keyboard events.
        public static EntityType.Player player;
        public static TileBase[] tileArray;
        private Basic borderSurface;
        

        public EntityConsole(int width, int height, int viewWidth, int viewHeight, TileBase[] tileArray) : base(width, height, SadConsole.Global.FontDefault, new Rectangle(0,0, width, height), tileArray)
        {

            

            UseKeyboard = true;
            IsVisible = true;
            ViewPort = new Rectangle(Position.X, Position.Y, viewWidth, viewHeight);

            //draw border
            borderSurface = new Basic(viewWidth + 2, viewHeight + 2, base.Font);
            borderSurface.DrawBox(new Rectangle(0, 0, borderSurface.Width, borderSurface.Height), new Cell(Color.White, Color.Black), null, SurfaceBase.ConnectedLineThin);
            borderSurface.Position = new Point(-1, -1);

            Children.Add(borderSurface);

            //create player instance
            CreatePlayer();

            //create entity manager
            EntityManager manager = new EntityManager();
            manager.Entities.Add(player);
            Children.Add(manager); 

        }

        

        public bool IsTileWalkable(Point newPoint)
        {
            int x = newPoint.X;
            int y = newPoint.Y;

            //check if target point is within map bounds
            if (x < 0 || y < 0 || x > Width || y > Height )
            {
                return false;
            }
            else
            {
                //check if target tile blocks movement
                return !tileArray[GoRogue.Coord.ToIndex(x, y, Width)].IsBlockingMove;
            }

        }

        private static void CreatePlayer()
        {
            player = new EntityType.Player();
            player.Position = new Point(1,1); //should this be in player class params?
            player.PreviousPosition = player.Position;
        }

        private static void CreateTileArray(int width, int height)
        {
            //create tile array
            tileArray = new TileBase[width * height];
        }
    }
}