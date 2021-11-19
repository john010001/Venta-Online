using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application.Common
{
    public interface IResult
    {
        bool HasSucceeded { get; }
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
    }

    public abstract class Result : IResult
    {
        public bool HasSucceeded { get; protected set; }
    }

    public class SuccessResult : IResult
    {
        public SuccessResult()
        {
            HasSucceeded = true;
        }
        public bool HasSucceeded { get; private set; }
    }

    public class SuccessResult<T> : IResult<T>
    {
        public SuccessResult() => HasSucceeded = true;
        public SuccessResult(T value) : this() => Value = value;
        public T Value { get; }

        public bool HasSucceeded { get; }
    }

    public class FailureResult : IResult
    {
        private readonly IEnumerable<FailureDetail> failureDetails;

        public FailureResult() => HasSucceeded = false;

        public FailureResult(IEnumerable<FailureDetail> failureDetails) : this()
        {
            this.failureDetails = failureDetails;
        }

        public FailureResult(string message)
        {
            this.failureDetails = new[] { new FailureDetail(message) };
        }

        public bool HasSucceeded { get; }

        public IEnumerable<FailureDetail> GetFailureDetails()
        {
            return failureDetails;
        }
    }

    public class FailureResult<T> : FailureResult, IResult<T>
    {
        public FailureResult(IEnumerable<FailureDetail> failureDetails) : base(failureDetails)
        {
        }       

        public FailureResult(string message) : base(message) { }

        public T Value { get; }
    }

    public class FailureDetail
    {
        public FailureDetail(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
