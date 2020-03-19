using DeskBooker.Core.Domain;
using DeskBooker.Core.Interface;
using Moq;
using System;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTest
    {
        private readonly Mock<IDeskBookingRepository> _deskBookingRepository;
        private readonly DeskBookingRequestProcessor _processor;
        private readonly DeskBookingRequest _request;
        public DeskBookingRequestProcessorTest()
        {
            _deskBookingRepository = new Mock<IDeskBookingRepository>();
            this._processor = new DeskBookingRequestProcessor(_deskBookingRepository.Object);
            _request = new DeskBookingRequest()
            {
                FirstName = "Ali",
                LastName = "Raza",
                Email = "Test@abc.com",
                Date = new DateTime(2020, 3, 25)
            };
        }

        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            DeskBookingResult result = _processor.BookDesk(_request);

            Assert.NotNull(_request);
            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveDeskBooking()
        {
            DeskBooking savedDeskBooking = null;
            _deskBookingRepository.Setup(x => x.Save(It.IsAny<DeskBooking>()))
                .Callback<DeskBooking>(deskBooking => { savedDeskBooking = deskBooking; });
            _processor.BookDesk(_request);

            _deskBookingRepository.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Once);

            Assert.NotNull(savedDeskBooking);
            Assert.Equal(_request.FirstName, savedDeskBooking.FirstName);
            Assert.Equal(_request.LastName, savedDeskBooking.LastName);
            Assert.Equal(_request.Email, savedDeskBooking.Email);
            Assert.Equal(_request.Date, savedDeskBooking.Date);
        }

    }
}
