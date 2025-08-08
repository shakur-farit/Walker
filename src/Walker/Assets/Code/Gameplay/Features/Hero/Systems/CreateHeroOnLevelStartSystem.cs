using System.Collections.Generic;
using Code.Gameplay.Features.Hero.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class CreateHeroOnLevelStartSystem : IExecuteSystem
	{
		private readonly List<GameEntity> _buffer = new(1);

		private readonly IHeroFactory _hereFactory;
		private readonly IGroup<GameEntity> _levels;

		public CreateHeroOnLevelStartSystem(GameContext game, IHeroFactory hereFactory)
		{
			_hereFactory = hereFactory;
			_levels = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Level,
					GameMatcher.HeroAbsent));
		}

		public void Execute()
		{
			foreach (GameEntity level in _levels.GetEntities(_buffer))
			{
				_hereFactory.CreateHero(HeroTypeId.TheGeneral, Vector3.zero);

				level.isHeroAbsent = false;
			}
		}
	}
}