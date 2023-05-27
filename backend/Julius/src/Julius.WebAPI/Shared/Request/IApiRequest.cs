using Julius.Application.Abstractions;
using Julius.SharedKernel;

namespace Julius.API.Shared.Request
{
    public interface IApiRequest<T, Q> where T : ICommand<Q>  where Q : EntityBase
    {
        public T ToCommand();
    }
}
