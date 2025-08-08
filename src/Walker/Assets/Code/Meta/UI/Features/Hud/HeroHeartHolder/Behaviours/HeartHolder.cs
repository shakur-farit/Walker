using System.Collections.Generic;
using Code.Meta.Features.Hud.HeroHeartHolder.Factory;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Meta.Features.Hud.HeroHeartHolder.Behaviours
{
	public class HeartHolder : MonoBehaviour
	{
		private const int MaxHearts = 10;

		[SerializeField] private Transform _holder;

		private IHeartUIFactory _factory;

		private readonly List<GameObject> _heartIconsBuffer = new();

		[Inject]
		public void Constructor(IHeartUIFactory factory) =>
			_factory = factory;


		public async void UpdateHeartUICount(float currentHp, float maxHp)
		{
			int heartsToShow = Mathf.CeilToInt((currentHp / maxHp) * MaxHearts);
			heartsToShow = Mathf.Clamp(heartsToShow, 0, MaxHearts);

			await CreateHeartUI();

			for (int i = 0; i < _heartIconsBuffer.Count; i++)
				_heartIconsBuffer[i].SetActive(i < heartsToShow);
		}

		private async UniTask CreateHeartUI()
		{
			while (_heartIconsBuffer.Count < MaxHearts)
			{
				GameObject icon = await _factory.CreateHeartUI(_holder);
				icon.SetActive(false);
				_heartIconsBuffer.Add(icon);
			}
		}
	}
}