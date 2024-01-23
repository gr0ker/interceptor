namespace InterceptorsTest;

using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Interceptors;
using MyLibrary;
using System.IO;

public class CallInterceptorShould
{
    [Fact]
    public void PrintMethodName()
    {
        var stringWriter = new StringWriter();
        var container = BuildContainer(stringWriter);
        var subject = container.Resolve<ISubject>();
        subject.DoNothing();
        Assert.Equal("Called Subject.DoNothing\r\nNothing is done\r\n", stringWriter.ToString());
    }

    private static IContainer BuildContainer(TextWriter writer)
    {
        var builder = new ContainerBuilder();
        builder
            .RegisterInstance(writer);
        builder
            .RegisterType<CallInterceptor>();
        builder
            .RegisterType<Subject>().As<ISubject>()
            .EnableInterfaceInterceptors().InterceptedBy(typeof(CallInterceptor));
        return builder.Build();
    }
}