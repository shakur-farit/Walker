using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Ammo Static Data", menuName = "Scriptable Objects/Static Data/Ammo")]
	public class AmmoStaticData : ScriptableObject
	{
		public Sprite Sprite;
		[Range(0.01f, 50f)] public float MovementSpeed;
		[Range(1, 5000)] public int Lifetime;
		[Range(1, 50)] public int Damage;
		public Vector2 ColliderSize;
	}
}