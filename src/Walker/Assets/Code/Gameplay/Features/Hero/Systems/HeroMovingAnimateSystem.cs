using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class HeroMovingAnimateSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _heroes;

		public HeroMovingAnimateSystem(GameContext game)
		{
			_heroes = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.HeroAnimator));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _heroes)
			{
				if(hero.isMoving)
					hero.HeroAnimator.StartMoving();
				else
					hero.HeroAnimator.StartIdling();
			}
		}
	}
}