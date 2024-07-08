using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Zenject;

namespace UI.Windows
{
	public class GameCompleteWindow : WindowBass
	{
		private ISaveService _saveService;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(ISaveService saveService, IPersistentProgressService persistentProgressService)
		{
			_saveService = saveService;
			_persistentProgressService = persistentProgressService;
		}

		protected override void OnAwake()
		{
		}

		protected override void CloseWindow() =>
			QuitGame();

		private void QuitGame()
		{
			_saveService.SaveProgress(_persistentProgressService.Progress);

#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
		}
	}
}