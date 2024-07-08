using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class GameOverWindow : WindowBass
	{
		private IGameStatesSwitcher _gameStatesSwitcher;
		private IWindowsService _windowsService;

		[Inject]
		public void Constructor(IGameStatesSwitcher gameStatesSwitcher, IWindowsService windowsService)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_windowsService = windowsService;
		}

		protected override void OnAwake()
		{
		}

		protected override void CloseWindow()
		{
			Debug.Log("hete");

			_windowsService.Close(WindowType.GameOver);

			_gameStatesSwitcher.SwitchState<LoadLevelState>();
		}
	}
}