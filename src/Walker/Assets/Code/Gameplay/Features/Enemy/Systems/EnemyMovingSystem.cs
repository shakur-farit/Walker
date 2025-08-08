using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyMovingSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _enemies;
		private readonly IGroup<GameEntity> _heroes;

		public EnemyMovingSystem(GameContext game)
		{
			_enemies = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Enemy,
					GameMatcher.MovementRange,
					GameMatcher.WorldPosition));

			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.WorldPosition));

		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes)
			foreach (GameEntity enemy in _enemies)
			{
				Vector3 direction = (hero.WorldPosition - enemy.WorldPosition).normalized;

				enemy.ReplaceDirection(direction);

				float distance = Vector2.Distance(enemy.WorldPosition, hero.WorldPosition);

				enemy.isMoving = (distance < 2) == false && distance < enemy.MovementRange;
			}
		}
	}
}