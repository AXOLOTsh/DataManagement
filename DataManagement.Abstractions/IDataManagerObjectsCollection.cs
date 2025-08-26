namespace DataManagement {
    public interface IDataManagerObjectsCollection {
        public void AddObject<T>(string path, Func<T, string> nameFunc) where T : class;
        public string? GetFilePath<T>(T value) where T : class;
        public string? GetDirectoryPath<T>() where T : class;
    }
}
