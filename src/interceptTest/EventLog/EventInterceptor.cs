using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.DynamicProxy;

namespace interceptTest.EventLog;

/// <summary>
/// 事件拦截器
/// </summary>
public class EventInterceptor : AbpInterceptor, ITransientDependency
{
    public ILogger<EventInterceptor> Logger { get; set; }
    public EventInterceptor()
    {
        Logger = NullLogger<EventInterceptor>.Instance;
    }
    public override async Task InterceptAsync(IAbpMethodInvocation invocation)
    {
            Logger.LogInformation("call：{0}，Argument：{1}", invocation.Method.Name,
                string.Join(",", invocation.ArgumentsDictionary.Select(t => $"{t.Key}:{t.Value ?? ""}")));
            await invocation.ProceedAsync();
    }
}