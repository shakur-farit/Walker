using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Camera.Factory
{
	public interface IVirtualCameraFactory
	{
		UniTask Create();
		void Destroy(GameObject gameObject);
	}
}