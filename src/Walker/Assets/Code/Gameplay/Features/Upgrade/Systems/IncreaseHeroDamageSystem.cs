using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class IncreaseHeroDamageSystem : IExecuteSystem
	{
		private readonly List<GameEntity> _buffer = new(1);
		private readonly IGroup<GameEntity> _requests;
		private readonly IGroup<GameEntity> _heroes;

		public IncreaseHeroDamageSystem(GameContext game)
		{
			_requests = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.UpgradeRequested,
					GameMatcher.DamageUpgrade,
					GameMatcher.UpgradePrice,
					GameMatcher.UpgradeValue));


			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.Coins,
					GameMatcher.Damage));
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

				hero.ReplaceDamage(hero.Damage + request.UpgradeValue);
			}
		}
	}
}