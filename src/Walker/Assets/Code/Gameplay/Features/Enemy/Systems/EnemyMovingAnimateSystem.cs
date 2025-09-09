using Entitas;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyMovingAnimateSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _enemies;

		public EnemyMovingAnimateSystem(GameContext game)
		{
			_enemies = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Enemy,
					GameMatcher.EnemyAnimator));
		}

		public void Execute()
		{
			foreach (GameEntity enemy in _enemies)
			{
				if (enemy.isMoving)
					enemy.EnemyAnimator.StartMoving();
				else
					enemy.EnemyAnimator.StartIdling();
			}
		}
	}
}