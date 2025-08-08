using Code.Gameplay.Features.Hero.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
	[Game] public class Hero : IComponent { }
	[Game] public class HeroTypeIdComponent : IComponent { public HeroTypeId Value; }

	[Game] public class FirePositionPoint : IComponent { public Transform Value; }
	[Game] public class WeaponRotationPoint : IComponent { public Transform Value; }
	[Game] public class ClosestEnemyPosition : IComponent { public Vector3 Value; }

	[Game] public class Coins : IComponent { public int Value; }

	[Game] public class HeroAnimatorComponent : IComponent { public HeroAnimator Value; }

	[Game] public class UpgradeValue : IComponent { public float Value; }
	[Game] public class UpgradePrice : IComponent { public int Value; }
	[Game] public class UpgradeRequested : IComponent { }
	[Game] public class DamageUpgrade : IComponent { }
	[Game] public class HpUpgrade : IComponent { }
	[Game] public class CooldownUpgrade : IComponent { }
}