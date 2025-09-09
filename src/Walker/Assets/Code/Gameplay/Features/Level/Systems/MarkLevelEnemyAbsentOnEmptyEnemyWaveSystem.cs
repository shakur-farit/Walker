using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;
using Entitas;

namespace Code.Gameplay.Features.Level.Systems
{
	public class MarkLevelEnemyAbsentOnEmptyEnemyWaveSystem : IExecuteSystem
	{
		private readonly IWindowService _windowService;
		private readonly List<GameEntity> _buffer = new(1);

		private readonly IGroup<GameEntity> _levels;

		public MarkLevelEnemyAbsentOnEmptyEnemyWaveSystem(GameContext game, IWindowService windowService)
		{
			_windowService = windowService;
			_levels = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Level,
					GameMatcher.NextWaveIndex,
					GameMatcher.EnemiesInWaveCount)
				.NoneOf(GameMatcher.EnemyAbsent, GameMatcher.Processed));
		}

		public void Execute()
		{
			foreach (GameEntity level in _levels.GetEntities(_buffer))
			{
				if (level.EnemiesInWaveCount <= 0)
				{
					level.ReplaceNextWaveIndex(level.NextWaveIndex + 1);
					level.isEnemyAbsent = true;

					_windowService.Open(WindowId.ShopWindow);
				}
			}
		}
	}
}