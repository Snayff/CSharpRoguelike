﻿using SadConsole;



namespace CSharpRoguelike.Map.Tile
{
    //Tilebase inherits from SadConsole.Cell which is a class that all surfaces use in rendering
    public class TileBase : Cell
    {
        public bool IsBlockingMove;
        public bool IsBlockingSight;
        public string Name;

        public TileBase() : base()
        {

        }
    }




} 