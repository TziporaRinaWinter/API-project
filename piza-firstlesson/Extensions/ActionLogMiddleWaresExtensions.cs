using piza_firstlesson.Middlewares;
namespace piza_firstlesson.Extensions{
    public static class ActionLogMiddleWaresExtensions
    {
        public static IApplicationBuilder UseActionLog(
        this IApplicationBuilder builder)
        {
        return builder.UseMiddleware<ActionLogMiddleware>();
        }
    }
}