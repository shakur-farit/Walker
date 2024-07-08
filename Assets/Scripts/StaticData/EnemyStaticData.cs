using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
	[CreateAssetMenu(fileName = "Enemy Static Data", menuName = "Scriptable Objects/Static Data/Enemy")]
	public class EnemyStaticData : ScriptableObject
	{
		[Range(1, 100)] public int StartHealth;
		[Range(1, 100)] public int MaxHealth;
		[Range(0.05f, 100f)] public float MovementSpeed;
		[Range(1, 100)] public int Damage;
		[Range(1, 100)] public float CharcterDetectRange;
		private void OnValidate()
		{
			if (StartHealth > MaxHealth)
				MaxHealth = StartHealth;
		}
	}
}