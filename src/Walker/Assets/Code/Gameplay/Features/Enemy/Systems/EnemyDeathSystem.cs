using System.Collections.Generic;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyDeathSystem : IExecuteSystem
	{
		private readonly List<GameEntity> _buffer = new(128);

		private readonly IGroup<GameEntity> _enemies;
		private readonly IGroup<GameEntity> _levels;

		public EnemyDeathSystem(GameContext game)
		{
			_enemies = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Enemy,
					GameMatcher.Dead,
					GameMatcher.ProcessingDeath));

			_levels = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.EnemiesInLevelCount));
		}

		public void Execute()
		{
			foreach (GameEntity level in _levels)
			foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
			{
				enemy.isMovementAvailable = false;
				enemy.RemoveTargetCollectionComponents();
				enemy.isDestructed = true;

				level.ReplaceEnemiesInWaveCount(level.EnemiesInWaveCount - 1);
				level.ReplaceEnemiesInLevelCount(level.EnemiesInLevelCount - 1);
			}
		}
	}
}