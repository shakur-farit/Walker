using Entitas;

namespace Code.Meta.Features.Hud.CoinsHolder.Systems
{
	public class UpdateCoinsTextInHolderSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _heroes;
		private readonly IGroup<GameEntity> _coinsHolders;

		public UpdateCoinsTextInHolderSystem(GameContext game)
		{
			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.Coins));

			_coinsHolders = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.CoinsHolder));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes)
			foreach (GameEntity coins in _coinsHolders)
				coins.CoinsHolder.UpdateCoinsText(hero.Coins);
		}
	}
}