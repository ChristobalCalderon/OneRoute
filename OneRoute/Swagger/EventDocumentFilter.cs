using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace OneRoute.Swagger
{
    public class EventDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var eventDownSchema = new OpenApiSchema
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>
                {
                    { "eventType", new OpenApiSchema
                    {
                        Type = "string",
                    } }
                },
                Title = "EventDown"
            };

            var eventUpSchema = new OpenApiSchema
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>
                {
                    { "eventType", new OpenApiSchema
                    {
                        Type = "string",
                    } }
                },
                Title = "EventUp"
            };

            swaggerDoc.Components.Schemas["Event"].OneOf = new List<OpenApiSchema>()
            {
                eventDownSchema,
                eventUpSchema
            };
            swaggerDoc.Components.Schemas.Add("EventDown", eventDownSchema);
            swaggerDoc.Components.Schemas.Add("EventUp", eventUpSchema);
        }
    }
}
