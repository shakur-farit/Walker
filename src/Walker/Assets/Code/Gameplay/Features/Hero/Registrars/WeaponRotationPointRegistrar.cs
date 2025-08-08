using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
	public class WeaponRotationPointRegistrar : EntityComponentRegistrar
	{
		[SerializeField] private Transform _weaponRotationPoint;

		public override void RegisterComponents() =>
			Entity.AddWeaponRotationPoint(_weaponRotationPoint);

		public override void UnregisterComponents()
		{
			if (Entity.hasWeaponRotationPoint)
				Entity.RemoveWeaponRotationPoint();
		}
	}
}