using Contracts;
using ServiceStack;

namespace Services
{
    public class GreeterServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
