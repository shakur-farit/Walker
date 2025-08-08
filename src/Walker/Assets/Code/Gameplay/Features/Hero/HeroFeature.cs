using Code.Gameplay.Cameras.Systems;
using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero
{
	public sealed class HeroFeature : Feature
	{
		public HeroFeature(ISystemsFactory systems)
		{
			Add(systems.Create<CreateHeroOnLevelStartSystem>());

			Add(systems.Create<SetHeroForwardDirectionSystem>());
			Add(systems.Create<CameraFollowHeroSystem>());
			Add(systems.Create<FindClosestEnemySystem>());
			Add(systems.Create<RotateHeroWeaponAlongClosestTargetSystem>());
			Add(systems.Create<MovingOnEnemyDetectedSystem>());
			Add(systems.Create<ShootingOnEnemyDetectedSystem>());
		}
	}
}