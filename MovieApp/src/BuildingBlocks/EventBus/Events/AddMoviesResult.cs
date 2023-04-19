using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events
{
    public record AddMoviesResult
    {
        public bool Status { get; init; }
    }
}
