using Code.Gameplay.Common.Time;
using Entitas;
using ModestTree;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
	public class LinerDirectionalMoveSystem : IExecuteSystem
	{
		private readonly ITimeService _time;
		private readonly IGroup<GameEntity> _movers;

		public LinerDirectionalMoveSystem(GameContext game, ITimeService time)
		{
			_time = time;
			_movers = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Speed,
					GameMatcher.WorldPosition,
					GameMatcher.Direction,
					GameMatcher.MovementAvailable,
					GameMatcher.LinerMovement,
					GameMatcher.Moving));
		}

		public void Execute()
		{
			foreach (GameEntity mover in _movers)
				mover.ReplaceWorldPosition((Vector2)mover.WorldPosition + mover.Direction *
					mover.Speed * _time.DeltaTime);
		}
	}
}