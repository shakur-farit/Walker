using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero.Systems
{
	public sealed class UpgradeFeature : Feature
	{
		public UpgradeFeature(ISystemsFactory systems)
		{
			Add(systems.Create<IncreaseHeroCurrentHpSystem>());
			Add(systems.Create<IncreaseHeroDamageSystem>());
			Add(systems.Create<DecreaseHeroShootingCooldownSystem>());
		}
	}
}