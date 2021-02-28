using FluentValidation.Results;
using MediatR;
using System;

namespace FastFeet.API.Messages
{
    public class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public Command()
        {
            Timestamp = DateTime.Now;
        }
        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
