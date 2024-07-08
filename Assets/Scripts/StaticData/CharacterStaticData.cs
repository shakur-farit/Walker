using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Character Static Data", menuName = "Scriptable Objects/Static Data/Character")]
	public class CharacterStaticData : ScriptableObject
	{
		public int StartHealth;
		public int MaxHealth;
		public int DamageTakingCooldown;
		public float Speed;
		public float EnemyDetectRange;
	}
}