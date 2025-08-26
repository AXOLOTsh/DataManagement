namespace DataManagement.Extensions {
    public static class DataManagerBuilderExtension {
        public static IDataManagerBuilder SetSerializer(this IDataManagerBuilder builder, ISerializer serializer) {
            builder.Serializer = serializer;
            return builder;
        }

        public static IDataManagerBuilder AddObject<T>(this IDataManagerBuilder builder, string path, Func<T, string> nameFunc) where T : class {
            var objects = builder.Objects;
            objects.AddObject(path, nameFunc);
            return builder;
        }
        public static IDataManagerBuilder AddClass<T>(this IDataManagerBuilder builder, string path) where T : class {
            var classes = builder.Classes;
            classes.AddClass<T>(path);
            return builder;
        }
    }
}
