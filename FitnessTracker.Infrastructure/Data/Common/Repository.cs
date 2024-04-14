using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Data.Common
{
	public class Repository : IRepository
	{
		private readonly DbContext context;

		public Repository(FitnessTrackerDbContext _context)
		{
			context = _context;
		}

		private DbSet<T> DbSet<T>() where T : class
		{
			return context.Set<T>();
		}

		public IQueryable<T> All<T>() where T : class
		{
			return DbSet<T>();
		}

		public IQueryable<T> AllReadOnly<T>() where	T : class
		{
			return DbSet<T>().AsNoTracking();
		}

		public async Task SaveAsync()
		{
			await context.SaveChangesAsync();
		}

		public async Task AddAsync<T>(T entity) where T : class
		{
			await context.AddAsync(entity);
		}
	}
}
