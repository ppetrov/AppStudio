namespace AppCore.Features
{
	public interface IFeatureDataAdapter
	{
		void Insert(Feature feature, string details);
	}
}