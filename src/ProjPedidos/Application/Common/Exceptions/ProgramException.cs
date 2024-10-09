using ProjPedidos.Domain.Constants;

namespace ProjPedidos.Application.Common.Exceptions;

public static class ProgramException
{
    public static UserFriendlyException AppsettingNotSetException()
        => new(ErrorCode.Internal, ErrorMessage.AppConfigurationMessage, ErrorMessage.Internal);
}
