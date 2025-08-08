using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Level.Configs
{
	[CreateAssetMenu(menuName = "Walker/Level Config", fileName = "LevelConfig")]
	public class LevelConfig : ScriptableObject
	{
		public LevelTypeId TypeId;
		[Range(0, 100)] public float HeroSaveZoneRadius;
		public List<EnemyWave> EnemyWaves;
	}
}