using Code.Gameplay.Features;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Level;
using Code.Gameplay.Features.Level.Configs;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
	  UniTask Load();

    WindowConfig GetWindowConfig(WindowId id);
    HeroConfig GetHeroConfig(HeroTypeId typeId);
    EnemyConfig GetEnemyConfig(EnemyTypeId typeId);
    LevelConfig GetLevelConfig(LevelTypeId typeId);
    AmmoConfig GetAmmoConfig(AmmoTypeId typeId);
  }
}