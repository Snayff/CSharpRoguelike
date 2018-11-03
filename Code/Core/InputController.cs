using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using CSharpRoguelike.CustomConsole;


namespace CSharpRoguelike.InputController
{
    public class InputController
    {

        //if (Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
        //{
        //    SadConsole.Settings.ToggleFullScreen();
        //}
        static private bool inpUp;
        static private bool inpDown;
        static private bool inpLeft;
        static private bool inpRight;

        public static bool CheckKeyboard()
        {
            bool keyHit = false;
            var input = SadConsole.Global.KeyboardState;
            inpUp = false;
            inpDown = false;
            inpLeft = false;
            inpRight = false;


            if ( input.IsKeyPressed(Keys.Up))
            {
                inpUp = true;
                keyHit = true;
            }
            else if (input.IsKeyPressed(Keys.Down))
            {
                inpDown = true;
                keyHit = true;
            }

            if (input.IsKeyPressed(Keys.Left))
            {
                EntityConsole.player.Move(new Point(-1, 0));
                keyHit = true;
            }
            else if (input.IsKeyPressed(Keys.Right))
            {
                EntityConsole.player.Move(new Point(1, 0));
                keyHit = true;
            }


            if (keyHit)
            {
                //// Check if the new position is valid
                //if (ViewPort.Contains(EntityConsole.player.Position))
                //{
                //    EntityConsole.player.PreviousPosition = EntityConsole.player.Position;
                //    GameLoop.mapConsole.CenterViewPortOnPoint(EntityConsole.player.Position);

                return true;
            }
            else  // New position was not in the area of the console, move back
            {
                //EntityConsole.player.Position = oldPosition;
                return false;
            }
        }   
    

        private void ProcessKeyboard()
        {
            var oldPosition = EntityConsole.player.Position;

            if (inpUp)
            {
                EntityConsole.player.Move(new Point(0, -1));
            }
            else if (inpDown)
            {
                EntityConsole.player.Move(new Point(0, 1));
            }

            if (inpLeft)
            {
                EntityConsole.player.Move(new Point(-1, 0));
            }
            else if (inpRight)
            {
                EntityConsole.player.Move(new Point(1, 0));
            }
        }
    }
}
