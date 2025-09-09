using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
	[Game] public class Speed : IComponent { public float Value; }
	[Game] public class MovementRange : IComponent { public float Value; }
	[Game] public class Direction : IComponent { public Vector2 Value; }
	[Game] public class OrbitCenter : IComponent { public Vector3 Value; }
	[Game] public class OrbitRadius : IComponent { public float Value; }
	[Game] public class OrbitAngularSpeed : IComponent { public float Value; }
	[Game] public class OrbitElapsedTime : IComponent { public float Value; }
	[Game] public class OrbitInitialAngle : IComponent { public float Value; }
	[Game] public class StartPosition : IComponent { public Vector3 Value; }
	[Game] public class TargetPosition : IComponent { public Vector3 Value; }
	[Game] public class ArcHeight : IComponent { public float Value; }
	[Game] public class ArcElapsedTime : IComponent { public float Value; }
	[Game] public class Moving : IComponent { }
	[Game] public class MovementAvailable : IComponent { }
	[Game] public class LinerMovement : IComponent { }
	[Game] public class ArcMovement : IComponent { }
	[Game] public class OrbitalMovement : IComponent { }
}
