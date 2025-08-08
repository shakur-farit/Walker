﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Effects.Systems
{
	public class ProcessDamageEffectSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _effects;
		private readonly List<GameEntity> _buffer = new(64);

		public ProcessDamageEffectSystem(GameContext game)
		{
			_effects = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.DamageEffect,
					GameMatcher.EffectValue,
					GameMatcher.TargetId));
		}

		public void Execute()
		{
			foreach (GameEntity effect in _effects.GetEntities(_buffer))
			{
				GameEntity target = effect.Target();

				effect.isProcessed = true;

				if (target.isDead)
					continue;

				target.ReplaceCurrentHp(target.CurrentHp - effect.EffectValue);

				if (target.hasDamageTakenAnimator)
					target.DamageTakenAnimator.PlayDamageTaken();
			}
		}
	}
}