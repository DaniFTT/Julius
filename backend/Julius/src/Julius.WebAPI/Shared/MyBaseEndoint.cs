using Ardalis.ApiEndpoints;
using Ardalis.Result;
using MediatR;

namespace Julius.API.Shared
{
    public static class MyBaseEndpoint
    {
        public static class WithRequest<TRequest>
            where TRequest : class
        {
            public abstract class WithResult<TResponse> : EndpointBaseAsync.WithRequest<TRequest>.WithResult<TResponse>
                where TResponse : class
            {
                
            }
        }

        public static class WithoutRequest
        {
            public abstract class WithResult<TResponse> : EndpointBaseAsync.WithoutRequest.WithResult<TResponse>
                where TResponse : class
            {

            }
        }
    }
}
