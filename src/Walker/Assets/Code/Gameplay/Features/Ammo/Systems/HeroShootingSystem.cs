using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enemy;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class HeroShootingSystem : IExecuteSystem
	{
		private readonly IAmmoFactory _ammoFactory;
		private readonly IGroup<GameEntity> _heroes;
		private readonly List<GameEntity> _buffer = new(1);

		public HeroShootingSystem(GameContext game, IAmmoFactory ammoFactory)
		{
			_ammoFactory = ammoFactory;
			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.FirePositionPoint,
					GameMatcher.Shooting,
					GameMatcher.WeaponRotationPoint,
					GameMatcher.CooldownUp));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes.GetEntities(_buffer))
			{
				_ammoFactory.CreateAmmo(AmmoTypeId.HeroAmmo, hero.FirePositionPoint.position)
					.AddProducerId(hero.Id)
					.AddDirection(hero.WeaponRotationPoint.right)
					.AddEffectSetups(new(){EffectSetup.FormId(EffectTypeId.Damage, hero.Damage)})
					.With(x => x.isMoving = true);

				hero.PutOnCooldown();
			}
		}
	}
}