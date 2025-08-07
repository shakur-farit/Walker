using Code.Progress.Data.Progress;

namespace Code.Progress.Provider
{
	public interface IProgressProvider
	{
		ProgressData ProgressData { get; }

		void SetProgressData(ProgressData data);
	}
}