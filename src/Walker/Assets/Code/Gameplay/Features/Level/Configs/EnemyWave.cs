using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Enemy;
using UnityEngine;

namespace Code.Gameplay.Features.Level.Configs
{
	[Serializable]
	public class EnemyWave
	{
		public List<EnemiesInWave> EnemiesInWave;
	}

	[Serializable]
	public class EnemiesInWave
	{
		public EnemyTypeId EnemyTypeId;
		[Range(0, 100)] public int Amount;
	}
}