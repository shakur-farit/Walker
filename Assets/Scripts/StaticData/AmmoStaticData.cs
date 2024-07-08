using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Ammo Static Data", menuName = "Scriptable Objects/Static Data/Ammo")]
	public class AmmoStaticData : ScriptableObject
	{
		public Sprite Sprite;
		public float Speed;
		public int Lifetime;
		public int Damage;
		public Vector2 ColliderSize;
	}
}