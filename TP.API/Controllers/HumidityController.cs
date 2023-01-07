using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TP.API.Servcies;
using InfluxDB.Client.Writes;

namespace TP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumidityController : ControllerBase
    {
        private readonly InfluxDBService _service;

        public HumidityController(InfluxDBService service)
        {
            _service = service;
        }

        public void writeData(string valueName, int value)
        {
            _service.Write(write =>
            {
                var point = PointData.Measurement("my_measures_sensors")
                    .Field(valueName, value);

                write.WritePoint(point, "HD", "HD");
            });
        }

        [HttpPost]
        public void receivceFrames([FromBody] Dictionary<string, string> data)
        {
            string payLoad = "";
            int value = 0;

            string frame = data["data"];
            int digitsNumber = SensorsServices.digitsNumber(data["data"]);

            if (digitsNumber == 6)
            {
                payLoad = SensorsServices.payLoadSixDigits(frame);
                value = SensorsServices.stringToInt(payLoad);
                Console.WriteLine(value + " %");
                writeData("humidity", value);
            }
            else if (digitsNumber == 10)
            {
                payLoad = SensorsServices.payLoadSixDigits(frame);
                value = SensorsServices.stringToInt(payLoad);
                Console.WriteLine(value + " %");
                writeData("humidity", value);

                payLoad = SensorsServices.payLoadTenDigits(frame);
                value = SensorsServices.stringToInt(payLoad);
                Console.WriteLine(value + " %");
                writeData("humidity", value);
            }
        }
    }
}
