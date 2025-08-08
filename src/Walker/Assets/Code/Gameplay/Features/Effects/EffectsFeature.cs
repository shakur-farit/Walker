using Code.Gameplay.Features.Effects.Systems;
using Code.Infrastructure;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Effects
{
	public sealed class EffectsFeature : Feature
	{
		public EffectsFeature(ISystemsFactory systems)
		{
			Add(systems.Create<RemoveEffectsWithoutTargetSystem>());
			Add(systems.Create<ProcessDamageEffectSystem>());
			Add(systems.Create<ProcessHealEffectSystem>());

			Add(systems.Create<CleanupProcessedEffectsSystem>());
		}
	}
}