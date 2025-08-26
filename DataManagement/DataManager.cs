namespace DataManagement {
    public class DataManager : IDataManager {
        public ISerializer Serializer { get; }

        public IDataManagerObjectsCollection Objects { get; set; }
        public IDataManagerClassesCollection Classes { get; set; }

        public DataManager(IDataManagerObjectsCollection objects, IDataManagerClassesCollection classes) : this(new JsonSerializer(), objects, classes) { }
        public DataManager(ISerializer serializer, IDataManagerObjectsCollection objects, IDataManagerClassesCollection classes) {
            Serializer = serializer;

            Objects = objects;
            Classes = classes;
        }

        public T? GetValue<T>(string path) {
            if (!File.Exists(path))
                return default;

            using (var reader = File.OpenRead(path)) {
                return Serializer.Deserialize<T>(reader);
            }
        }
        public void SaveValue<T>(T value, string path, bool replace = true) {
            if (!replace && File.Exists(path))
                return;

            var directory = Path.GetDirectoryName(path);
            if (directory is not null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (var writer = File.Create(path)) {
                Serializer.Serialize(value, writer);
            }
        }
        public void DeleteValue(string path) {
            if (File.Exists(path))
                File.Delete(path);
        }
        public string[]? GetValues(string path) {
            if (!Directory.Exists(path))
                return null;

            return Directory.GetFiles(path);
        }

        public T? GetObject<T>(string name) where T : class {
            var directoryPath = Objects.GetDirectoryPath<T>();
            if (directoryPath is null)
                return default;

            var path = Path.Combine(directoryPath, name);
            return GetValue<T>(path);
        }
        public void SaveObject<T>(T value, bool replace = true) where T : class {
            var path = Objects.GetFilePath(value);
            if (path is null)
                return;

            SaveValue(value, path, replace);
        }
        public void DeleteObject<T>(T value) where T : class {
            var path = Objects.GetFilePath(value);
            if (path is null)
                return;

            DeleteValue(path);
        }
        public string[]? GetObjects<T>() where T : class {
            var directoryPath = Objects.GetDirectoryPath<T>();
            if (directoryPath is null)
                return null;

            return GetValues(directoryPath);
        }

        public T? GetClass<T>() where T : class {
            var path = Classes.GetFilePath<T>();
            if (path is null)
                return default;

            return GetValue<T>(path);
        }
        public void SaveClass<T>(T value, bool replace = true) where T : class {
            var path = Classes.GetFilePath<T>();
            if (path is null)
                return;

            SaveValue(value, path, replace);
        }
        public void DeleteClass<T>(T value) where T : class {
            var path = Classes.GetFilePath<T>();
            if (path is null)
                return;

            DeleteValue(path);
        }
    }
}
