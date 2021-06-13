﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace IRL.EventSourcing.Commands.Common
{
    public class CommandResponse<T>
    {
        public CommandResponse()
        {
            this.Payload = (T)Activator.CreateInstance(typeof(T));
        }

        public CommandResponse(ICollection<string> errors)
        {
            Errors = errors;
        }

        public T Payload { get; set; }
        public ICollection<string> Errors { get; set; } = new List<string>();
        public bool IsSuccess => !Errors.Any();

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}