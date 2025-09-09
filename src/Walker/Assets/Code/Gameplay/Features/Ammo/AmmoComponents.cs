using Entitas;

namespace Code.Gameplay.Features.Enemy
{
	[Game] public class Ammo : IComponent { }
	[Game] public class AmmoTypeIdComponent : IComponent { public AmmoTypeId Value; }

	[Game] public class RotationAngle : IComponent { public float Value; }
	[Game] public class Shooting : IComponent { }
	
	[Game] public class HeroAmmo : IComponent { }
	[Game] public class EnemyAmmo : IComponent { }
}