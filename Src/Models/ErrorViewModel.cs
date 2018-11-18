using System;

namespace SamMiller.Mumba.Models
{
    /// <summary>
    /// Models an error that occurs
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// The id of the request
        /// </summary>
        /// <value></value>
        public string RequestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}