using Cysharp.Threading.Tasks;
using Infrastructure.States.StatesMachine;
using UI.Factory;

namespace Infrastructure.States
{
	public class LoadSceneState : IGameState
	{
		private readonly IUIFactory _uiFactory;
		private readonly IGameStatesSwitcher _gameStatesSwitcher;

		public LoadSceneState(IUIFactory uiFactory, IGameStatesSwitcher gameStatesSwitcher)
		{
			_uiFactory = uiFactory;
			_gameStatesSwitcher = gameStatesSwitcher;
		}

		public async void Enter()
		{
			await CreateUIRoot();

			EnterToLoadLevelState();
		}

		public void Exit()
		{
		}

		private async UniTask CreateUIRoot() =>
			await _uiFactory.CreateUIRoot();

		private void EnterToLoadLevelState() =>
			_gameStatesSwitcher.SwitchState<LoadLevelState>();
	}
}