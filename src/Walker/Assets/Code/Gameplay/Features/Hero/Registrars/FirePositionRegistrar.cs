using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
	public class FirePositionRegistrar : EntityComponentRegistrar
	{
		[SerializeField] private Transform _firePosiotionTransform;

		public override void RegisterComponents()
		{
			Entity
				.AddFirePositionPoint(_firePosiotionTransform);
		}

		public override void UnregisterComponents()
		{
			if (Entity.hasFirePositionPoint)
				Entity.RemoveFirePositionPoint();
		}
	}
}