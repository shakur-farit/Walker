using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
	public class ArcDirectionalMoveSystem : IExecuteSystem
	{
		private readonly ITimeService _time;
		private readonly IGroup<GameEntity> _movers;
		private readonly List<GameEntity> _buffer = new(12);

		public ArcDirectionalMoveSystem(GameContext game, ITimeService time)
		{
			_time = time;
			_movers = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.WorldPosition,
					GameMatcher.Speed,
					GameMatcher.StartPosition,
					GameMatcher.TargetPosition,
					GameMatcher.ArcHeight,
					GameMatcher.ArcMovement,
					GameMatcher.ArcElapsedTime,
					GameMatcher.Moving));
		}

		public void Execute()
		{
			foreach (GameEntity mover in _movers.GetEntities(_buffer))
			{
				float distance = Vector2.Distance(mover.StartPosition, mover.TargetPosition);
				float arcTime = distance / mover.Speed;

				float elapsed = mover.ArcElapsedTime + _time.DeltaTime;
				mover.ReplaceArcElapsedTime(elapsed);

				float t = Mathf.Clamp01(elapsed / arcTime);

				Vector2 start = mover.StartPosition;
				Vector2 target = mover.TargetPosition;

				Vector2 pos = Vector2.Lerp(start, target, t);

				pos.y += mover.ArcHeight * Mathf.Sin(Mathf.PI * t);

				mover.ReplaceWorldPosition(pos);

				if (t >= 1f) 
					mover.isMoving = false;
			}
		}
	}
}