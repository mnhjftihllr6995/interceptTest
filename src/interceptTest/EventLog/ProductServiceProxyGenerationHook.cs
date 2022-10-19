using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace interceptTest.EventLog;
public class ProductServiceProxyGenerationHook : IProxyGenerationHook, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ProductServiceProxyGenerationHook> _logger;

    public ProductServiceProxyGenerationHook(IServiceProvider serviceProvider,  ILogger<ProductServiceProxyGenerationHook> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public void MethodsInspected()
    {
    }

    public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
    {
    }

    public void NonVirtualMemberNotification(Type type, MemberInfo memberInfo)
    {
    }

    public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
    {
        return methodInfo
            .CustomAttributes
            .Any(a => a.AttributeType == typeof(EventLogAttribute));

        return true;
    }
}
