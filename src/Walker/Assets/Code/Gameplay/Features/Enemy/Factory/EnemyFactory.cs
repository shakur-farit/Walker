using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyFactory : IEnemyFactory
	{
		private readonly IIdentifierService _identifier;
		private readonly IStaticDataService _staticDataService;

		public EnemyFactory(IIdentifierService identifier, IStaticDataService staticDataService)
		{
			_identifier = identifier;
			_staticDataService = staticDataService;
		}

		public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
		{
			switch (typeId)
			{
				case EnemyTypeId.Orc:
					return CreateOrc(typeId, at);
				case EnemyTypeId.Hedusa:
					return CreateHedusa(typeId, at);
			}

			throw new Exception($"Enemy with type id {typeId} does not exist");
		}

		private GameEntity CreateOrc(EnemyTypeId typeId, Vector3 at) => 
			CreateEnemyEntity(typeId, at)
		;

		private GameEntity CreateHedusa(EnemyTypeId typeId, Vector3 at) =>
			CreateEnemyEntity(typeId, at);

		private GameEntity CreateEnemyEntity(EnemyTypeId typeId, Vector3 at)
		{
			EnemyConfig config = _staticDataService.GetEnemyConfig(typeId);

			Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
					.With(x => x[Stats.Speed] = config.MovementSpeed)
					.With(x => x[Stats.MaxHp] = config.MaxHp)
					.With(x => x[Stats.Damage] = config.Damage)
				;

			return CreateEntity.Empty()
					.AddId(_identifier.Next())
					.AddEnemyTypeId(typeId)
					.AddWorldPosition(at)
					.AddSpeed(baseStats[Stats.Speed])
					.AddCurrentHp(baseStats[Stats.MaxHp])
					.AddMaxHp(baseStats[Stats.MaxHp])
					.AddBaseStats(baseStats)
					.AddStatModifiers(InitStats.EmptyStatDictionary())
					.AddViewPrefab(config.ViewPrefab)
					.AddEnemyValue(config.Value)
					.AddMovementRange(config.MovementRange)
					.AddTargetsBuffer(new())
					.AddTargetLayerMask(CollisionLayer.Hero.AsMask())
					.AddRadius(config.AttackRange)
					.AddCollectTargetsInterval(config.AttackInterval)
					.AddCollectTargetsTimer(0f)
					.AddShootingRange(config.ShootingRange)
					.AddCooldown(config.ShootingInterval)
					.AddEffectSetups(new List<EffectSetup> { EffectSetup.FormId(EffectTypeId.Damage, baseStats[Stats.Damage]) })
					.With(x => x.isEnemy = true)
					.With(x => x.isMovementAvailable = true)
					.With(x => x.isLinerMovement = true)
					.With(x => x.isMoving = true)
					.PutOnCooldown()
				;
		}
	}
}