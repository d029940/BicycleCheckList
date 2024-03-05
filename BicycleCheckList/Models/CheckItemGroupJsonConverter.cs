using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BicycleCheckList.Models
{
    public class CheckItemGroupJsonConverter : JsonConverter<CheckItemGroup>
    {
        public override CheckItemGroup? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // StartObject
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            // Read Group
            // Prop
            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new JsonException();

            // value of prop
            reader.Read();
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();
            string group = reader.GetString() ?? "";

            // Read all check items of the group
            List<CheckItem> items = [];
            do
            {
                CheckItem? item = ReadItem(ref reader);
                if (item != null)
                {
                    items.Add(item);
                }
                else break;

            } while (true);

            return new CheckItemGroup(group, items);
        }

        private static CheckItem? ReadItem(ref Utf8JsonReader reader)
        {
            bool isChecked;
            string name;
            int amount;
            string lang;

            // Prop
            reader.Read();

            if (reader.TokenType == JsonTokenType.EndObject)
                return null;

            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new JsonException();

            // Start Array
            reader.Read();
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            // CheckItem
            if (!reader.Read())
                throw new JsonException();
            isChecked = reader.GetBoolean();

            if (!reader.Read() || reader.TokenType != JsonTokenType.String)
                throw new JsonException();
            name = reader.GetString() ?? "";

            if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
                throw new JsonException();
            amount = reader.GetInt16();

            if (!reader.Read() || reader.TokenType != JsonTokenType.String)
                throw new JsonException();
            lang = reader.GetString() ?? "de-DE";

            // EndArray
            if (!reader.Read()) throw new JsonException();
            if (reader.TokenType != JsonTokenType.EndArray)
                throw new JsonException();

            return (new CheckItem(name, amount, lang, isChecked));
        }


        public override void Write(Utf8JsonWriter writer, CheckItemGroup value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("Group", value.Group);

            List<CheckItem> items = value as List<CheckItem>;
            foreach (CheckItem item in items)
            {
                writer.WriteStartArray("Item");
                writer.WriteBooleanValue(item.IsChecked);
                writer.WriteStringValue(item.Name);
                writer.WriteNumberValue(item.Amount);
                writer.WriteStringValue(item.Language);
                writer.WriteEndArray();
            }
            writer.WriteEndObject();

        }
    }
}
