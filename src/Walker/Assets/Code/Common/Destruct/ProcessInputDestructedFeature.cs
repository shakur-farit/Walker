using Code.Common.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common
{
	public sealed class ProcessInputDestructedFeature : Feature
	{
		public ProcessInputDestructedFeature(ISystemsFactory systems)
		{
			Add(systems.Create<CleanupInputDestructedSystem>());
		}
	}
}