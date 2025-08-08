using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
	public class HeroFactory : IHeroFactory
	{
		private readonly IIdentifierService _identifier;
		private readonly IStaticDataService _staticDataService;

		public HeroFactory(IIdentifierService identifier, IStaticDataService staticDataService)
		{
			_identifier = identifier;
			_staticDataService = staticDataService;
		}

		public GameEntity CreateHero(HeroTypeId typeId, Vector3 at)
		{
			switch (typeId)
			{
				case HeroTypeId.TheGeneral:
					return CreateTheGeneral(typeId, at);
			}

			throw new Exception($"Hero with type id {typeId} does not exist");
		}

		private GameEntity CreateTheGeneral(HeroTypeId typeId, Vector3 at)
		{
			return CreateHeroEntity(typeId, at);
		}

		private GameEntity CreateHeroEntity(HeroTypeId typeId, Vector3 at)
		{
			HeroConfig config = _staticDataService.GetHeroConfig(typeId);
			
			Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
					.With(x => x[Stats.Speed] = config.MovementSpeed)
					.With(x => x[Stats.MaxHp] = config.MaxHp)
					.With(x => x[Stats.Damage] = config.Damage)
				;

			return CreateEntity.Empty()
					.AddId(_identifier.Next())
					.AddHeroTypeId(typeId)
					.AddWorldPosition(at)
					.AddSpeed(baseStats[Stats.Speed])
					.AddCurrentHp(baseStats[Stats.MaxHp])
					.AddMaxHp(baseStats[Stats.MaxHp])
					.AddDamage(baseStats[Stats.Damage])
					.AddBaseStats(baseStats)
					.AddStatModifiers(InitStats.EmptyStatDictionary())
					.AddViewPrefab(config.ViewPrefab)
					.AddTargetsBuffer(new())
					.AddTargetLayerMask(CollisionLayer.Enemy.AsMask())
					.AddRadius(config.AttackRange)
					.AddCooldown(config.AttackCooldown)
					.AddCoins(0)
					.With(x => x.isHero = true)
					.With(x => x.isMovementAvailable = true)
					.With(x => x.isLinerMovement = true)
					.With(x => x.isMoving = true)
					.With(x => x.isReadyToCollectTargets = true)
					.With(x => x.isCollectTargetsContinuously = true)
					.PutOnCooldown()
				;
		}
	}
}