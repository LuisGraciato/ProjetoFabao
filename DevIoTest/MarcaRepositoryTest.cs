using DevIoBusiness.Models;
using DevIoData.Context;
using DevIoData.Repository;
using Microsoft.EntityFrameworkCore;

namespace DevIoTest
{
    public class MarcaRepositoryTest
    {
        [Fact]
        public void TestGetAllMarcas()
        {
            var connectionString = "Data Source=MAGNATI-10863-F\\SQLEXPRESS;Initial Catalog=CarrosDB;Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False;";
            var contextOptions = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            var context = new MyDbContext(contextOptions);
            var repository = new MarcaRepository(context);

            IEnumerable<Marca> marcas = repository.GetAllMarcas().Result;
            List<Marca> lista = marcas.ToList();

            Assert.NotNull(lista);
            Assert.Equal(1, lista.Count);
        }
    }

}
