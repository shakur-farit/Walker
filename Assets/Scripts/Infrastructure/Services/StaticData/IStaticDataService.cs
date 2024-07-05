using Cysharp.Threading.Tasks;


namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		UniTask Load();
		UniTask WarmUp();
	}
}