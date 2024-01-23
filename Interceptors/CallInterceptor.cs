namespace Interceptors;

using System.IO;
using Castle.DynamicProxy;

public class CallInterceptor : IInterceptor
{
    private readonly StreamWriter _writer;

    public CallInterceptor(StreamWriter writer)
    {
        _writer = writer;
    }

    public void Intercept(IInvocation invocation)
    {
        _writer.WriteLine($"Called {invocation.TargetType.Name}.{invocation.Method.Name}");

        invocation.Proceed();
    }
}
