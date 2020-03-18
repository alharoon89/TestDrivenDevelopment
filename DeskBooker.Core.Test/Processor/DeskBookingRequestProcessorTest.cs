using DeskBooker.Core.Domain;
using System;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTest
    {
        private readonly DeskBookingRequestProcessor processor;

        public DeskBookingRequestProcessorTest()
        {
            this.processor = new DeskBookingRequestProcessor();
        }

        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            var request = new DeskbookingRequest()
            {
                FirstName = "Ali",
                LastName = "Raza",
                Email = "Test@abc.com",
                Date = new DateTime(2020, 3, 25)
            };
           
         //   var processor = new DeskBookingRequestProcessor();

            DeskBookingResult result = processor.BookDesk(request);

            Assert.NotNull(request);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception =  Assert.Throws<ArgumentNullException>(() => processor.BookDesk(null));
            Assert.Equal("request", exception.ParamName);
        }
    }
}
