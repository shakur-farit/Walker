using Code.Gameplay.Features.EffectApplication.Systems;
using Code.Infrastructure;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.EffectApplication
{
	public sealed class EffectApplicationFeature : Feature
	{
		public EffectApplicationFeature(ISystemsFactory systems)
		{
			Add(systems.Create<ApplyEffectsOnTargetsSystem>());
		}
	}
}