using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class GameCompleteState : IGameState
	{
		private readonly IWindowsService _windowsService;

		public GameCompleteState(IWindowsService windowsService) => 
			_windowsService = windowsService;

		public void Enter() => 
			_windowsService.Open(WindowType.GameComplete);

		public void Exit()
		{
			throw new System.NotImplementedException();
		}
	}
}