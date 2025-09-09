using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Effects.Factory
{
	public class EffectFactory : IEffectFactory
	{
		private readonly IIdentifierService _identifier;

		public EffectFactory(IIdentifierService identifier) => 
			_identifier = identifier;

		public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
		{
			switch (setup.EffectTypeId)
			{
				case EffectTypeId.Damage:
					return	CreateDamage(producerId, targetId, setup.Value);
				case EffectTypeId.Heal:
					return CreateHeal(producerId, targetId, setup.Value);
			}

			throw new Exception($"Effect with type id {setup.EffectTypeId} does not exist");
		}

		private GameEntity CreateDamage(int producerId, int targetId, float value) =>
			CreateEffectEntity(producerId, targetId, value)
				.With(x => x.isDamageEffect = true);

		private GameEntity CreateHeal(int producerId, int targetId, float value) =>
			CreateEffectEntity(producerId, targetId, value)
				.With(x => x.isHealEffect = true);

		private GameEntity CreateEffectEntity(int producerId, int targetId, float value) =>
			CreateEntity.Empty()
				.AddId(_identifier.Next())
				.With(x => x.isEffect = true)
				.AddProducerId(producerId)
				.AddTargetId(targetId)
				.AddEffectValue(value);
	}
}