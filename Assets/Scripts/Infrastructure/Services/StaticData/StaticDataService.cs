using Character;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string DropsListStaticDataAddress = "Drops List Static Data";
		private const string CharacterStaticDataAddress = "Character Static Data";
		private const string EnemyStaticDataAddress = "Enemy Static Data";
		private const string WeaponStaticDataAddress = "Weapon Static Data";
		private const string AmmoStaticDataAddress = "Ammo Static Data";

		private readonly IAssetsProvider _assetsProvider;

		public DropsListStaticData DropsList { get; private set; }
		public CharacterStaticData CharacterStaticData{ get; private set; }
		public EnemyStaticData EnemyStaticData{ get; private set; }
		public WeaponStaticData WeaponStaticData{ get; private set; }
		public AmmoStaticData AmmoStaticData{ get; private set; }

		public StaticDataService(IAssetsProvider assetsProvider) =>
			_assetsProvider = assetsProvider;

		public async UniTask Load()
		{
			DropsList = await _assetsProvider.Load<DropsListStaticData>(DropsListStaticDataAddress);
			CharacterStaticData = await _assetsProvider.Load<CharacterStaticData>(CharacterStaticDataAddress);
			EnemyStaticData = await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);
			WeaponStaticData = await _assetsProvider.Load<WeaponStaticData>(WeaponStaticDataAddress);
			AmmoStaticData = await _assetsProvider.Load<AmmoStaticData>(AmmoStaticDataAddress);
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<DropsListStaticData>(DropsListStaticDataAddress);
			await _assetsProvider.Load<CharacterStaticData>(CharacterStaticDataAddress);
			await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);
			await _assetsProvider.Load<WeaponStaticData>(WeaponStaticDataAddress);
			await _assetsProvider.Load<AmmoStaticData>(AmmoStaticDataAddress);
		}
	}
}