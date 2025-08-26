namespace DataManagement {
    public interface ISerializer {
        public void Serialize<T>(T value, Stream stream);
        public T? Deserialize<T>(Stream stream);
    }
}
