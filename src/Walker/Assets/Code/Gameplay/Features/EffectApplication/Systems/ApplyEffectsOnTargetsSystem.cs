using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
	public class ApplyEffectsOnTargetsSystem : IExecuteSystem
	{
		private readonly IEffectFactory _effectFactory;
		private readonly IGroup<GameEntity> _entities;

		public ApplyEffectsOnTargetsSystem(GameContext game, IEffectFactory effectFactory)
		{
			_effectFactory = effectFactory;
			_entities = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.EffectSetups,
					GameMatcher.TargetsBuffer));
		}

		public void Execute()
		{
			foreach (GameEntity entity in _entities)
			foreach (int targetId in entity.TargetsBuffer)
			foreach (EffectSetup setup in entity.EffectSetups)
				_effectFactory.CreateEffect(setup, ProducerId(entity), targetId);
		}

		private int ProducerId(GameEntity entity) => 
			entity.hasProducerId ? entity.ProducerId : entity.Id;
	}
}