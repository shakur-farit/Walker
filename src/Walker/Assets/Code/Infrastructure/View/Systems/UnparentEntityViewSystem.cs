using System.Collections.Generic;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
	public class UnparentEntityViewSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;
		private readonly List<GameEntity> _buffer = new(32);

		public UnparentEntityViewSystem(GameContext game)
		{
			_entities = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.ViewParent,
					GameMatcher.Unparented));
		}

		public void Execute()
		{
			foreach (GameEntity entity in _entities.GetEntities(_buffer))
			{
				entity.ViewParent.SetParent(null);

				entity.isParented = false;
			}
		}
	}
}
