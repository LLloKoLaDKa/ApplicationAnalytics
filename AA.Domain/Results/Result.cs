using System;

namespace AA.Domain.Results
{
    public class Result
    {
        public String? Error { get; }
        public Object? Data { get; set; }

        public Boolean IsSuccess => Error is null;

        private Result(String? error)
        {
            Error = error;
        }

        private Result(Object? @object)
        {
            Data = @object;
        }

        public static Result Fail(String error) => new Result(error);
        public static Result Success(Object @object = null) => new Result(@object);
    }
}
