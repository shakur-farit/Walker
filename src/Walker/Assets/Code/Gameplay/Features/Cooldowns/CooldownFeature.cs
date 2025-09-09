using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Cooldowns
{
	public sealed class CooldownFeature : Feature
	{
		public CooldownFeature(ISystemsFactory systems)
		{
			Add(systems.Create<CooldownSystem>());
		}
	}
}