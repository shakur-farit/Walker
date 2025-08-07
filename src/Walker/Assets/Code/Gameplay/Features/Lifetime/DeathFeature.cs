using Code.Gameplay.Features.Lifetime.Systems;
using Code.Infrastructure;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime
{
	public sealed class DeathFeature : Feature
	{
		public DeathFeature(ISystemsFactory systems)
		{
			Add(systems.Create<MarkDeadSystem>());
		}
	}
}