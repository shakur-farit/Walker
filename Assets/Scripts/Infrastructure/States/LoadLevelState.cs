using Character;
using Character.Factory;
using Cysharp.Threading.Tasks;
using Enemy.Factory;
using Hud.Factory;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using UI.Factory;
using UnityEngine;

namespace Infrastructure.States
{
	public class LoadLevelState : IGameState
	{
		private readonly IStaticDataService _staticDataService;
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IUIFactory _uiFactory;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IRandomService _randomizer;

		public LoadLevelState(ICharacterFactory characterFactory, IHudFactory hudFactory, IUIFactory uiFactory, 
			IEnemyFactory enemyFactory, IRandomService randomizer, IStaticDataService staticDataService)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_uiFactory = uiFactory;
			_enemyFactory = enemyFactory;
			_randomizer = randomizer;
			_staticDataService = staticDataService;
		}

		public async void Enter()
		{
			await CreateUIRoot();
			await CreateCharacter();
			await CreateHud();
			await CreateEnemies();
		}

		public void Exit()
		{
		}

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		private async UniTask CreateCharacter() => 
			await _characterFactory.Create();

		private async UniTask CreateHud() => 
			await _hudFactory.Create();

		private async UniTask CreateEnemies()
		{
			LevelStaticData levelStaticData = _staticDataService.LevelStaticData;

			Debug.Log(levelStaticData.MinXPositionToEnemySpawn +"/ " + levelStaticData.MaxXPositionToEnemySpawn);

			for (int i = 0; i < levelStaticData.EnemiesCountOnLevel; i++)
			{
				float randomXPosition = _randomizer.Next(levelStaticData.MinXPositionToEnemySpawn, levelStaticData.MaxXPositionToEnemySpawn);
				float randomYPosition = _randomizer.Next(levelStaticData.MinYPositionToEnemySpawn, levelStaticData.MaxYPositionToEnemySpawn);
				await _enemyFactory.Create(new Vector2(randomXPosition, randomYPosition));
			}
		}
	}
}