using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SadConsole;
using SadConsole.Entities;
using SadConsole.Surfaces;
using Console = SadConsole.Console;
using CSharpRoguelike.Map.Tile;
using GoRogue.MapViews;

namespace CSharpRoguelike.CustomConsole
{
    

    class EntityConsole : Console
    {
        // The console here acts like a playing field for our entities. You could draw some sort of area for the
        // entity to walk around on. The console also gets focused with the keyboard and accepts keyboard events.
        public static EntityType.Player player;
        public  TileBase[] tileArray;
        private Basic borderSurface;
        

        public EntityConsole(int width, int height, int viewWidth, int viewHeight) : base(width, height, SadConsole.Global.FontDefault, new Rectangle(0,0, width, height))
        {
            UseKeyboard = true;
            IsVisible = true;
            ViewPort = new Rectangle(Position.X, Position.Y, viewWidth, viewHeight);

            //draw border
            borderSurface = new Basic(viewWidth + 2, viewHeight + 2, base.Font);
            borderSurface.DrawBox(new Rectangle(0, 0, borderSurface.Width, borderSurface.Height), new Cell(Color.White, Color.Black), null, SurfaceBase.ConnectedLineThin);
            borderSurface.Position = new Point(-1, -1);
            Children.Add(borderSurface);

            //tile array holds all tile info and receives mapgen's converted output
            CreateTileArray(width, height);

            //create player instance
            CreatePlayer();
            
            //create entity manager
            EntityManager manager = new EntityManager();
            manager.Entities.Add(player);
            Children.Add(manager);

        }


        public void SetCellsToTileArray()
        {
            //assign tile array to console cells
            Cells = tileArray;
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
            player.Position = new Point(1, 1);
            player.PreviousPosition = player.Position;
        }

        private void CreateTileArray(int width, int height)
        {
            //create tile array
            tileArray = new TileBase[width * height];
        }
    }
}