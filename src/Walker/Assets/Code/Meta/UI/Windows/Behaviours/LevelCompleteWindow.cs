using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.Windows.Service;
using Code.Progress.Provider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class LevelCompleteWindow : BaseWindow
	{
		[SerializeField] private Button _nextLevelButton;


		private IGameStateMachine _stateMachine;

		[Inject]
		public void Constructor(IGameStateMachine stateMachine)
		{
			Id = WindowId.LevelCompleteWindow;

			_stateMachine = stateMachine;
		}

		protected override void Initialize()
		{
			_nextLevelButton.onClick.AddListener(EnterToBattle);
		}

		private void EnterToBattle() =>
			_stateMachine.Enter<BattleEnterState>();
	}
}