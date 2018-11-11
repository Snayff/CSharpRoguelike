using Microsoft.Xna.Framework;
using GoRogue.MapViews;

namespace CSharpRoguelike.Controller
{
    public class EntityController
    {

        public EntityType.Player Player;
        
        public EntityController()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            Player = new EntityType.Player();
            ScreenController.MapConsole.EntityManager.Entities.Add(Player);
            Player.Position = new Point(1, 1);
            Player.PreviousPosition = Player.Position;
        }

        public void MovePlayerToValidPosition()
        {
            //move the player to a valid position
            var validPosition = ControllerContainer.MapController.MapData.RandomPosition(true);
            Player.Position = new Point(validPosition.X, validPosition.Y);
        }

    }
}
