using Code.Gameplay.Cameras.Systems;
using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;
using Code.Meta.Features.Hud.CoinsHolder.Systems;
using Code.Meta.Features.Hud.HeroHeartHolder.Systems;

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

			Add(systems.Create<HeroMovingSystem>());
			Add(systems.Create<HeroMovingAnimateSystem>());
			Add(systems.Create<HeroShootingSystem>());

			Add(systems.Create<UpdateHeartUIForHeroInHolderSystem>());
			Add(systems.Create<UpdateCoinsTextInHolderSystem>());

			Add(systems.Create<HeroDeathSystem>());
		}
	}
}