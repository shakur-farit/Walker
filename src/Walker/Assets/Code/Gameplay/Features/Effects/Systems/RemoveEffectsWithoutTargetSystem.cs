using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
	public class RemoveEffectsWithoutTargetSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _effects;
		private readonly List<GameEntity> _buffer = new(32);

		public RemoveEffectsWithoutTargetSystem(GameContext game)
		{
			_effects = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Effect,
					GameMatcher.TargetId));
		}

		public void Execute()
		{
			foreach (GameEntity effect in _effects.GetEntities(_buffer))
			{
				var target = effect.Target();

				if(target == null)
					effect.Destroy();
			}
		}
	}
}