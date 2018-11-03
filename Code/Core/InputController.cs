using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace CSharpRoguelike.Input
{
    public static class InputController
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
                inpLeft = true;
                keyHit = true;
            }
            else if (input.IsKeyPressed(Keys.Right))
            {
                inpRight = true;
                keyHit = true;
            }


            //was something pressed?
            if (keyHit)
            {
                return true;
            }
            else  
            {

                return false;
            }
        }   
    

        public static void ProcessInput() 
        {
            
            //Movement
            if (inpUp)
            {
                //chck if 
                if (GameLoop.mapConsole.player.CheckTargetLocationIsValid(new Point(0, -1)))
                {
                    GameLoop.mapConsole.player.Move(new Point(0, -1));
                }
            }
            else if (inpDown)
            {
                if (GameLoop.mapConsole.player.CheckTargetLocationIsValid(new Point(0, 1)))
                {
                    GameLoop.mapConsole.player.Move(new Point(0, 1));
                }
            }

            if (inpLeft)
            {
                if (GameLoop.mapConsole.player.CheckTargetLocationIsValid(new Point(-1, 0)))
                {
                    GameLoop.mapConsole.player.Move(new Point(-1, 0));
                }
               
            }
            else if (inpRight)
            {
                if (GameLoop.mapConsole.player.CheckTargetLocationIsValid(new Point(1, 0)))
                {
                    GameLoop.mapConsole.player.Move(new Point(1, 0));
                }
               
            }
        }
    }
}
