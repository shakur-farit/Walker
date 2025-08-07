
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;
using Code.Progress.Provider;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
	public class BattleEnterState : SimpleState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly IProgressProvider _progressProvider;
		private readonly IWindowService _windowService;

		public BattleEnterState(
			IGameStateMachine stateMachine,
			IProgressProvider progressProvider,
			IWindowService windowService)
		{
			_stateMachine = stateMachine;
			_progressProvider = progressProvider;
			_windowService = windowService;
		}

		public override void Enter()
		{
			OpenHud();
			EnterToBattleLoop();
		}

		private void OpenHud() => 
			_windowService.Open(WindowId.Hud);

		private void EnterToBattleLoop() => 
			_stateMachine.Enter<BattleLoopState>();
	}
}