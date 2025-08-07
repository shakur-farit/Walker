using Code.Gameplay.Input.Systems;
using Code.Infrastructure;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Input
{
	public sealed class InputFeature : Feature
	{
		public InputFeature(ISystemsFactory systems)
		{
			Add(systems.Create<InitializeInputSystem>());

			Add(systems.Create<EmitAxisInputSystem>());
			Add(systems.Create<EmitLeftMouseButtonInputSystem>());
		}
	}
}