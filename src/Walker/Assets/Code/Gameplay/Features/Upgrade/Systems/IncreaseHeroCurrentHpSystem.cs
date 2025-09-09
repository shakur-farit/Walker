using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class IncreaseHeroCurrentHpSystem : IExecuteSystem
	{
		private readonly List<GameEntity> _buffer = new(1);
		private readonly IGroup<GameEntity> _requests;
		private readonly IGroup<GameEntity> _heroes;

		public IncreaseHeroCurrentHpSystem(GameContext game)
		{
			_requests = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.UpgradeRequested,
					GameMatcher.HpUpgrade,
					GameMatcher.UpgradePrice,
					GameMatcher.UpgradeValue));


			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.Coins,
					GameMatcher.CurrentHp,
					GameMatcher.MaxHp));
		}

		public void Execute()
		{
			foreach (GameEntity request in _requests.GetEntities(_buffer))
			foreach (GameEntity hero in _heroes)
			{
				request.isUpgradeRequested = false;
				request.isDestructed = true;

				if (hero.Coins < request.UpgradePrice)
					continue;

				hero.ReplaceCoins(hero.Coins - request.UpgradePrice);

				hero.ReplaceCurrentHp(hero.CurrentHp + request.UpgradeValue);

				if (hero.CurrentHp > hero.MaxHp)
					hero.ReplaceCurrentHp(hero.MaxHp);
			}
		}
	}
}