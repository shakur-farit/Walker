using Code.Gameplay.Common.Physics;
using Code.Gameplay.Features.Hero;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
	public class CastForTargetsWithNoLimitSystem : IExecuteSystem
	{
		private readonly List<GameEntity> _buffer = new(128);

		private readonly IPhysicsService _physicsService;
		private readonly IGroup<GameEntity> _ready;

		public CastForTargetsWithNoLimitSystem(GameContext game, IPhysicsService physicsService)
		{
			_physicsService = physicsService;
			_ready = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.TargetsBuffer,
					GameMatcher.Radius,
					GameMatcher.TargetLayerMask,
					GameMatcher.WorldPosition,
					GameMatcher.ReadyToCollectTargets)
				.NoneOf(GameMatcher.TargetLimit));
		}

		public void Execute()
		{
			foreach (GameEntity ready in _ready.GetEntities(_buffer))
			{
				ready.TargetsBuffer.AddRange(TargetsInRadius(ready));

				if (ready.isCollectTargetsContinuously == false)
					ready.isReadyToCollectTargets = false;
			}
		}

		private IEnumerable<int> TargetsInRadius(GameEntity entity) =>
			_physicsService
				.CircleCast(entity.WorldPosition, entity.Radius, entity.TargetLayerMask)
				.Select(x => x.Id);
	}
}