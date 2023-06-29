
// See https://aka.ms/new-console-template for more information
using IOCAbstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

Console.WriteLine("Hello, World!");


IServiceCollection _services = new ServiceCollection();
_services.AddSingleton<IMiddleware, Define>();


