using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemy
{
	public sealed class EnemyFeature : Feature
	{
		public EnemyFeature(ISystemsFactory systems)
		{
			Add(systems.Create<CreateEnemySystem>());

			Add(systems.Create<EnemyDeathSystem>());
		}
	}
}