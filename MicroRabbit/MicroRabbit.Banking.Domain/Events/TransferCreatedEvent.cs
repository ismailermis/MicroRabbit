﻿using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Events
{
    public class TransferCreatedEvent:Event
    {
        public int From {get;private set;}
        public int To {get;private set;}
        public decimal Amount {get;private set;}
        public bool IsEndPublish { get; set; }

        public TransferCreatedEvent(int from,int to, decimal amount,bool isEndPublish)
        {
            From = from;
            To = to;
            Amount = amount;
            IsEndPublish=isEndPublish;
        }

    }
}
