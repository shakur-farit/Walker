using Character;
using Cysharp.Threading.Tasks;


namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		UniTask Load();
		UniTask WarmUp();
		DropsListStaticData DropsList { get; }
		CharacterStaticData CharacterStaticData { get; }
		EnemyStaticData EnemyStaticData { get; }
		WeaponStaticData WeaponStaticData { get; }
		AmmoStaticData AmmoStaticData { get; }
	}
}