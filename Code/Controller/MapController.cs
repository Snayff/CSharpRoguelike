using System;
using Microsoft.Xna.Framework;
using CSharpRoguelike.Map.Tile;
using GoRogue;
using GoRogue.MapViews;

namespace CSharpRoguelike.Controller
{
    public class MapController
    {
        public TileBase[,] TileArray;
        public TileBase[] CellArray;
        public ArrayMap<bool> MapData;
        public int MapWidth = 250;
        public int MapHeight = 250;

        private FOV fov;

        public MapController()
        {
            CreateTileArray(MapWidth, MapHeight);
            CreateCellArray(MapWidth, MapHeight);
            CreateMapData(MapWidth, MapHeight);
            CreateFov();
        }


        private void CreateMapData(int width, int height)
        {
            //create mapview
            MapData = new ArrayMap<bool>(width, height);
        }


        private void CreateTileArray(int width, int height)
        {
            ///tile array holds all tile info and receives mapgen's converted output
            
            //create tile array
            TileArray = new TileBase[width, height];
        }

        private void CreateCellArray(int width, int height)
        {
            ///cellArray holds the cell info to be passed to the console
            
            //create the 1d cell array 
            CellArray = new TileBase[width * height];
        }

        private void CreateFov()
        {
            //create the player fov
            fov = new FOV(MapData);
            
        }



        public void RefreshFov()
        {
            /// take MapData and check latest Fov info

            var player = ControllerContainer.EntityController.Player;
            Coord playerCoord = Coord.Get(player.Position.X, player.Position.Y);
            int visionRange = 6; //***update to take from player stat

            fov.Calculate(playerCoord, visionRange);

            UpdateTilesToReflectFov();
        }

        public bool IsTileWalkable(Point newPoint)
        {
            ///check if a tile can receive an entity

            int x = newPoint.X;
            int y = newPoint.Y;

            //check if target point is within array bounds
            if (x < 0 || y < 0 || x > TileArray.GetLength(0) || y > TileArray.GetLength(1))
            {
                return false;
            }
            else
            {
                //check if target tile blocks movement
                return !TileArray[x,y].IsBlockingMove;
            }

        }

        public void ConvertTileArrayToCellArray()
        {
            ///console requires 1d array so convert TileArray[,] to CellArray[]

            int width = TileArray.GetLength(0);
            int height = TileArray.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    CellArray[Coord.ToIndex(x,y,width)] = TileArray[x,y];
                }
            }
        }

        private void UpdateTilesToReflectFov()
        {
            ///update TileArray to incorporate Fov info

            int width = TileArray.GetLength(0);
            int height = TileArray.GetLength(1);

            //check recently seen / unseen cells and update Tile info
            //foreach (Coord newlySeenPos in fov.NewlySeen)
            //{
            //    TileArray[newlySeenPos.X, newlySeenPos.Y].IsInView = true;
            //    TileArray[newlySeenPos.X, newlySeenPos.Y].HasBeenSeen = true;
            //}

            //foreach (Coord newlyHiddenPos in fov.NewlyUnseen)
            //{
            //    TileArray[newlyHiddenPos.X, newlyHiddenPos.Y].IsInView = false;

            //}
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (fov.BooleanFOV[x, y])
                    {
                        TileArray[x, y].IsInView = true;
                        TileArray[x, y].HasBeenSeen = true;
                    }
                    else
                    {
                        TileArray[x, y].IsInView = false;
                    }

                }
            }
        }

        public void UpdateTileDrawInfo()
        {
            ///update tile info to reflect what needs to be drawn

            int width = TileArray.GetLength(0);
            int height = TileArray.GetLength(1);
            int minRadius = 3; //*** update to pull from player stats
            int maxRadius = 6; //*** update to pull from player stats (visionRange)
            double  minRadiusPercent = minRadius / maxRadius;
            byte minAlphaValue = 80;

            minRadiusPercent = Convert.ToDouble(minRadius) / maxRadius;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //we can see it so show as normal
                    if (TileArray[x,y].IsInView)
                    {
                        TileArray[x, y].IsVisible = true; //indicates to console that tile should be drawn

                        //distance to target is more than half radius so start scaling alpha
                        if (fov[x, y] <= minRadiusPercent)
                        {
                            TileArray[x, y].Foreground.A = Math.Max(Convert.ToByte((fov[x, y] * 2) * 255), minAlphaValue); //scales with distance from player - fov[x,y] returns a double with 1 being start position and 0 beingn unseen
                        }
                        else
                        {
                            TileArray[x, y].Foreground.A = 255;
                        }

                                       
                    }
                    else if (TileArray[x, y].HasBeenSeen) 
                    {
                        //we have seen it so show as faded

                        TileArray[x, y].IsVisible = true;
                        TileArray[x, y].Foreground.A = minAlphaValue;
                    } 
                    else 
                    {
                        //we have never seen it so dont draw at all
                        TileArray[x, y].IsVisible = false;
                    }


                }
            }
        }


    }
}

