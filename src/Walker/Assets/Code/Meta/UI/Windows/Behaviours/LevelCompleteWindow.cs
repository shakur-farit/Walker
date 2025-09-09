using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class LevelCompleteWindow : BaseWindow
	{
		[SerializeField] private Button _restartButton;
		[SerializeField] private Button _quitButton;

		private IGameStateMachine _stateMachine;

		[Inject]
		public void Constructor(IGameStateMachine stateMachine)
		{
			Id = WindowId.LevelCompleteWindow;

			_stateMachine = stateMachine;
		}

		protected override void Initialize()
		{
			_restartButton.onClick.AddListener(EnterToBattle);
			_quitButton.onClick.AddListener(Quit);
		}

		private void EnterToBattle() =>
			_stateMachine.Enter<BattleEnterState>();

		private void Quit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
		}
	}
}