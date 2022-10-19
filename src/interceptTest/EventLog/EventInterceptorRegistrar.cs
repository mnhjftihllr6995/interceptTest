using System;
using System.Linq;
using System.Reflection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.DynamicProxy;

namespace interceptTest.EventLog;

public static class EventInterceptorRegistrar
{
    public static void RegisterIfNeeded(IOnServiceRegistredContext context)
    {
        if (ShouldIntercept(context.ImplementationType))
        {
            context.Interceptors.TryAdd<EventInterceptor>();
        }
    }
    private static bool ShouldIntercept(Type type)
    {
        return !DynamicProxyIgnoreTypes.Contains(type) &&
               (type.IsDefined(typeof(EventLogAttribute), true) ||
                type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Any(methodInfo => methodInfo.IsDefined(typeof(EventLogAttribute), true)));
    }
}