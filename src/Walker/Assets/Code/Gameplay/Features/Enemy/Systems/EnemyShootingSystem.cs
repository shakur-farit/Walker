using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyShootingSystem : IExecuteSystem
	{
		private readonly List<GameEntity> _buffer = new(1);

		private readonly GameContext _game;
		private readonly IGroup<GameEntity> _enemies;
		private readonly IGroup<GameEntity> _heroes;

		public EnemyShootingSystem(GameContext game)
		{
			_game = game;
			_enemies = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Enemy,
					GameMatcher.WorldPosition,
					GameMatcher.ShootingRange));

			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.WorldPosition));
		}

		public void Execute()
		{
			foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
			foreach (GameEntity hero in _heroes)
				enemy.isShooting =
					Vector2.Distance(enemy.WorldPosition, hero.WorldPosition)
					< enemy.ShootingRange;
		}
	}
}