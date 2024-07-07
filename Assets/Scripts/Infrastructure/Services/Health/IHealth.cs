using System;

namespace Infrastructure.Services.Health
{
	public interface IHealth
	{
		event Action HealthChanged; 
		void TakeDamage(int damage);
	}
}
