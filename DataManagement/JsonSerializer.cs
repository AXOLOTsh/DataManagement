using System.Text.Json;

namespace DataManagement {
    public class JsonSerializer : ISerializer {
        public JsonSerializerOptions? Options { get; set; }
        public JsonSerializer() { }
        public JsonSerializer(JsonSerializerOptions? options) {
            Options = options;
        }

        public void Serialize<T>(T value, Stream stream) {
            System.Text.Json.JsonSerializer.Serialize(stream, value, Options);
        }

        public T? Deserialize<T>(Stream stream) {
            return System.Text.Json.JsonSerializer.Deserialize<T>(stream, Options);
        }
    }
}
