using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace Tests
{
    public class TestContainersContainer
    {
        private  MsSqlContainer _msSqlContainer;
        public string ConnectionString { get; set; }
        private bool disposed = false;

        private TestContainersContainer() { }

        // 异步初始化方法
        private async Task InitializeAsync()
        {
            _msSqlContainer = new MsSqlBuilder().Build();
            await _msSqlContainer.StartAsync();
            ConnectionString = _msSqlContainer.GetConnectionString();
        }

        // 静态工厂方法
        public static async Task<TestContainersContainer> CreateAsync()
        {
            var container = new TestContainersContainer();
            await container.InitializeAsync();
            return container;
        }

      
    }
}
