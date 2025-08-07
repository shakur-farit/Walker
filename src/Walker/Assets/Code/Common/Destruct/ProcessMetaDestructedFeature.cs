using Code.Common.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common
{
	public sealed class ProcessMetaDestructedFeature : Feature
	{
		public ProcessMetaDestructedFeature(ISystemsFactory systems)
		{
			Add(systems.Create<CleanupMetaDestructedSystem>());
		}
	}
}