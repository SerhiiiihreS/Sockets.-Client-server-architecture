// * Д.З. Реалізувати інтерфейс для запуску/зупинки сервера
//  * > Server OFF
//  * > 1 - Start
//  * > 0 - Exit
//  * >  1
//  * > Server ON
//  * > 2 - Stop
//  * > 0 - Exit
//  * >  0
//  * >  Server Stopped
//  * 
//  * Реалізувати команду генерації випадкового значення
//  * Command: 'RND-FILE'   | випадковий рядок довжиною 10 символів
//  * Payload: 10           | який може бути іменем файлу (не містить * / \ ? .. )
//  * 
//  * Command: 'RND-UINT'   | випадкове беззнакове число у діапазоні
//  * Payload: 10000        | 0 -- 10000
//  */

using System;
using System.Threading;
using System.Threading.Tasks;
using ServerApp;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;



namespace ServerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IRandomService, RandomService>();
                    services.AddSingleton<ICommandHandler, CommandHandler>();
                    services.AddHostedService<Server>();
                })
                .UseSerilog((context, configuration) =>
                {
                    configuration
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console(new CompactJsonFormatter())
                        .WriteTo.File(new CompactJsonFormatter(), "logs/log-.json", rollingInterval: RollingInterval.Day);
                })
                .Build();

            await host.RunAsync();
        }
    }
}
