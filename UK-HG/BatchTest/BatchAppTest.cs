using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using BatchApp.Data;

namespace BatchTest
{
    public class BatchAppTest
    {
        private static DbContextOptions<ApplicationDbContext> DbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName:"BatchApp").Options;

        DbContext Context;

        [OneTimeSetUp]
        public void Setup()
        {
            Context = new ApplicationDbContext(DbContextOptions);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}