using Code.Gameplay.Cameras.Provider;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class LevelInitializer : MonoBehaviour, IInitializable
	{
		public Camera MainCamera;
		private ICameraProvider _cameraProvider;

		[Inject]
		private void Construct(ICameraProvider cameraProvider) => 
			_cameraProvider = cameraProvider;

		public void Initialize() => 
			_cameraProvider.SetMainCamera(MainCamera);
	}
}