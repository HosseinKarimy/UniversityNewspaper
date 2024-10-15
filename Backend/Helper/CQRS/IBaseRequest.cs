using Helper.HelperModels;

namespace Helper.CQRS;

public interface IBaseRequestProps
{
    ImportantHttpContextCarrier ContextCarrier { get; set; }
}
