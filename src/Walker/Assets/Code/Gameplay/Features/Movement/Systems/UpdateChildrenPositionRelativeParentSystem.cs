using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
	public class UpdateChildrenPositionRelativeParentSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _children;

		public UpdateChildrenPositionRelativeParentSystem(GameContext game)
		{
			_children = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.ViewParent,
					GameMatcher.Transform,
					GameMatcher.Parented));
		}

		public void Execute()
		{
			foreach (GameEntity child in _children)
			{
				child.ReplaceWorldPosition(child.ViewParent.position);
				child.Transform.localPosition = Vector2.zero;
			}
		}
	}
}