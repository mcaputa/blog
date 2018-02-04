using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseNodeModule(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions()
            {
                FileProvider = fileProvider,
                RequestPath = "/node_modules"
            };

            app.UseStaticFiles(options);
            return app;
        }
    }
}
