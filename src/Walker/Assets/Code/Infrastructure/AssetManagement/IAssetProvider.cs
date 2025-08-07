using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
  public interface IAssetProvider
  {
	  UniTask Initialize();
	  UniTask<T> LoadComponent<T>(string addressReference) where T : Component;
	  UniTask<T> Load<T>(string addressReference) where T : class;
	  UniTask<List<T>> LoadAll<T>(string label) where T : class;
	  void Release(string addressReference);
	  void CleanUp();
  }
}