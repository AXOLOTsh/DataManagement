using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DataManagement.Extensions {
    public static class DataManagerServiceCollectionExtension {
        public static IServiceCollection AddDataManager(this IServiceCollection services) => services.AddDataManager(x => { });
        public static IServiceCollection AddDataManager(this IServiceCollection services, Action<IDataManagerBuilder> configure) {
            if (services is null) throw new ArgumentNullException(nameof(services));

            var builder = new DataManagerBuilder(services);
            configure(builder);

            services.TryAdd(ServiceDescriptor.Singleton<IDataManager>(new DataManager(builder.Serializer, builder.Objects, builder.Classes)));

            return services;
        }
    }
}
