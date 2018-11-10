using Microsoft.Xna.Framework;
using GoRogue.MapViews;

namespace CSharpRoguelike.Controller
{
    public class EntityController
    {

        public EntityType.Player player;
        
        public EntityController()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            player = new EntityType.Player();
            ScreenController.mapConsole.manager.Entities.Add(player);
            player.Position = new Point(1, 1);
            player.PreviousPosition = player.Position;
        }

        public void MovePlayerToValidPosition()
        {
            //move the player to a valid position
            var validPosition = ControllerManager.mapController.mapData.RandomPosition(true);
            player.Position = new Point(validPosition.X, validPosition.Y);
        }

    }
}
