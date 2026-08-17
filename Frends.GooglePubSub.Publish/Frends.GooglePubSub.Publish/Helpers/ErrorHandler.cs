using System;
using System.Collections.Generic;
using Frends.GooglePubSub.Publish.Definitions;

namespace Frends.GooglePubSub.Publish.Helpers;

internal static class ErrorHandler
{
    internal static Result Handle(this Exception exception, Options options, List<string> messageIds = null, List<MessagePublishingError> errors = null, bool throwCanceled = true)
    {
        ThrowIfCanceled(exception, throwCanceled);
        if (options.ThrowErrorOnFailure) ThrowBaseException(exception, options.ErrorMessageOnFailure);

        return ReturnResult(exception, options.ErrorMessageOnFailure, messageIds, errors);
    }

    private static void ThrowIfCanceled(Exception exception, bool throwCanceled = true)
    {
        if (throwCanceled && exception is OperationCanceledException) throw exception;
    }

    private static void ThrowBaseException(Exception exception, string customMessage = null)
    {
        if (string.IsNullOrEmpty(customMessage))
            throw new Exception(exception.Message, exception);

        throw new Exception(customMessage, exception);
    }

    private static Result ReturnResult(Exception exception, string customMessage = null, List<string> messageIds = null, List<MessagePublishingError> errors = null)
    {
        var errorMessage = string.IsNullOrEmpty(customMessage)
            ? exception.Message
            : $"{customMessage}: {exception.Message}";

        return new Result
        {
            Success = false,
            Error = new Error
            {
                Message = errorMessage,
                AdditionalInfo = exception,
            },
            MessageIDs = messageIds,
            Errors = errors,
        };
    }
}
