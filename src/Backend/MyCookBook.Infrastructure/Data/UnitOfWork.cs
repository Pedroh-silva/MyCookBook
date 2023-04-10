﻿using MyCookBook.Domain.Repository;
using MyCookBook.Infrastructure.Context;

namespace MyCookBook.Infrastructure.Data
{
	public sealed class UnitOfWork : IDisposable, IUnitOfWork
	{
		private readonly MyCookBookContext _context;
		private bool _disposed;

		public UnitOfWork(MyCookBookContext context)
		{
			_context = context;
		}

		public async Task Commit()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			Dispose(true);
		}
		private void Dispose(bool disposing)
		{
			if(!_disposed && disposing)
			{
				_context.Dispose();
			}

			
			_disposed = true;

		}
	}
}
