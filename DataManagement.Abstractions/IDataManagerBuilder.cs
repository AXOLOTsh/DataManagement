using Microsoft.Extensions.DependencyInjection;

namespace DataManagement {
    public interface IDataManagerBuilder {
        IServiceCollection Services { get; }

        ISerializer Serializer { get; set; }
        IDataManagerObjectsCollection Objects { get; }
        IDataManagerClassesCollection Classes { get; }
    }
}
