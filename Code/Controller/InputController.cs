using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CSharpRoguelike;



namespace CSharpRoguelike.Controller
{
    public class InputController
    {

        //if (Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
        //{
        //    SadConsole.Settings.ToggleFullScreen();
        //}
        private bool inpUp;
        private bool inpDown;
        private bool inpLeft;
        private bool inpRight;

        public bool CheckKeyboard()
        {
            bool keyHit = false;
            var input = SadConsole.Global.KeyboardState;
            inpUp = false;
            inpDown = false;
            inpLeft = false;
            inpRight = false;

            //convert input into consolidated variables
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
    

        public void ProcessInput() 
        {
            
            //Movement
            if (inpUp)
            {
                //check if entity can move to the new location
                if (ControllerManager.entityController.player.CheckTargetLocationIsValid(new Point(0, -1)))
                {
                    ControllerManager.entityController.player.Move(new Point(0, -1));
                }
            }
            else if (inpDown)
            {
                if (ControllerManager.entityController.player.CheckTargetLocationIsValid(new Point(0, 1)))
                {
                    ControllerManager.entityController.player.Move(new Point(0, 1));
                }
            }

            if (inpLeft)
            {
                if (ControllerManager.entityController.player.CheckTargetLocationIsValid(new Point(-1, 0)))
                {
                    ControllerManager.entityController.player.Move(new Point(-1, 0));
                }
               
            }
            else if (inpRight)
            {
                if (ControllerManager.entityController.player.CheckTargetLocationIsValid(new Point(1, 0)))
                {
                    ControllerManager.entityController.player.Move(new Point(1, 0));
                }
               
            }
        }
    }
}
