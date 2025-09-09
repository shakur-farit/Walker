using Entitas;

namespace Code.Meta.Features.Hud.HeroHeartHolder.Systems
{
	public class UpdateHeartUIForHeroInHolderSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _holders;
		private readonly IGroup<GameEntity> _heroes;

		public UpdateHeartUIForHeroInHolderSystem(GameContext game)
		{
			_holders = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.HeartHolder));

			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.MaxHp,
					GameMatcher.CurrentHp));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes)
			foreach (GameEntity holder in _holders)
				holder.HeartHolder.UpdateHeartUICount(hero.CurrentHp, hero.MaxHp);
		}
	}
}