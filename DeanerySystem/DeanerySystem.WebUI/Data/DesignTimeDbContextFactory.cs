//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using DeanerySystem.DataAccess.Concrete;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

//namespace DeanerySystem.WebUI.Data
//{
//    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DeaneryDbContext>
//    {
//        public DeaneryDbContext CreateDbContext(string[] args)
//        {
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build();

//            var builder = new DbContextOptionsBuilder<DeaneryDbContext>();

//            var connectionString = configuration.GetConnectionString("DefaultConnection");

//            builder.UseSqlServer(connectionString);

//            return new DeaneryDbContext(builder.Options);
//        }
//    }
//}
