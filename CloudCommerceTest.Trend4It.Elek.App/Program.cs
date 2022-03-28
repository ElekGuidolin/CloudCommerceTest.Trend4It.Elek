using CloudCommerceTest.Trend4It.Elek.Domain.Concrete;
using CloudCommerceTest.Trend4It.Elek.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace CloudCommerceTest.Trend4It.Elek.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPerson, PersonCsv>()
                .BuildServiceProvider();

            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));

            var person = serviceProvider.GetService<IPerson>();
            string[] csv = person.GetData($@"{path.Replace(@"file:\", "")}\CSV");
            string result = person.SaveData(csv);

            Console.WriteLine(result);

            File.WriteAllText($@"{path.Replace(@"file:\", "")}\JSON\person.json", result);

            Console.WriteLine("Proccess Done!!");
        }
    }
}
