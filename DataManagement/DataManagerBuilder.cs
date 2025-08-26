using Microsoft.Extensions.DependencyInjection;

namespace DataManagement {
    public class DataManagerBuilder : IDataManagerBuilder {
        public IServiceCollection Services { get; }

        public ISerializer Serializer { get; set; }
        public IDataManagerObjectsCollection Objects { get; }
        public IDataManagerClassesCollection Classes { get; }

        public DataManagerBuilder(IServiceCollection services) : this(services, new JsonSerializer(), new DataManagerObjectsCollection(), new DataManagerClassesCollection()) { }
        public DataManagerBuilder(IServiceCollection services, ISerializer serializer, IDataManagerObjectsCollection objects, IDataManagerClassesCollection classes) {
            Services = services;

            Serializer = serializer;
            Objects = objects;
            Classes = classes;
        }
    }
}
