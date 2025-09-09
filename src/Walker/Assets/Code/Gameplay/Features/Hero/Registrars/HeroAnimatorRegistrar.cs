using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
	public class HeroAnimatorRegistrar : EntityComponentRegistrar
	{
		[SerializeField] public HeroAnimator _heroAnimator;

		public override void RegisterComponents()
		{
			Entity
				.AddHeroAnimator(_heroAnimator)
				.AddDamageTakenAnimator(_heroAnimator);
		}

		public override void UnregisterComponents()
		{
			if (Entity.hasHeroAnimator)
				Entity.RemoveHeroAnimator();

			if (Entity.hasDamageTakenAnimator)
				Entity.RemoveDamageTakenAnimator();
		}
	}
}