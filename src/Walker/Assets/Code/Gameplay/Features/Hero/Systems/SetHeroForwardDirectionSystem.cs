using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class SetHeroForwardDirectionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _heroes;

		public SetHeroForwardDirectionSystem(GameContext game, InputContext input)
		{
			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.MovementAvailable));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes) 
				hero.ReplaceDirection(Vector2.right);
		}
	}
}