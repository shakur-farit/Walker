using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
	[Game] public class Hero : IComponent { }
	[Game] public class HeroTypeIdComponent : IComponent { public HeroTypeId Value; }

	[Game] public class FirePositionPoint : IComponent { public Transform Value; }
	[Game] public class WeaponRotationPoint : IComponent { public Transform Value; }
	[Game] public class ClosestEnemyPosition : IComponent { public Vector3 Value; }
}