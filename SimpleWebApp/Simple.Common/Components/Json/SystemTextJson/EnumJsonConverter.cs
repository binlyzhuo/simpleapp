using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Simple.Common.Components.Json.SystemTextJson
{
    /// <summary>
    /// Enum 转换
    /// </summary>
    public class EnumJsonConverter : JsonConverter<Enum>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        public override Enum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.TokenType switch
            {
                JsonTokenType.Number => reader.GetInt32().ToString(),
                JsonTokenType.String => reader.GetString(),
                _ => "0",
            };

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (Enum.TryParse(typeToConvert, value, out var result))
            {
                return result as Enum;
            }
            throw new InvalidOperationException("值不在枚举范围中");
        }

        public override void Write(Utf8JsonWriter writer, Enum value, JsonSerializerOptions options)
        {
            // 字符串
            //writer.WriteStringValue(value.ToString());
            //writer.WriteStringValue(Enum.GetName(value.GetType(), value));

            // 数字
            writer.WriteNumberValue(Convert.ToInt32(value));
        }
    }
}
