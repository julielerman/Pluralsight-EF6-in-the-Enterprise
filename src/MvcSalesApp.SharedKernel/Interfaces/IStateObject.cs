using MvcSalesApp.SharedKernel.Enums;

namespace MvcSalesApp.SharedKernel.Interfaces
{
  public interface IStateObject
  {
    ObjectState State { get; }
  }
}