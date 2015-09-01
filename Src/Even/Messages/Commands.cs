﻿using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even.Messages
{
    // base messages
    public abstract class CommandMessage
    {
        public Guid CommandID { get; set; }
    }

    /// <summary>
    /// Represents a request to send a command to a specific aggregate
    /// </summary>
    public class CommandRequest : CommandMessage
    {
        public string StreamID { get; set; }
        public object Command { get; set; }
        public int Retries { get; set; }
    }

    public class CommandResponse : CommandMessage
    { }

    public class TypedCommandRequest : CommandRequest
    {
        public Type AggregateType { get; set; }
    }

    /// <summary>
    /// Indicates the command was applied successfully.
    /// </summary>
    public class CommandSucceeded : CommandResponse
    { }

    /// <summary>
    /// Indicates the command failed for some reason.
    /// </summary>
    public class CommandFailed : CommandResponse
    {
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// Indicates the command timed out.
    /// </summary>
    public class CommandTimedout : CommandResponse
    { }

    public class CommandRefused : CommandResponse
    {
        public CommandRequest CommandRequest { get; set; }
        public string Reason { get; set; }
    }

}
