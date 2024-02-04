using TableReservationApp;

namespace TableReservationAppTest
{
    public class TableTest
    {
        private Table table;
        [SetUp]
        public void Setup()
        {
            table = new Table();
        }

        [Test]
        public void IsBooked_WhenDateIsBooked_ReturnsTrue()
        {
            DateTime bookedDate = new DateTime(2024, 2, 4);
            table.Book(bookedDate);

            bool result = table.IsBooked(bookedDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBooked_WhenDateIsNotBooked_ReturnsFalse()
        {
            DateTime bookedDate = new DateTime(2024, 2, 4);
            DateTime notBookedDate = new DateTime(2024, 2, 5);
            table.Book(bookedDate);

            bool result = table.IsBooked(notBookedDate);

            Assert.IsFalse(result);
        }
    }
}