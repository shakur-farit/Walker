using UI.Services.Windows;
using Zenject;

namespace UI.Windows
{
	public class InventoryWindow : WindowBass
	{
		private IWindowsService _windowsService;

		[Inject]
		public void Constructor(IWindowsService windowsService) => 
			_windowsService = windowsService;

		protected override void OnAwake()
		{
			
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Inventory);
	}
}