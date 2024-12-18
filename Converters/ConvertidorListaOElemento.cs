using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Gestion_Del_Presupuesto.Converters
{
    public class ConvertidorListaOElemento<T> : JsonConverter<List<T>>
    {
        public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                // Si el JSON es un array, deserializar como lista
                return JsonSerializer.Deserialize<List<T>>(ref reader, options);
            }
            else
            {
                // Si el JSON es un solo objeto, envolver en una lista
                var valorUnico = JsonSerializer.Deserialize<T>(ref reader, options);
                return new List<T> { valorUnico };
            }
        }

        public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
        {
            // Serializar la lista de objetos como JSON
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
