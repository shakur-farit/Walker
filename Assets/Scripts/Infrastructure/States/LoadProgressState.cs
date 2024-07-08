using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.States.StatesMachine;

namespace Infrastructure.States
{
	public class LoadProgressState : IGameState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly ISaveService _saveLoadService;

		public LoadProgressState(IGameStatesSwitcher gameStatesSwitcher, IPersistentProgressService persistentProgressService, 
			ISaveService saveLoadService)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_saveLoadService = saveLoadService;
		}

		public void Enter()
		{
			InitProgress();

			EnterToLoadSceneState();
		}

		public void Exit()
		{
		}

		private void InitProgress() => 
			_persistentProgressService.Progress = LoadProgress() != null ? LoadProgress() : InitializeNewProgress();

		private Progress LoadProgress() => 
			_saveLoadService.LoadProgress();

		private Progress InitializeNewProgress() => new();

		private void EnterToLoadSceneState() => 
			_gameStatesSwitcher.SwitchState<LoadSceneState>();
	}
}