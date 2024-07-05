using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private readonly IAssetsProvider _assetsProvider;


		public StaticDataService(IAssetsProvider assetsProvider) =>
			_assetsProvider = assetsProvider;

		public async UniTask Load()
		{

		}

		public async UniTask WarmUp()
		{

		}
	}
}