using Helper.CQRS;

namespace Helper.JsuServerResponse;

public static class JsuContractTemplate
{
    public static object GetContractTemplate(bool isSuccess, object? data = null, string? message = null)
    {
        return
            new
            {
                isSuccess,
                data,
                message
            };
    }

    public static object FromRequestResult<T>(RequestResult<T> result)
    {
        if (result is null) return new { IsSuccess = false, Message = "Null result" };

        if (result.GetType().GetGenericTypeDefinition() == typeof(PaginatedResult<>))
        {
            dynamic dyn = result;
            return new
            {
                dyn.IsSuccess,
                dyn.Data,
                dyn.Message,
                dyn.Page,
                dyn.PageSize
            };
        }

        return new
        {
            result.IsSuccess,
            result.Data,
            result.Message
        };
    }


}
