using System.Collections.Generic;
using Code.Gameplay.Features.Level.Configs;
using Entitas;

namespace Code.Gameplay.Features.Level
{
	[Game] public class LevelTypeIdComponent : IComponent { public LevelTypeId Value; }
	[Game] public class Level : IComponent { }

	[Game] public class EnemyWaves : IComponent { public List<EnemyWave> Value; }
	[Game] public class NextWaveIndex : IComponent { public int Value; }
	[Game] public class EnemyWaveComponent : IComponent { public EnemyWave Value; }
	[Game] public class SpawnedEnemyWaves : IComponent { public int Value; }
	[Game] public class EnemiesInWaveCount : IComponent { public int Value; }
	[Game] public class EnemiesInLevelCount : IComponent { public int Value; }

	[Game] public class HeroSafeZoneRadius : IComponent { public float Value; }

	[Game] public class HeroAbsent : IComponent { }
	[Game] public class EnemyAbsent : IComponent { }
}