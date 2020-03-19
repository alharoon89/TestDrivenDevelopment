using System;
using System.Linq;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Interface;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        private readonly IDeskBookingRepository _deskBookingRepository;
        private readonly IDeskRepository _deskRepository;

        public DeskBookingRequestProcessor(IDeskBookingRepository deskBookingRepository, IDeskRepository deskRepository)
        {
            _deskBookingRepository = deskBookingRepository;
            _deskRepository = deskRepository;
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var availableDesk = _deskRepository.GetAvailableDesk(request.Date);

            if (availableDesk.Count() > 0)
            {
                var deskBooKing = Create<DeskBooking>(request);
                deskBooKing.DeskId = availableDesk.First().Id;
                _deskBookingRepository.Save(deskBooKing);
            }

            return Create<DeskBookingResult>(request);

        }

        private T Create<T>(DeskBookingRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };
        }
    }
}