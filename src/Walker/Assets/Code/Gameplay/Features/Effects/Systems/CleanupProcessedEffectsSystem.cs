using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
	public class CleanupProcessedEffectsSystem : ICleanupSystem
	{
		private readonly IGroup<GameEntity> _effects;
		private List<GameEntity> _buffer = new(32);

		public CleanupProcessedEffectsSystem(GameContext Game)
		{
			_effects = Game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Effect,
					GameMatcher.Processed));
		}

		public void Cleanup()
		{
			foreach (GameEntity effect in _effects.GetEntities(_buffer)) 
				effect.Destroy();
		}
	}
}