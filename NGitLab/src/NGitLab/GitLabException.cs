using System;
#if !(NETSTANDARD1_5 || NETSTANDARD1_6)
    using System.Runtime.Serialization;
#endif
using NGitLab.Models;

namespace NGitLab.Impl
{
#if !(NETSTANDARD1_5 || NETSTANDARD1_6)
    [Serializable]
#endif
    public class GitLabException : Exception
    {
        private Error errorMessage;

        public GitLabException()
        {
        }

        public GitLabException(string message) : base(message)
        {
        }

        public GitLabException(Error errorMessage) :this(errorMessage.Message)
        {
            this.errorMessage = errorMessage;
        }

        public GitLabException(string message, Exception innerException) : base(message, innerException)
        {
        }
#if !(NETSTANDARD1_5 || NETSTANDARD1_6)
        protected GitLabException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#endif
    }
}