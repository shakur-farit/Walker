using Infrastructure.Services.PersistentProgress;
using UI.Factory;
using UI.Services.Windows;
using Zenject;

namespace UI.Windows
{
	public class InventoryWindow : WindowBass
	{
		private IWindowsService _windowsService;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IWindowsService windowsService, IPersistentProgressService persistentProgressService)
		{
			_windowsService = windowsService;
			_persistentProgressService = persistentProgressService;
		}

		protected override void OnAwake()
		{
			
		}

		protected override void CloseWindow()
		{
			_windowsService.Close(WindowType.Inventory);

			_persistentProgressService.Progress.InventoryData.ItemCellsList.Clear();
		}

	}
}