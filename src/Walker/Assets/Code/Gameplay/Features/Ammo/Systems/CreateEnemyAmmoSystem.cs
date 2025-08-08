using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.Features.Enemy;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class CreateEnemyAmmoSystem : IExecuteSystem
	{
		private readonly List<GameEntity> _buffer = new(1);
		private readonly IAmmoFactory _ammoFactory;
		private readonly IGroup<GameEntity> _enemies;
		private readonly IGroup<GameEntity> _heroes;

		public CreateEnemyAmmoSystem(GameContext game, IAmmoFactory ammoFactory)
		{
			_ammoFactory = ammoFactory;
			_enemies = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Enemy,
					GameMatcher.FirePositionPoint,
					GameMatcher.Shooting,
					GameMatcher.EffectSetups,
					GameMatcher.CooldownUp));

			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.WorldPosition));
		}

		public void Execute()
		{
			foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
			foreach (GameEntity hero in _heroes)
			{
				
				_ammoFactory.CreateAmmo(AmmoTypeId.EnemyAmmo, enemy.FirePositionPoint.position)
					.AddProducerId(enemy.Id)
					.AddEffectSetups(enemy.EffectSetups)
					.AddStartPosition(enemy.FirePositionPoint.position)
					.AddTargetPosition(hero.WorldPosition)
					.AddArcHeight(2f)
					.AddArcElapsedTime(0f)
					.With(x => x.isArcMovement = true)
					.With(x => x.isMoving = true);

				enemy.PutOnCooldown();
			}
		}
	}
}