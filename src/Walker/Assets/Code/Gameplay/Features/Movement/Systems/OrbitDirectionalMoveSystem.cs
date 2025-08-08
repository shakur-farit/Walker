using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
	public class OrbitDirectionalMoveSystem : IExecuteSystem
	{
		private readonly ITimeService _time;
		private readonly IGroup<GameEntity> _entities;

		public OrbitDirectionalMoveSystem(GameContext game, ITimeService time)
		{
			_time = time;

			_entities = game.GetGroup(GameMatcher.AllOf(
				GameMatcher.WorldPosition,
				GameMatcher.Direction,
				GameMatcher.Speed,
				GameMatcher.MovementAvailable,
				GameMatcher.Moving,
				GameMatcher.OrbitalMovement,
				GameMatcher.OrbitRadius,
				GameMatcher.OrbitCenter,
				GameMatcher.OrbitAngularSpeed,
				GameMatcher.OrbitInitialAngle,
				GameMatcher.OrbitElapsedTime
			));
		}

		public void Execute()
		{
			foreach (GameEntity entity in _entities)
			{
				float elapsed = entity.OrbitElapsedTime + _time.DeltaTime;
				entity.ReplaceOrbitElapsedTime(elapsed);

				float angle = entity.OrbitInitialAngle + entity.OrbitAngularSpeed * elapsed;
				float rad = angle * Mathf.Deg2Rad;

				Vector3 offset = new Vector3(
					Mathf.Cos(rad),
					Mathf.Sin(rad),
					0f
				) * entity.OrbitRadius;

				Vector3 newPos = entity.OrbitCenter + offset;
				entity.ReplaceWorldPosition((Vector2)newPos);
			}
		}
	}
}