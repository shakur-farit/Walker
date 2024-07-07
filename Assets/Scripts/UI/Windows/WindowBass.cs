using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
	public abstract class WindowBass : MonoBehaviour
	{
		[SerializeField] protected Button CloseButton;

		private void Awake()
		{
			CloseButton.onClick.AddListener(CloseWindow);

			OnAwake();
		}

		protected abstract void OnAwake();

		protected abstract void CloseWindow();
	}
}