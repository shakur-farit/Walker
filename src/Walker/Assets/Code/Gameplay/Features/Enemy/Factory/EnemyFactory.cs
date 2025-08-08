using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
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
			}

			throw new Exception($"Enemy with type id {typeId} does not exist");
		}

		private GameEntity CreateOrc(EnemyTypeId typeId, Vector3 at)
		{
			return CreateEnemyEntity(typeId, at);
		}

		private GameEntity CreateEnemyEntity(EnemyTypeId typeId, Vector3 at)
		{
			EnemyConfig config = _staticDataService.GetEnemyConfig(typeId);

			Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
					.With(x => x[Stats.Speed] = config.MovementSpeed)
					.With(x => x[Stats.MaxHp] = config.MaxHp)
				;

			return CreateEntity.Empty()
					.AddId(_identifier.Next())
					.AddEnemyTypeId(typeId)
					.AddWorldPosition(at)
					.AddSpeed(baseStats[Stats.Speed])
					.AddCurrentHp(baseStats[Stats.MaxHp])
					.AddMaxHp(baseStats[Stats.MaxHp])
					.AddEffectSetups(config.EffectSetups)
					.AddBaseStats(baseStats)
					.AddStatModifiers(InitStats.EmptyStatDictionary())
					.AddViewPrefab(config.ViewPrefab)
					.With(x => x.isEnemy = true)
				;
		}
	}
}