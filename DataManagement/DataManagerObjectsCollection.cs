namespace DataManagement {
    public class DataManagerObjectsCollection : IDataManagerObjectsCollection {
        private Dictionary<Type, (string, Func<object, string>)> objects = new Dictionary<Type, (string, Func<object, string>)>();
        public void AddObject<T>(string path, Func<T, string> nameFunc) where T : class {
            var type = typeof(T);
            if (objects.ContainsKey(type))
                return;

            Func<object, string> objectFunc = (obj) => nameFunc((T)obj);
            objects.Add(type, (path, objectFunc));
        }

        public string? GetFilePath<T>(T value) where T : class {
            var type = typeof(T);
            if (!objects.ContainsKey(type))
                return null;

            var entry = objects[type];

            var path = entry.Item1;
            var nameFunc = entry.Item2;

            return Path.Combine(path, nameFunc(value));
        }

        public string? GetDirectoryPath<T>() where T : class {
            var type = typeof(T);
            if (!objects.ContainsKey(type))
                return null;

            var entry = objects[type];

            var path = entry.Item1;

            return path;
        }
    }
}
