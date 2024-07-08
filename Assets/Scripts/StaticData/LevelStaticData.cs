using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Level Static Data", menuName = "Scriptable Objects/Static Data/Level")]
	public class LevelStaticData : ScriptableObject
	{
		[Range(1, 100)] public int EnemiesCountOnLevel;
		public float MinXPositionToEnemySpawn;
		public float MaxXPositionToEnemySpawn;
		public float MinYPositionToEnemySpawn;
		public float MaxYPositionToEnemySpawn;
	}
}