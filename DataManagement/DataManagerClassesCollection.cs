namespace DataManagement {
    public class DataManagerClassesCollection : IDataManagerClassesCollection {
        private Dictionary<Type, string> classes = new Dictionary<Type, string>();
        public void AddClass<T>(string path) where T : class {
            var type = typeof(T);
            if (classes.ContainsKey(type))
                return;

            classes.Add(type, path);
        }

        public string? GetFilePath<T>() where T : class {
            var type = typeof(T);
            if (!classes.ContainsKey(type))
                return null;

            var path = classes[type];

            return path;
        }
    }
}
