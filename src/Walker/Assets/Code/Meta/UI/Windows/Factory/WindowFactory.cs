﻿using Code.Gameplay.StaticData;
using Code.Meta.UI.Windows.Behaviours;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Windows.Factory
{
	public class WindowFactory : IWindowFactory
	{
		private readonly IStaticDataService _staticData;
		private readonly IInstantiator _instantiator;
		private Transform _uiRoot;

		public WindowFactory(IStaticDataService staticData, IInstantiator instantiator)
		{
			_staticData = staticData;
			_instantiator = instantiator;
		}

		public void SetUIRoot(RectTransform uiRoot) =>
			_uiRoot = uiRoot;

		public BaseWindow CreateWindow(WindowId windowId) =>
			_instantiator.InstantiatePrefabForComponent<BaseWindow>(PrefabFor(windowId), _uiRoot);

		private GameObject PrefabFor(WindowId id) => 
			_staticData.GetWindowConfig(id).ViewPrefab;
	}
}