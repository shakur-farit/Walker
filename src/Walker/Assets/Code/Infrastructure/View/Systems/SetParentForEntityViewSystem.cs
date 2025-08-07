using System.Collections.Generic;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
	public class SetParentForEntityViewSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _children;
		private readonly List<GameEntity> _buffer = new(32);

		public SetParentForEntityViewSystem(GameContext game)
		{
			_children = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.ViewParent,
					GameMatcher.Transform)
				.NoneOf(GameMatcher.Parented));
		}

		public void Execute()
		{
			foreach (GameEntity child in _children.GetEntities(_buffer))
			{
				child.Transform.SetParent(child.ViewParent);
				child.isParented = true;
			}
		}
	}
}