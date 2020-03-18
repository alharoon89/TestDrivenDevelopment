using DeskBooker.Core.Domain;

namespace DeskBooker.Core.Interface
{
    public interface IDeskBookingRepository
    {
        void Save(DeskBooking deskBooking);
    }
}
