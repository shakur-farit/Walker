using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class DecreaseHeroShootingCooldownSystem : IExecuteSystem
	{
		private const float MinCooldown = 0.1f;


		private readonly List<GameEntity> _buffer = new(1);
		private readonly IGroup<GameEntity> _requests;
		private readonly IGroup<GameEntity> _heroes;

		public DecreaseHeroShootingCooldownSystem(GameContext game)
		{
			_requests = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.UpgradeRequested,
					GameMatcher.UpgradePrice,
					GameMatcher.UpgradeValue));


			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.Coins,
					GameMatcher.Cooldown));
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

				hero.ReplaceCooldown(hero.Cooldown - request.UpgradeValue);

				if (hero.Cooldown < MinCooldown)
					hero.ReplaceCooldown(MinCooldown);
			}
		}
	}
}