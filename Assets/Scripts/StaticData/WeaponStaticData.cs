using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Weapon Static Data", menuName = "Scriptable Objects/Static Data/Weapon")]
	public class WeaponStaticData : ScriptableObject
	{
		public Sprite Sprite;
		public int ShootCooldown;
	}
}