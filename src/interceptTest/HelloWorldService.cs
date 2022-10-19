using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using interceptTest.EventLog;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace interceptTest;

public class HelloWorldService :UserControl,  ITransientDependency
{
    public ILogger<HelloWorldService> Logger { get; set; }

    public HelloWorldService()
    {
        Logger = NullLogger<HelloWorldService>.Instance;
    }
    [UnitOfWork]
    public virtual Task SayHelloAsync()
    {
        
        return Task.CompletedTask;
    }
}
