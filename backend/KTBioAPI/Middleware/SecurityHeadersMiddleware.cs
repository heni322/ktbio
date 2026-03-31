namespace KTBioAPI.Middleware
{
    /// <summary>
    /// Middleware to add security headers to all HTTP responses
    /// </summary>
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SecurityHeadersMiddleware> _logger;

        public SecurityHeadersMiddleware(RequestDelegate next, ILogger<SecurityHeadersMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Remove server header to avoid leaking server info
                context.Response.Headers.Remove("Server");
                context.Response.Headers.Remove("X-Powered-By");
                
                // Prevent MIME-sniffing attacks
                context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
                
                // Prevent clickjacking attacks
                context.Response.Headers.Append("X-Frame-Options", "DENY");
                
                // Enable XSS protection in older browsers
                context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
                
                // Control referrer information
                context.Response.Headers.Append("Referrer-Policy", "no-referrer");
                
                // Restrict permissions
                context.Response.Headers.Append("Permissions-Policy", "geolocation=(), microphone=(), camera=()");
                
                // Content Security Policy
                context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'");
                
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SecurityHeadersMiddleware");
                throw;
            }
        }
    }

    /// <summary>
    /// Extension method for adding SecurityHeadersMiddleware
    /// </summary>
    public static class SecurityHeadersMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecurityHeadersMiddleware>();
        }
    }
}
