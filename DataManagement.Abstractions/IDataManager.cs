namespace DataManagement {
    public interface IDataManager {
        public ISerializer Serializer { get; }
        public IDataManagerObjectsCollection Objects { get; set; }
        public IDataManagerClassesCollection Classes { get; set; }

        public T? GetValue<T>(string path);
        public T? GetObject<T>(string name) where T : class;
        public T? GetClass<T>() where T : class;

        public void SaveValue<T>(T value, string path, bool replace = true);
        public void SaveObject<T>(T value, bool replace = true) where T : class;
        public void SaveClass<T>(T value, bool replace = true) where T : class;

        public void DeleteValue(string path);
        public void DeleteObject<T>(T value) where T : class;
        public void DeleteClass<T>(T value) where T : class;
    }
}
