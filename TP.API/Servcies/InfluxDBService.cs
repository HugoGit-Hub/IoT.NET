using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using InfluxDB.Client;

namespace TP.API.Servcies
{
    public class InfluxDBService
    {
        private readonly string _token;

        public InfluxDBService(IConfiguration configuration)
        {
            _token = configuration.GetValue<string>("InfluxDB:Token");
        }

        public void Write(Action<WriteApi> action)
        {
            #pragma warning disable CS0618 // Type or member is obsolete
            using var client = InfluxDBClientFactory.Create("http://localhost:8086", _token);

            #pragma warning restore CS0618 // Type or member is obsolete
            using var write = client.GetWriteApi();
            action(write);
        }

        public async Task<T> QueryAsync<T>(Func<QueryApi, Task<T>> action)
        {
            #pragma warning disable CS0618 // Type or member is obsolete
            using var client = InfluxDBClientFactory.Create("http://localhost:8086", _token);

            #pragma warning restore CS0618 // Type or member is obsolete
            var query = client.GetQueryApi();
            return await action(query);
        }
    }
}
