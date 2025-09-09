using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
	public sealed class CollectTargetsFeature : Feature
	{
		public CollectTargetsFeature(ISystemsFactory systems)
		{
			Add(systems.Create<CollectTargetsIntervalSystem>());
			Add(systems.Create<CastForTargetsWithNoLimitSystem>());
			Add(systems.Create<CastForTargetsWithLimitSystem>());

			Add(systems.Create<CleanupTargetBuffersSystem>());
		}
	}
}