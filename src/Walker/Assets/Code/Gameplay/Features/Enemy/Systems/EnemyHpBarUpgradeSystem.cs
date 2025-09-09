using Entitas;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyHpBarUpgradeSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _enemies;

		public EnemyHpBarUpgradeSystem(GameContext game)
		{
			_enemies = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Enemy,
					GameMatcher.CurrentHp,
					GameMatcher.MaxHp,
					GameMatcher.EnemyHpBar));
		}

		public void Execute()
		{
			foreach (GameEntity enemy in _enemies) 
				enemy.EnemyHpBar.UpdateHpBar(enemy.CurrentHp, enemy.MaxHp);
		}
	}
}