using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetDirectoryName(typeof(Program).GetTypeInfo().Assembly.Location);

            var configurations = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var services = new ServiceCollection();

            var awsOptions = configurations.GetAWSOptions();
            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonS3>();

            var serviceProvider = services.BuildServiceProvider();

            var s3Client = serviceProvider.GetService<IAmazonS3>();

            Debug.Assert(s3Client != null);

            Console.WriteLine("Wroks - using AWSSDK.Extensions.NETCore.Setup v3.3.0.3");
            Console.ReadLine();
        }
    }
}
