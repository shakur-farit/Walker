using Cysharp.Threading.Tasks;
using UI.Factory;
using UI.Windows;

namespace UI.Services.Windows
{
	public class WindowsService : IWindowsService
	{
		private readonly IUIFactory _uiFactory;

		public WindowsService(IUIFactory uiFactory) => 
			_uiFactory = uiFactory;

		public async UniTask Open(WindowType type)
		{
			switch (type)
			{
				case WindowType.Inventory:
					await _uiFactory.CreateInventoryWindow();
					break;
				case WindowType.ItemInformation:
					await _uiFactory.CreateItemInformationWindow();
					break;
				case WindowType.GameComplete:
					await _uiFactory.CreateGameCompleteWindow();
					break;
				case WindowType.GameOver:
					await _uiFactory.CreateGameOverWindow();
					break;
			}
		}

		public void Close(WindowType type)
		{
			switch (type)
			{
				case WindowType.Inventory:
					 _uiFactory.DestroyInventoryWindow();
					break;
				case WindowType.ItemInformation:
					_uiFactory.DestroyItemInformationWindow();
					break;
				case WindowType.GameComplete:
					_uiFactory.DestroyGameCompleteWindow();
					break;
				case WindowType.GameOver:
					 _uiFactory.DestroyGameOverWindow();
					break;
			}
		}
	}
}
