using Camera.Factory;
using Character.Factory;
using Enemy.Factory;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;

namespace Infrastructure.States
{
	public class GameOverState : IGameState
	{
		private readonly IWindowsService _windowService;
		private readonly ITilemapFactory _tilemapFactory;
		private readonly IVirtualCameraFactory _virtualCameraFactory;
		private readonly ICharacterFactory _characterFactory;
		private IHudFactory _hudFactory
			;

		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IEnemyFactory _enemyFactory;

		public GameOverState(IWindowsService windowService, ICharacterFactory characterFactory, 
			IHudFactory hudFactory, IEnemyFactory enemyFactory, IVirtualCameraFactory virtualCameraFactory,
			ITilemapFactory tilemapFactory, IPersistentProgressService persistentProgressService)
		{
			_windowService = windowService;
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_enemyFactory = enemyFactory;
			_virtualCameraFactory = virtualCameraFactory;
			_tilemapFactory = tilemapFactory;
			_persistentProgressService = persistentProgressService;
		}

		public void Enter() => 
			_windowService.Open(WindowType.GameOver);

		public void Exit()
		{
			DestroyTilemap();
			DestroyVirtualCamera();
			DestroyHud();
			DestroyEnemies();
			DestroyCharacter();
		}

		private void DestroyTilemap() =>
			 _tilemapFactory.Destroy();

		private void DestroyVirtualCamera() =>
			_virtualCameraFactory.Destroy();

		private void DestroyCharacter() =>
			_characterFactory.Destroy();

		private void DestroyHud() =>
			_hudFactory.Destroy();

		private void DestroyEnemies()
		{
			foreach (GameObject gameObject in _persistentProgressService.Progress.EnemyData.EnemiesList)
				_enemyFactory.Destroy(gameObject);

			_persistentProgressService.Progress.EnemyData.EnemiesList.Clear();
		}
	}
}