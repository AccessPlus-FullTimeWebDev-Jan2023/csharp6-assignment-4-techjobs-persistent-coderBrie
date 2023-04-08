using System;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;

namespace Task.Tests
{
    public class ConnectionFactory : IDisposable
    {
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public JobDbContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<JobDbContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new JobDbContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}

