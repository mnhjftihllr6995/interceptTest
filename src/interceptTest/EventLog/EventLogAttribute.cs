using System;

namespace interceptTest.EventLog;

/// <summary>
/// 日志记录器
/// </summary>

[AttributeUsage(AttributeTargets.Method)]
public class EventLogAttribute:Attribute
{
   
}