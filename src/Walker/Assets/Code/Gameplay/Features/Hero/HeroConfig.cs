using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
	[CreateAssetMenu(menuName = "Walker/Hero Config", fileName = "HeroConfig")]
	public class HeroConfig : ScriptableObject
	{
		public HeroTypeId TypeId;
		public EntityBehaviour ViewPrefab;
		public float MovementSpeed;
		public float AttackRange;
		public float AttackCooldown;
		public float CurrentHp;
		public float MaxHp;
		public int Damage;
	}
}