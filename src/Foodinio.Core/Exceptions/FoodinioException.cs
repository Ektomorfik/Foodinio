using System;

namespace Foodinio.Core.Exceptions
{
    public class FoodinioException : Exception
    {
        public string Code { get; }

        protected FoodinioException()
        {
        }

        protected FoodinioException(string code)
        {
            Code = code;
        }

        protected FoodinioException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected FoodinioException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected FoodinioException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected FoodinioException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}