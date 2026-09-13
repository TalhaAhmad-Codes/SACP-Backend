using System.Text;
using System.Text.Json;

namespace Backend.Shared.Middleware
{
    public sealed class TrimStringsMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // Only process requests that can contain a body.
            if (
                context.Request.ContentLength > 0
                && context.Request.ContentType?.Contains(
                    "application/json",
                    StringComparison.OrdinalIgnoreCase
                ) == true
            )
            {
                await TrimRequestBodyAsync(context);
            }

            await next(context);
        }

        private static async Task TrimRequestBodyAsync(HttpContext context)
        {
            // Allow the request body to be read multiple times.
            context.Request.EnableBuffering();

            using var reader = new StreamReader(
                context.Request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true
            );

            var body = await reader.ReadToEndAsync();

            // Reset stream position so ASP.NET Core can read it again.
            context.Request.Body.Position = 0;

            // Empty body -> nothing to process.
            if (string.IsNullOrWhiteSpace(body))
                return;

            try
            {
                using var document = JsonDocument.Parse(body);

                var trimmedJson = TrimJsonElement(document.RootElement);

                var bytes = Encoding.UTF8.GetBytes(trimmedJson);

                context.Request.Body = new MemoryStream(bytes);
                context.Request.ContentLength = bytes.Length;
            }
            catch (JsonException)
            {
                // Let ASP.NET Core's normal model binding handle invalid JSON.
                context.Request.Body.Position = 0;
            }
        }

        private static string TrimJsonElement(JsonElement element)
        {
            using var stream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(stream))
            {
                WriteTrimmedJson(writer, element);
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private static void WriteTrimmedJson(Utf8JsonWriter writer, JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    writer.WriteStartObject();

                    foreach (var property in element.EnumerateObject())
                    {
                        writer.WritePropertyName(property.Name);
                        WriteTrimmedJson(writer, property.Value);
                    }

                    writer.WriteEndObject();
                    break;

                case JsonValueKind.Array:
                    writer.WriteStartArray();

                    foreach (var item in element.EnumerateArray())
                    {
                        WriteTrimmedJson(writer, item);
                    }

                    writer.WriteEndArray();
                    break;

                case JsonValueKind.String:
                    writer.WriteStringValue(element.GetString()?.Trim());
                    break;

                case JsonValueKind.Number:
                    writer.WriteRawValue(element.GetRawText());
                    break;

                case JsonValueKind.True:
                    writer.WriteBooleanValue(true);
                    break;

                case JsonValueKind.False:
                    writer.WriteBooleanValue(false);
                    break;

                case JsonValueKind.Null:
                    writer.WriteNullValue();
                    break;
            }
        }
    }
}
