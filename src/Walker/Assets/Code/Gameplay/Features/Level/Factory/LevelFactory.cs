using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Level.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Level.Factory
{
	public class LevelFactory : ILevelFactory
	{
		private const int StartingEnemyWavesCount = 0;

		private readonly IIdentifierService _identifier;
		private readonly IStaticDataService _staticDataService;

		public LevelFactory(
			IIdentifierService identifier, 
			IStaticDataService staticDataService)
		{
			_identifier = identifier;
			_staticDataService = staticDataService;
		}

		public GameEntity CreateLevel(int level)
		{
			if (Enum.IsDefined(typeof(LevelTypeId), level))
			{
				LevelTypeId typeId = (LevelTypeId)level;
				LevelConfig config = _staticDataService.GetLevelConfig(typeId);

				return CreateEntity.Empty()
						.AddId(_identifier.Next())
						.AddLevelTypeId(typeId)
						.AddEnemyWaves(config.EnemyWaves)
						.AddNextWaveIndex(0)
						.AddSpawnedEnemyWaves(StartingEnemyWavesCount)
						.AddEnemiesInWaveCount(StartingEnemyWavesCount)
						.AddEnemiesInLevelCount(EnemiesOnLevel(config.EnemyWaves))
						.AddHeroSafeZoneRadius(config.HeroSaveZoneRadius)
						.With(x => x.isLevel = true)
						.With(x => x.isHeroAbsent = true)
						.With(x => x.isEnemyAbsent = true)
					;
			}

			throw new Exception($"Level with type id {level} does not exist");
		}

		private int EnemiesOnLevel(List<EnemyWave> waves)
		{
			int count = 0;

			foreach (EnemyWave wave in waves)
			foreach (EnemiesInWave enemiesInWave in wave.EnemiesInWave)
				count += enemiesInWave.Amount;

			return count;
		}
	}
}