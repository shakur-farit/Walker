using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemy
{
	public sealed class EnemyFeature : Feature
	{
		public EnemyFeature(ISystemsFactory systems)
		{
			Add(systems.Create<CreateEnemySystem>());

			Add(systems.Create<EnemyShootingSystem>());
			Add(systems.Create<EnemyMovingSystem>());
			Add(systems.Create<EnemyMovingAnimateSystem>());

			Add(systems.Create<EnemyHpBarUpgradeSystem>());
			Add(systems.Create<EnemyDeathSystem>());
		}
	}
}