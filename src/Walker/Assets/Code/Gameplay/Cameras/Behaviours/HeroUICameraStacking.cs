using Code.Gameplay.Cameras.Provider;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;

namespace Code.Gameplay.Cameras.Behaviours
{
	public class HeroUICameraStacking : MonoBehaviour
	{
		[SerializeField] private Camera _heroUICamera;

		private ICameraProvider _cameraProvider;

		[Inject]
		public void Constructor(ICameraProvider cameraProvider) => 
			_cameraProvider = cameraProvider;

		private void Start() => 
			_cameraProvider.MainCamera
				.GetUniversalAdditionalCameraData()
				.cameraStack.Add(_heroUICamera);
	}
}