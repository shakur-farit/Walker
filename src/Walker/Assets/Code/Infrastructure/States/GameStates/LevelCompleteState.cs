using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;
using Code.Progress.Provider;

namespace Code.Infrastructure.States.GameStates
{
	public class LevelCompleteState : SimpleState
	{
		private readonly IProgressProvider _progressProvider;
		private readonly IWindowService _windowService;

		public LevelCompleteState(IProgressProvider progressProvider, IWindowService windowService)
		{
			_progressProvider = progressProvider;
			_windowService = windowService;
		}

		public override void Enter()
		{
			CloseHud();
			OpenLevelCompleteWindow();
		}

		protected override void Exit() => 
			CloseLevelCompleteWindow();

		private void CloseHud() => 
			_windowService.Close(WindowId.Hud);

		private void OpenLevelCompleteWindow() => 
			_windowService.Open(WindowId.LevelCompleteWindow);

		private void CloseLevelCompleteWindow() => 
			_windowService.Close(WindowId.LevelCompleteWindow);
	}
}