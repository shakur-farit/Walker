using System.Collections.Generic;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Level.Configs;
using Entitas;
using ModestTree;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	public class CreateEnemySystem : IExecuteSystem
	{
		private readonly List<GameEntity> _buffer = new(1);
		private readonly List<GameEntity> _heroBuffer = new(1);

		private readonly IEnemyFactory _enemyFactory;
		private readonly IRandomService _random;
		private readonly IGroup<GameEntity> _levels;
		private readonly IGroup<GameEntity> _heroes;

		public CreateEnemySystem(GameContext game, IEnemyFactory enemyFactory, IRandomService random)
		{
			_enemyFactory = enemyFactory;
			_random = random;
			_levels = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Level,
					GameMatcher.EnemyWaves,
					GameMatcher.NextWaveIndex,
					GameMatcher.EnemyAbsent)
				.NoneOf(GameMatcher.Processed));
			
			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.WorldPosition));
		}

		public void Execute()
		{
			foreach (GameEntity level in _levels.GetEntities(_buffer))
			foreach (GameEntity hero in _heroes.GetEntities(_heroBuffer))
			{
				foreach (EnemiesInWave enemiesInWave in level.EnemyWaves[level.NextWaveIndex].EnemiesInWave)
				{
					for (int i = 0; i < enemiesInWave.Amount; i++)
					{
						_enemyFactory.CreateEnemy(enemiesInWave.EnemyTypeId,
							GetSpawnPosition(hero.WorldPosition, level.HeroSafeZoneRadius));
						level.ReplaceEnemiesInWaveCount(level.EnemiesInWaveCount + 1);
					}
				}

				level.isEnemyAbsent = false;
			}
		}

		private Vector2 GetSpawnPosition(Vector3 heroPosition, float safeZone)
		{
			float offset = _random.Range(-2f, 2f);

			return new Vector2(heroPosition.x + safeZone + offset, heroPosition.y + offset);
		}
	}
}