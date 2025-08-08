using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class HeroShootingSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _heroes;
		private readonly List<GameEntity> _buffer = new(1);

		public HeroShootingSystem(GameContext game)
		{
			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.TargetsBuffer));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes.GetEntities(_buffer)) 
				hero.isShooting = hero.TargetsBuffer.Count > 0;
		}
	}
}