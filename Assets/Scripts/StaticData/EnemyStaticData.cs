using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Enemy Static Data", menuName = "Scriptable Objects/Static Data/Enemy")]
	public class EnemyStaticData : ScriptableObject
	{
		public int StartHealth;
		public float Speed;
		public float CharcterDetectRange;
	}
}