using System;
using System.Collections.Generic;
using System.Text;
using Application.Packages.AOP.Interceptor;
using Castle.DynamicProxy;

namespace Application.Packages.AOP.Aspects.Exception
{
    /// <summary>
    /// AsminExceptionAspect works when method is throwing exception
    /// </summary>
    public class ExceptionAspect : MethodInterceptor
    {
        public override void OnException(IInvocation invocation, System.Exception exception)
        {
            Console.WriteLine($"[AppExceptionAspect] {exception}");
        }
    }
}
