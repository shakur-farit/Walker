using Entitas;

namespace Code.Gameplay.Features.Enemy
{
	[Game] public class Enemy : IComponent { }
	[Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }

	[Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
	[Game] public class EnemyHpBarComponent : IComponent { public EnemyHpBar Value; }

	[Game] public class EnemyValue : IComponent { public int Value; }
}