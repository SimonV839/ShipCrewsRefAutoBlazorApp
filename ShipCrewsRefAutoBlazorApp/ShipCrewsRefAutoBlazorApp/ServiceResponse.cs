using System.Diagnostics.Contracts;

namespace ShipCrewsRefAutoBlazorApp
{
    /// <summary>
    /// Service Response
    /// Simon: Because I don't know better yet
    /// </summary>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Whether this indicates success of failure
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                return simpleResponse.IsSuccess;
            }
            set
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                Contract.Ensures(IsValid, "The combination of allowable values is incorrect.");
                if (value)
                {
                    simpleResponse.IsSuccess = true;
                }
                else
                {
                    simpleResponse.IsSuccess = false;
                    item = default;
                }
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
                return simpleResponse.Error;
            }
            set
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                Contract.Ensures(IsValid, "The combination of allowable values is incorrect.");
                simpleResponse.Error = value;
            }
        }

        /// <summary>
        /// The time associated with success.
        /// </summary>
        public T? Item 
        {
            get
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                return item;
            }
            set
            {
                Contract.Requires(IsValid, "The combination of allowable values is incorrect.");
                Contract.Ensures(IsValid, "The combination of allowable values is incorrect.");
                item = value;
                System.Diagnostics.Debug.Assert(IsValid, "The combination of allowable values is incorrect.");
            }
        }

        private bool IsValid
        {
            get
            {
                return
                    (simpleResponse.IsSuccess && !EqualityComparer<T>.Default.Equals(item, default)) ||
                    (!simpleResponse.IsSuccess && EqualityComparer<T>.Default.Equals(item, default));
            }
        }

        SimpleResponse simpleResponse = new SimpleResponse();
        private T? item;
    }
}
