using System.Collections.Generic;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class HeroDeathSystem : IExecuteSystem
	{
		private readonly IWindowService _windowService;
		private readonly IGroup<GameEntity> _heroes;
		private readonly List<GameEntity> _buffer = new(1);

		public HeroDeathSystem(GameContext game, IWindowService windowService)
		{
			_windowService = windowService;
			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero, 
					GameMatcher.Dead));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes.GetEntities(_buffer))
			{
				hero.isDestructed = true;

				_windowService.Open(WindowId.GameOverWindow);
			}
		}
	}
}