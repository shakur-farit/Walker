using UnityEngine;

namespace Code.Gameplay.Common.Visuals.StatusVisuals
{
	public class StatusVisuals : MonoBehaviour, IStatusVisuals
	{
		private static readonly int ColorProperty = Shader.PropertyToID("_Color");
		private static readonly int ColorIntensityProperty = Shader.PropertyToID("_Intensity");

		[SerializeField] public Renderer _renderer;
		[SerializeField] public Animator _animator;

		[Header("Freeze")]
		public Color FreezeColor;

		[Header("Poison")]
		public Color PoisonColor;
		public float PoisonColorIntensity;

		public void ApplyFreeze()
		{
			_renderer.material.SetColor(ColorProperty, FreezeColor);
			_animator.speed = 0;
		}

		public void UnapplyFreeze()
		{
			_renderer.material.SetColor(ColorProperty, Color.white);
			_animator.speed = 1;
		}

		public void ApplyPoison()
		{
			_renderer.material.SetColor(ColorProperty, PoisonColor);
			_renderer.material.SetFloat(ColorIntensityProperty, PoisonColorIntensity);
		}

		public void UnapplyPoison()
		{
			_renderer.material.SetColor(ColorProperty, Color.white);
			_renderer.material.SetFloat(ColorIntensityProperty, 0f);
		}
	}
}