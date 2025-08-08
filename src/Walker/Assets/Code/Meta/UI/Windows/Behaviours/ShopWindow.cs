using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Code.Meta.UI.Windows.Service;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class ShopWindow : BaseWindow
	{
		[SerializeField] private Button _hearthButton;
		[SerializeField] private Button _cooldownButton;
		[SerializeField] private Button _damageButton;
		[SerializeField] private Button _closeButton;

		private IWindowService _windowService;
		private ITimeService _time;

		[Inject]
		public void Constructor(IWindowService windowService, ITimeService time)
		{
			Id = WindowId.ShopWindow;

			_windowService = windowService;
			_time = time;
		}

		private void OnEnable()
		{
			_hearthButton.onClick.AddListener(IncreaseCurrentHp);
			_cooldownButton.onClick.AddListener(DecreaseFireCooldown);
			_damageButton.onClick.AddListener(IncreaseDamage);
			_closeButton.onClick.AddListener(CloseWindow);

			_time.StopTime();
		}

		private void IncreaseCurrentHp()
		{
			CreateEntity.Empty()
				.AddUpgradeValue(1)
				.AddUpgradePrice(1)
				.With(x => x.isUpgradeRequested = true);

			CloseWindow();
		}

		private void DecreaseFireCooldown()
		{
			CreateEntity.Empty()
				.AddUpgradeValue(0.5f)
				.AddUpgradePrice(1)
				.With(x => x.isUpgradeRequested = true);

			CloseWindow();
		}

		private void IncreaseDamage()
		{
			CreateEntity.Empty()
				.AddUpgradeValue(1)
				.AddUpgradePrice(2)
				.With(x => x.isUpgradeRequested = true)
				.With(x => x.isDamageUpgrade = true);

			CloseWindow();
		}

		private void CloseWindow()
		{
			_windowService.Close(WindowId.ShopWindow);

			_time.StartTime();
		}
	}
}