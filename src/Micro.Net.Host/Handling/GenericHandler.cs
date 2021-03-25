using System;
using System.Threading.Tasks;

namespace Micro.Net
{
    public class GenericHandler<TRequest, TResponse> : IHandle<TRequest,TResponse> where TRequest : IContract<TResponse>
    {
        private readonly Func<TRequest, HandlerContext, Task<TResponse>> _predicate;

        public GenericHandler(Func<TRequest, HandlerContext, Task<TResponse>> predicate)
        {
            _predicate = predicate;
        }

        public async Task<TResponse> Handle(TRequest message, HandlerContext context)
        {
            return await _predicate(message,context);
        }
    }
}