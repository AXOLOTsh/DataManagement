namespace DataManagement {
    public interface IDataManagerClassesCollection {
        public void AddClass<T>(string path) where T : class;
        public string? GetFilePath<T>() where T : class;
    }
}
