using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Interceptors;
using MyLibrary;

IContainer BuildContainer()
{
    var builder = new ContainerBuilder();
    builder
        .RegisterInstance(Console.Out).As<TextWriter>();
    builder
        .RegisterType<CallInterceptor>();
    builder
        .RegisterType<Subject>().As<ISubject>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(CallInterceptor));
    return builder.Build();
}

var container = BuildContainer();

var subject = container.Resolve<ISubject>();

subject.DoNothing();