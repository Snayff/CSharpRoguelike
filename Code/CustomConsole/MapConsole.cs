using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SadConsole;
using SadConsole.Entities;
using SadConsole.Surfaces;
using Console = SadConsole.Console;
using CSharpRoguelike.Controller;
using System;

namespace CSharpRoguelike.CustomConsole
{

    public class MapConsole : Console
    {
        // The console here acts like a playing field for our entities. You could draw some sort of area for the
        // entity to walk around on. The console also gets focused with the keyboard and accepts keyboard events.

        private Basic borderSurface;
        public EntityManager EntityManager = new EntityManager();


        public MapConsole(int width, int height, int viewWidth, int viewHeight) : base(width, height, FontController.MapFontMaster.GetFont(Font.FontSizes.One), new Rectangle(0, 0, width, height))
        {
            UseKeyboard = true;
            IsVisible = true;
            ViewPort = new Rectangle(Position.X, Position.Y, viewWidth, viewHeight);

            //draw border
            borderSurface = new Basic(viewWidth + 2, viewHeight + 2, FontController.BorderFontMaster.GetFont(Font.FontSizes.One));
            borderSurface.DrawBox(new Rectangle(0, 0, borderSurface.Width, borderSurface.Height), new Cell(Colour.BorderColour, Color.Black), null, SurfaceBase.ConnectedLineThick);
            borderSurface.Position = new Point(-1, -1); //offset to draw AROUND the console
            Children.Add(borderSurface);

            //create entity manager
            Children.Add(EntityManager);

        }


        public void UpdateCellsToCellArray()
        {
            ControllerContainer.MapController.ConvertTileArrayToCellArray();

            //assign tile array to console cells
            Cells = ControllerContainer.MapController.CellArray;
        }


        public override void Update(TimeSpan delta)
        {
            //check for input
            if (ControllerContainer.InputController.CheckKeyboard())
            {
                ControllerContainer.InputController.ProcessInput();
                ScreenController.MapConsole.CenterViewPortOnPoint(ControllerContainer.EntityController.Player.Position);
                ControllerContainer.MapController.RefreshFov();
                ControllerContainer.MapController.UpdateTileDrawInfo();
            }

            base.Update(delta);
        }
    }
}