using Julius.Domain.CategoryAggregate;

namespace Julius.API.Shared
{
    public static class Routes
    {
        private const string BaseUri = "api";

        public const string CategoryUri = $"{BaseUri}/{nameof(Category)}";
    }
}
