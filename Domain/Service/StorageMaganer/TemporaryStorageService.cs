using Infrastructure.Entity;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Storage
{
    public class TemporaryStorageService
    {
        public static bool CreateDirectory( string path )
        {
            Directory.CreateDirectory(path);

            return Directory.Exists(path);
        }
        public static void DeleteDirectory( string name )
        {
            var matches = Directory.GetFiles(name);
            foreach ( var file in matches )
            {
                File.Delete(file);
            }
        }
    }
}
