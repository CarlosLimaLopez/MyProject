using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Infrastructure.Context;
using Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories
{
    public class DevicesRepository
    {
        private readonly DbContextOptions<DevicesContext> _options;

        //TODO
        public DevicesRepository(DbContextOptions<DevicesContext> options) : base()
        {
            _options = options;
        }

        //TODO
        public List<Device> GetDeviceBySerial(string serial)
        {
            List<Device> devices = new List<Device>();
            using (var db = new DevicesContext(_options))
            {
                devices = db.Devices.Where(x => x.d_serial.ToLower() == serial.Trim().ToLower()).ToList();
            }

            return devices;
        }

        //TODO
        public string InsertCounter(string serial, string brand, string model, string type)
        {
            using (var db = new DevicesContext(_options))
            {
                db.Devices.Add(new Device { d_serial = serial });
                db.Counters.Add(new Counter { c_serial = serial, c_brand = brand, c_model = model, c_type = type });

                db.SaveChanges();
            }

            return "Counter registered successfully.";
        }

        //TODO
        public string InsertGateway(string serial, string brand, string ip, string port)
        {
            using (var db = new DevicesContext(_options))
            {
                db.Devices.Add(new Device { d_serial = serial });
                db.Gateways.Add(new Gateway { g_serial = serial, g_brand = brand, g_ip = ip, g_port = port });

                db.SaveChanges();
            }

            return "Gateway registered successfully.";
        }
    }
}
