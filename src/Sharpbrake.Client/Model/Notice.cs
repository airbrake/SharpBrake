﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sharpbrake.Client.Model
{
    /// <summary>
    /// Object to send to the Airbrake endpoint.
    /// </summary>
    [DataContract]
    public sealed class Notice
    {
        /// <summary>
        /// A list of <see cref="ErrorEntry"/> objects that describe the error.
        /// </summary>
        [DataMember(Name = "errors", EmitDefaultValue = false)]
        public IList<ErrorEntry> Errors { get; set; }

        /// <summary>
        /// Additional context for the error.
        /// </summary>
        [DataMember(Name = "context", EmitDefaultValue = false)]
        public Context Context { get; set; }

        /// <summary>
        /// Environment variables at the time when the error happens.
        /// </summary>
        /// <remarks>
        /// Key is the variable name, e.g. { "PORT": "443", "CODE_NAME": "gorilla" }
        /// </remarks>
        [DataMember(Name = "environment", EmitDefaultValue = false)]
        public IDictionary<string, string> EnvironmentVars { get; set; }

        /// <summary>
        /// Session variables at the time when the error happens.
        /// </summary>
        /// <remarks>
        /// Key is the variable name, e.g. { "basket_total": "1234", "user_id": "123" }
        /// </remarks>
        [DataMember(Name = "session", EmitDefaultValue = false)]
        public IDictionary<string, string> Session { get; set; }

        /// <summary>
        /// Request parameters at the time when the error happens.
        /// </summary>
        /// <remarks>
        /// Key is the parameter name, e.g. { "page": "3", "sort": "desc" }
        /// </remarks>
        [DataMember(Name = "params", EmitDefaultValue = false)]
        public IDictionary<string, string> Params { get; set; }

        /// <summary>
        /// The <see cref="Exception"/> object that the <see cref="Notice"/> is built for.
        /// </summary>
        /// <remarks>
        /// This object is not sent to Airbrake. You can use it to assess properties
        /// of original exception in your dynamic filters.
        /// </remarks>
        public Exception Exception { get; set; }

        /// <summary>
        /// The message describing the error.
        /// </summary>
        /// <remarks>
        /// Message is built from message template and zero or more properties using specified by
        /// <see cref="IFormatProvider"/> formatting information in <see cref="AirbrakeConfig"/>.
        /// Message is sent to Airbrake in the first <see cref="ErrorEntry"/> message.
        /// </remarks>
        public string Message { get; set; }

        /// <summary>
        /// The <see cref="IHttpContext"/> object that the <see cref="Notice"/> is built for.
        /// </summary>
        /// <remarks>
        /// This object is not sent to Airbrake. You can use it to assess HTTP context
        /// properties in your dynamic filters.
        /// </remarks>
        public IHttpContext HttpContext { get; set; }
    }
}
