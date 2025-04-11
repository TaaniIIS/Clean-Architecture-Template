using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Response
{
    /// <summary>
    /// Generic response wrapper for service, command, and query results.
    /// Includes success state, messages, validation errors, and response data.
    /// </summary>
    /// <typeparam name="T">Type of the response data.</typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Default constructor sets Success to true.
        /// </summary>
        public BaseResponse() => Success = true;

        /// <summary>
        /// Constructor to initialize with a message and success flag.
        /// </summary>
        /// <param name="message">Response message.</param>
        /// <param name="success">Was the operation successful?</param>
        public BaseResponse(string message, bool success = true)
        {
            Success = success;
            Message = message;
        }

        /// <summary>
        /// Indicates whether the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Optional message describing the result.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Optional list of validation errors (used for failed validations).
        /// </summary>
        public List<string>? ValidationErrors { get; set; }

        /// <summary>
        /// Optional payload data returned with the response.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Static helper to create a successful response with message and data.
        /// </summary>
        /// <param name="message">Response message.</param>
        /// <param name="data">Payload data of type T.</param>
        /// <returns>A successful BaseResponse with data.</returns>
        public static BaseResponse<T> SuccessResult(string message, T data)
            => new BaseResponse<T>(message)
            {
                Data = data,
                Success = true
            };

        /// <summary>
        /// Static helper to create a failed response with message and optional validation errors.
        /// </summary>
        /// <param name="message">Response message.</param>
        /// <param name="errors">Optional list of validation errors.</param>
        /// <returns>A failed BaseResponse with validation errors.</returns>
        public static BaseResponse<T> FailureResult(string message, List<string>? errors = null)
            => new BaseResponse<T>(message, false)
            {
                ValidationErrors = errors
            };
    }




    //public class BaseResponse
    //{
    //    public BaseResponse()
    //    {
    //        Success = true;
    //    }
    //    public BaseResponse(string message)
    //    {
    //        Success = true;
    //        Message = message;
    //    }
    //    public BaseResponse(string message, bool success)
    //    {
    //        Success = success;
    //        Message = message;
    //    }
    //    public bool Success { get; set; }
    //    public string Message { get; set; }
    //    public List<string>? ValidationErrors { get; set; }
    //}
}
