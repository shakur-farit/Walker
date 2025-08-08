using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
	public sealed class MovementFeature : Feature
	{
		public MovementFeature(ISystemsFactory systems)
		{
			Add(systems.Create<LinerDirectionalMoveSystem>());
			Add(systems.Create<OrbitDirectionalMoveSystem>());
			Add(systems.Create<UpdateTransformPositionSystem>());
			Add(systems.Create<UpdateChildrenPositionRelativeParentSystem>());
		}
	}
}