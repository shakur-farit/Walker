using Entitas;

namespace Code.Gameplay.Features.Enemy
{
	[Game] public class Enemy : IComponent { }
	[Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
}