using System.Collections.Generic;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Entitas;

namespace Code.Gameplay.Features.Level.Systems
{
	public class CompleteLevelOnEnemiesDefeatSystem : IExecuteSystem
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly List<GameEntity> _buffer = new(1);

		private readonly IGroup<GameEntity> _levels;

		public CompleteLevelOnEnemiesDefeatSystem(GameContext game, IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
			_levels = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Level,
					GameMatcher.EnemiesInLevelCount));
		}

		public void Execute()
		{
			foreach (GameEntity level in _levels.GetEntities(_buffer))
			{
				if (level.EnemiesInLevelCount <= 0)
				{
					level.isDestructed = true;
					level.isProcessed = true;
					_stateMachine.Enter<LevelCompleteState>();
				}
			}
		}
	}
}