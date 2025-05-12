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

    public static object FromRequestResult(object result)
    {
        if (result is null) return new { IsSuccess = false, Message = "Null result" };

        var type = result.GetType();
        var isPaginated = type.IsGenericType &&
                          type.GetGenericTypeDefinition() == typeof(PaginatedResult<>);

        if (isPaginated)
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

        if (result is RequestResult<dynamic> dynResult)
        {
            return new
            {
                dynResult.IsSuccess,
                dynResult.Data,
                dynResult.Message
            };
        }

        return new { IsSuccess = false, Message = "Unknown result type" };
    }


}
