using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Level;
using Code.Gameplay.Features.Level.Configs;
using Code.Infrastructure.AssetManagement;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Code.Gameplay.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string WindowConfigLabel = "WindowConfig";
		private const string HeroConfigLabel = "HeroConfig";
		private const string EnemyConfigLabel = "EnemyConfig";
		private const string AmmoConfigLabel = "AmmoConfig";
		private const string LevelConfigLabel = "LevelConfig";

		private Dictionary<WindowId, WindowConfig> _windowById;
		private Dictionary<HeroTypeId, HeroConfig> _heroById;
		private Dictionary<EnemyTypeId, EnemyConfig> _enemyById;
		private Dictionary<AmmoTypeId, AmmoConfig> _ammoById;
		private Dictionary<LevelTypeId, LevelConfig> _levelById;

		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) =>
			_assetProvider = assetProvider;

		public async UniTask Load()
		{
			await LoadWindows();
			await LoadHeroes();
			await LoadLevels();
			await LoadAmmo();
			await LoadEnemies();
		}


		public WindowConfig GetWindowConfig(WindowId id)
		{
			if (_windowById.TryGetValue(id, out WindowConfig config))
				return config;

			throw new Exception($"Window config for {id} was not found");
		}

		public HeroConfig GetHeroConfig(HeroTypeId typeId)
		{
			if (_heroById.TryGetValue(typeId, out HeroConfig config))
				return config;

			throw new Exception($"Hero config for {typeId} was not found");
		}

		public EnemyConfig GetEnemyConfig(EnemyTypeId typeId)
		{
			if (_enemyById.TryGetValue(typeId, out EnemyConfig config))
				return config;

			throw new Exception($"Enemy config for {typeId} was not found");
		}

		public LevelConfig GetLevelConfig(LevelTypeId typeId)
		{
			if (_levelById.TryGetValue(typeId, out LevelConfig config))
				return config;

			throw new Exception($"Level config for {typeId} was not found");
		}

		public AmmoConfig GetAmmoConfig(AmmoTypeId typeId)
		{
			if (_ammoById.TryGetValue(typeId, out AmmoConfig config))
				return config;

			throw new Exception($"Ammo config for {typeId} was not found");
		}

		private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadHeroes() =>
			_heroById = (await _assetProvider.LoadAll<HeroConfig>(HeroConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadEnemies() =>
			_enemyById = (await _assetProvider.LoadAll<EnemyConfig>(EnemyConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadAmmo() =>
			_ammoById = (await _assetProvider.LoadAll<AmmoConfig>(AmmoConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadLevels() =>
			_levelById = (await _assetProvider.LoadAll<LevelConfig>(LevelConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);
	}
}