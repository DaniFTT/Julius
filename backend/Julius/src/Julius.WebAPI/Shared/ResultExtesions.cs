using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Julius.API.Shared;

public static class ResultExtensions
{
    public static ResultHandler<T> Handle<T>(this Result<T> result)
    {
        return new ResultHandler<T>(result);
    }
}

