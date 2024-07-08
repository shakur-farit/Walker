using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Weapon Static Data", menuName = "Scriptable Objects/Static Data/Weapon")]
	public class WeaponStaticData : ScriptableObject
	{
		public Sprite Sprite;
		[Range(0, 5000)] public int ShootCooldown;
	}
}