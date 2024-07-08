using System.Diagnostics.Contracts;

namespace ShipCrewsRefAutoBlazorApp
{
    /// <summary>
    /// Service Response
    /// Simon: Because I don't know better yet
    /// </summary>
    public class SimpleResponse
    {
        /// <summary>
        /// Whether this indicates success of failure
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                return isSuccess;
            }
            set
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                Contract.Ensures(IsValid, "The combination of allowable values is incorrect.");
                if (value)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                    if (error == null)
                    {
                        error = string.Empty;
                    }
                }
                System.Diagnostics.Debug.Assert(IsValid, "The combination of allowable values is incorrect.");
            }
        }

        /// <summary>
        /// The text associated with a failure.
        /// </summary>
        public string? Error
        {
            get
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                return error;
            }
            set
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                Contract.Ensures(IsValid, "The combination of allowable values is incorrect.");
                error = value;
                System.Diagnostics.Debug.Assert(IsValid, "The combination of allowable values is incorrect.");
            }
        }

        public bool IsValid
        {
            get
            {
                return
                    (isSuccess && error == null) ||
                    (!isSuccess && error != null);
            }
        }

        private bool isSuccess = true;
        private string? error = null;
    }
}
