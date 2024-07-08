using Data;

namespace Infrastructure.Services.Randomizer
{
	public interface ISaveService
	{
		void SaveProgress(Progress progress);
		Progress LoadProgress();
		void DeleteProgress();
	}
}