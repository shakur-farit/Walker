
using Code.Gameplay.Features.Level.Factory;
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
		private readonly ILevelFactory _levelFactory;
		private readonly IWindowService _windowService;

		public BattleEnterState(
			IGameStateMachine stateMachine,
			ILevelFactory levelFactory,
			IWindowService windowService)
		{
			_stateMachine = stateMachine;
			_levelFactory = levelFactory;
			_windowService = windowService;
		}

		public override void Enter()
		{
			OpenHud();
			CreateLevel();
			EnterToBattleLoop();
		}

		private void OpenHud() => 
			_windowService.Open(WindowId.Hud);

		private void CreateLevel()
		{
			_levelFactory.CreateLevel(1);
		}

		private void EnterToBattleLoop() => 
			_stateMachine.Enter<BattleLoopState>();
	}
}