using System.Threading.Tasks;
using System;
using TP.API.Servcies;
using InfluxDB.Client.Writes;
using InfluxDB.Client.Api.Domain;
using Coravel.Invocable;

namespace TP.API.Invocables
{
    public class SensorsInvocable : IInvocable
    {
        private readonly InfluxDBService _service;

        public SensorsInvocable(InfluxDBService service)
        {
            _service = service;
        }

        public Task Invoke()
        {
            _service.Write(write =>
            {
                var point = PointData.Measurement("my_measures_sensors")
                    .Field("value", "t");

                write.WritePoint(point, "HD", "HD");
            });

            return Task.CompletedTask;
        }
    }
}
