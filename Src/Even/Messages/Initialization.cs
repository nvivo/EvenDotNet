﻿using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even.Messages
{
    public class InitializeEventStoreReader
    {
        public ICryptoService CryptoService { get; set; }
        public IDataSerializer Serializer { get; set; }
        public IStreamStoreReader StoreReader { get; set; }
    }

    public class InitializeEventStoreWriter
    {
        public ICryptoService CryptoService { get; set; }
        public IDataSerializer Serializer { get; set; }
        public IStreamStoreWriter StoreWriter { get; set; }
    }

    public class InitializeCommandProcessorSupervisor
    {
        public IActorRef Writer { get; set; }
        public IActorRef Reader { get; set; }
    }

    public class InitializeEventProcessorSupervisor
    {
        public IActorRef ProjectionStreamSupervisor { get; set; }
    }

    public class InitializeProjectionStreams
    {
        public IActorRef Reader { get; set; }
        public IActorRef Writer { get; set; }
    }

    public class InitializeCommandProcessor
    {
        public IActorRef CommandProcessorSupervisor { get; set; }
        public IActorRef Writer { get; set; }
    }

    public class InitializeAggregate
    {
        public string StreamID { get; set; }
        public IActorRef Reader { get; set; }
        public IActorRef Writer { get; set; }
        public IActorRef CommandProcessorSupervisor { get; set; }
    }

    public class AggregateInitializationState
    {
        public bool Initialized { get; set; }
        public string InitializationFailureReason { get; set; }
    }

    public class WillStop { }

    public class InitializeProjectionStream
    {
        public ProjectionQuery Query { get; set; }
        public IActorRef Reader { get; set; }
        public IActorRef Writer { get; set; }
    }

    public class InitializeAggregateReplayWorker
    {
        public ReplayAggregateRequest Request { get; set; }
        public IActorRef ReplyTo { get; set; }
        public InitializeEventStoreReader ReaderInitializer { get; set; }
    }

    public class StartEventProcessor
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }

    public class InitializeEventProcessor
    {
        public IActorRef ProjectionStreamSupervisor { get; set; }
    }
}
