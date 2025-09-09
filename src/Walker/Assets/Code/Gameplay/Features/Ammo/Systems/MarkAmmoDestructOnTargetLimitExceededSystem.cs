using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class MarkAmmoDestructOnTargetLimitExceededSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _ammo;
		private readonly List<GameEntity> _buffer = new(32);

		public MarkAmmoDestructOnTargetLimitExceededSystem(GameContext game)
		{
			_ammo = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Ammo,
					GameMatcher.TargetLimit,
					GameMatcher.ProcessedTargets));
		}

		public void Execute()
		{
			foreach (GameEntity ammo in _ammo.GetEntities(_buffer))
			{
				if (ammo.ProcessedTargets.Count >= ammo.TargetLimit)
					ammo.isDestructed = true;
			}
		}
	}
}