using System;
using Api.Infrastructure.Context;
using Api.Infrastructure.Repositories;
using Api.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        private DbContextOptions<DevicesContext> _options;

        public InsertController(DbContextOptions<DevicesContext> options)
        {
            _options=options;
        }

        // POST Insert/Counter
        [HttpPost]
        [Route("Counter")]
        //[DisableCors]
        public ActionResult<string> Counter([FromBody]CounterModel counter)
        {
            string result = "error";

            try
            {
                DevicesRepository devices = new DevicesRepository(_options);

                if (devices.GetDeviceBySerial(counter.Serial).Count == 0)
                {
                    result = devices.InsertCounter(counter.Serial, counter.Brand, counter.Model, counter.Type);

                }
                else
                {
                    result = "The serial number entered was already registered. Please check the serial number.";
                }
            }
            catch (Exception ex)
            {
                return "Error: "+ex.Message;
            }

            return result;
        }

        // POST Insert/Gateway
        [HttpPost]
        [Route("Gateway")]
        public ActionResult<string> Gateway([FromBody]GatewayModel gateway)
        {
            string result = "error";

            try
            {
                DevicesRepository devices = new DevicesRepository(_options);

                if (devices.GetDeviceBySerial(gateway.Serial).Count == 0)
                {
                    result = devices.InsertGateway(gateway.Serial, gateway.Brand, gateway.Ip, gateway.Port);
                }
                else
                {
                    result = "The serial number entered was already registered. Please check the serial number.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }
    }
}
