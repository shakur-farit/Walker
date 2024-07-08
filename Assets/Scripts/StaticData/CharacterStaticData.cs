using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Character Static Data", menuName = "Scriptable Objects/Static Data/Character")]
	public class CharacterStaticData : ScriptableObject
	{
		[Range(1, 100)] public int StartHealth;
		[Range(1, 100)] public int MaxHealth;
		[Range(0, 5000)] public int DamageTakingCooldown;
		[Range(0.05f, 20f)] public float MovementSpeed;
		[Range(0.05f, 50f)] public float EnemyDetectRange;

		private void OnValidate()
		{
			if(StartHealth > MaxHealth) 
				MaxHealth = StartHealth;
		}
	}
}