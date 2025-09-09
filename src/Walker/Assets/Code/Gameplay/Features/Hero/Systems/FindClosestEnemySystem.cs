using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class FindClosestEnemySystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _heroes;
		private readonly IGroup<GameEntity> _enemies;

		public FindClosestEnemySystem(GameContext game)
		{
			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.WorldPosition));

			_enemies = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Enemy,
					GameMatcher.WorldPosition));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes)
			{
				float closestDistance = float.MaxValue;

				foreach (GameEntity enemy in _enemies)
				{
					float distance = (enemy.WorldPosition - hero.WorldPosition).magnitude;

					if (distance < closestDistance)
					{
						closestDistance = distance;
						hero.ReplaceClosestEnemyPosition(enemy.WorldPosition);
					}
				}
			}
		}
	}
}