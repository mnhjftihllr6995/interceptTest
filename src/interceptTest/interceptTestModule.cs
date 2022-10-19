using System.Threading.Tasks;
using interceptTest.EventLog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace interceptTest;

[DependsOn(
    typeof(AbpAutofacModule)
)]
[DependsOn(typeof(AbpUnitOfWorkModule))]
    public class interceptTestModule : AbpModule
{
    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.OnRegistred(EventInterceptorRegistrar.RegisterIfNeeded);
    }
}
