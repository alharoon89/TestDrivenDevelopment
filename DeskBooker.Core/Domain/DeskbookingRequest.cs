using System;

namespace DeskBooker.Core.Domain
{
    public class DeskbookingRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}