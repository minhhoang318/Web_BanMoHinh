using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServicesAndRepositories(this IServiceCollection services)
        {
            Console.WriteLine("AddServicesAndRepositories called");  // Debug log

            var serviceAssembly = Assembly.GetExecutingAssembly();

            // Đăng ký các Repository
            var repositoryTypes = serviceAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"))
                .ToList();

            foreach (var repo in repositoryTypes)
            {
                var interfaceType = repositoryTypes.FirstOrDefault(i => i.Name == "I" + repo.Name);
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, repo);
                }
            }

            // Đăng ký các Service
            var serviceTypes = serviceAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"))
                .ToList();

            foreach (var service in serviceTypes)
            {
                var interfaceType = serviceTypes.FirstOrDefault(i => i.Name == "I" + service.Name);
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, service);
                }
            }
        }
    }
}
