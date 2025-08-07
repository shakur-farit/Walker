using Code.Gameplay.Cameras.Provider;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cameras.Behaviours
{
	public class CameraStartOrthographicSizeInitializer : MonoBehaviour
	{
		private ICameraProvider _cameraProvider;

		[Inject]
		public void Constructor(ICameraProvider cameraProvider) => 
			_cameraProvider = cameraProvider;

		private void Start() => 
			_cameraProvider.SetCameraSize(15);
	}
}