using Character.Factory;
using Enemy.Factory;
using Hud.Factory;
using Infrastructure.Services.Randomizer;
using UI.Factory;
using UnityEngine;

namespace Infrastructure.States
{
	public class LoadLevelState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IUIFactory _uiFactory;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IRandomService _randomizer;

		public LoadLevelState(ICharacterFactory characterFactory, IHudFactory hudFactory, IUIFactory uiFactory, IEnemyFactory enemyFactory, IRandomService randomizer)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_uiFactory = uiFactory;
			_enemyFactory = enemyFactory;
			_randomizer = randomizer;
		}

		public void Enter()
		{
			CreateUIRoot();
			CreateHud();
			CreateCharacter();
			CreateEnemies();
		}

		private void CreateUIRoot()
		{
			_uiFactory.CreateUIRoot();
		}

		private void CreateHud()
		{
			_hudFactory.Create();
		}

		private void CreateCharacter()
		{
			_characterFactory.Create();
		}

		private void CreateEnemies()
		{
			for (int i = 0; i < 3; i++)
			{
				float randomXPosition = _randomizer.Next(-10f, 10f);
				float randomYPosition = _randomizer.Next(-10f, 10f);
				_enemyFactory.Create(new Vector2(randomXPosition, randomYPosition));
			}
		}

		public void Exit()
		{
			
		}
	}
}