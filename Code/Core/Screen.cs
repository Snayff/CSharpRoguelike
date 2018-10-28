using Microsoft.Xna.Framework;
using SadConsole.Renderers;
using SadConsole.Surfaces;
using System;
using CSharpRoguelike.Map;

namespace CSharpRoguelike.Screen
{
    class Dungeon : SadConsole.ScreenObject
    {
        private SadConsole.Renderers.Basic renderer = new SadConsole.Renderers.Basic();
        private SadConsole.Surfaces.Basic surface;
        private SadConsole.DrawCalls.DrawCallSurface drawCall;
        private Point position;

        //public Point MapViewPoint { get { return surface.RenderArea.Location; } set { surface.RenderArea = new Rectangle(value, new Point(Width, Height)); } }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Dungeon(int screenX, int screenY, int screenWidth, int screenHeight)
        {
            Position = new Point(screenX, screenY);
            Width = screenWidth;
            Height = screenHeight;
        }

        public void LoadMap(MapBase map)
        {
            // Create a surface for drawing. It uses the tiles from a map object.
            //surface = new SadConsole.Surfaces.Basic(map.Width, map.Height, map.Tiles, SadConsole.Global.FontDefault, new Rectangle(0, 0, Width, Height));
            //drawCall = new SadConsole.DrawCalls.DrawCallSurface(surface, position, false);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            renderer.Render(surface);
            SadConsole.Global.DrawCalls.Add(drawCall);

            base.Draw(timeElapsed);
        }
    }
}

