namespace FitnessTracker.Infrastructure.Data.Common
{
	public interface IRepository
	{
		IQueryable<T> All<T>() where T : class; 

		IQueryable<T> AllReadOnly<T>() where T : class;

		void AddAsync<T>(T entity) where T : class;

		void SaveAsync();
	}
}
