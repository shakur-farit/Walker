using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace UI.Factory
{
	public interface IUIFactory
	{
		UniTask CreateUIRoot();
		UniTask CreateInventoryWindow();
		UniTask CreateItemInformationWindow();
		UniTask CreateLevelCompleteWindow();
		UniTask CreateGameOverWindow();

		void DestroyInventoryWindow();
		void DestroyItemInformationWindow();
		void DestroyLevelCompleteWindow();
		void DestroyGameOVerWindow();
	}
}