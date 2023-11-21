using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoTest
{
    public class ContextTest
    {
        [Fact]
        public void TestSqlConnection()
        {
            //arrange
            var connectionString = "Data Source=MAGNATI-10863-F\\SQLEXPRESS;Initial Catalog=CarrosDB;Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False;";
            var contextOptions = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            var context = new MyDbContext(contextOptions);
            bool connected;

            //act
            try
            {
                connected = context.Database.CanConnect();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível conectar", e);
            }

            //assert
            Assert.True(connected);
        }
    }

}