using Code.Infrastructure.View;
using Code.Common.Extensions;
using UnityEngine;
using Entitas;

namespace Code.Gameplay.Features.Enemy
{
	[CreateAssetMenu(menuName = "Walker/Ammo Config", fileName = "AmmoConfig")]

	public class AmmoConfig : ScriptableObject
	{
		public AmmoTypeId TypeId;
		public EntityBehaviour ViewPrefab;
		public Sprite Sprite;
		public float MovementSpeed;
		public float RotationAngle;
		public float Range;
		public int Pierce;
	}
}