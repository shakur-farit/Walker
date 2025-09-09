using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemy
{
	public sealed class AmmoFeature : Feature
	{
		public AmmoFeature(ISystemsFactory systems)
		{
			Add(systems.Create<CreateHeroAmmoSystem>());
			Add(systems.Create<CreateEnemyAmmoSystem>());
			Add(systems.Create<MarkAmmoDestructOnTargetLimitExceededSystem>());
		}
	}
}