using System;
using System.Collections.Generic;
using DeskBooker.Core.Domain;

namespace DeskBooker.Core.Interface
{
    public interface IDeskRepository
    {
        IEnumerable<Desk> GetAvailableDesk(DateTime date);
    }
}
