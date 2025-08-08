using Code.Gameplay.Features.Effects;
using Code.Infrastructure.View;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	[CreateAssetMenu(menuName = "Walker/Enemy Config", fileName = "EnemyConfig")]

	public class EnemyConfig : ScriptableObject
	{
		public EnemyTypeId TypeId;
		public EntityBehaviour ViewPrefab;
		public RuntimeAnimatorController AnimatorController;
		public float MovementSpeed;
		public float MovementRange;
		public float AttackRange;
		public float AttackInterval;
		public float ShootingRange;
		public float ShootingInterval;
		public float Damage;
		public float CurrentHp;
		public float MaxHp;
		public int Value;
	}
}