using Code.Common.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common
{
	public sealed class ProcessGameDestructedFeature : Feature
	{
		public ProcessGameDestructedFeature(ISystemsFactory systems)
		{
			Add(systems.Create<SelfDestructTimerSystem>());

			Add(systems.Create<CleanupGameDestructedViewSystem>());
			Add(systems.Create<CleanupGameDestructedSystem>());
		}
	}
}