using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SadConsole;
using Console = SadConsole.Console;
using SadConsole.Entities;
using SadConsole.Surfaces;
using GoRogue.MapViews;

namespace CSharpRoguelike.CustomConsole
{
    class EntityConsole : Console
    {
        // The console here acts like a playing field for our entities. You could draw some sort of area for the
        // entity to walk around on. The console also gets focused with the keyboard and accepts keyboard events.
        public static EntityType.Player player;
        private Basic borderSurface;

        public EntityConsole(int width, int height, int viewWidth, int viewHeight) : base(width, height)
        {
            Width = width;
            Height = height;
            UseKeyboard = true;
            IsVisible = true;
            Fill(Color.White, Color.Black, 0);
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

        public override bool ProcessKeyboard(SadConsole.Input.Keyboard info)
        {
            // Forward the keyboard data to the entity to handle the movement code.
            // By not setting the entity as the active object, we let this
            // "game level" (the console we're hosting the entity on) determine if
            // the keyboard data should be sent to the entity.

            // Process logic for moving the entity.
            bool keyHit = false;
            var oldPosition = player.Position;

            if (info.IsKeyPressed(Keys.Up))
            {
                player.MoveBy(new Point(0,-1));
                keyHit = true;
            }
            else if (info.IsKeyPressed(Keys.Down))
            {
                player.MoveBy(new Point(0, 1));
                keyHit = true;
            }

            if (info.IsKeyPressed(Keys.Left))
            {
                player.MoveBy(new Point(-1,0));
                keyHit = true;
            }
            else if (info.IsKeyPressed(Keys.Right))
            {
                player.MoveBy(new Point(1, 0));
                keyHit = true;
            }


            if (keyHit)
            {
                // Check if the new position is valid
                if (ViewPort.Contains(player.Position))
                {
                    // Entity moved. Let's draw a trail of where they moved from.
                    SetGlyph(player.PreviousPosition.X, player.PreviousPosition.Y, 250);
                    player.PreviousPosition = player.Position;

                    return true;
                }
                else  // New position was not in the area of the console, move back
                    player.Position = oldPosition;
            }

            return false;
        }

        private static void CreatePlayer()
        {
            player = new EntityType.Player();
            player.Position = new Point(1,1);
            //new Point(0, 0); //should this be in player class params?
            player.PreviousPosition = player.Position;
        }
    }
}