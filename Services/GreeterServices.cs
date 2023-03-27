using System;
using Contracts;
using ServiceStack;

namespace MyGrpcProject.ServiceInterface
{
    public class GreeterServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
