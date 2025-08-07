using System.Collections.Generic;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
	  UniTask Load();

    WindowConfig GetWindowConfig(WindowId id);
  }
}