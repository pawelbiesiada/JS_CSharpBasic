using BasicCSharpConsoleNET.Samples.Class;
using System.ComponentModel.DataAnnotations;

namespace MyFirstTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        // czy można utworzyć obiekt Car  z wartością ujemną
        [Test]
        public void CanCarBeInitializedWithNegativeSpeedValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => { new Car(-5); });

        }
        [Test]
        public void CanCarBeInitializedWithPositiveSpeedValue()
        {
            Assert.DoesNotThrow(
                () => { new Car(5); });
        }


        [Test]
        public void IsCarInitializedWithZeroDistance()
        {
            var car = new Car(50);

            Assert.That(car.Distance == 0);
        }

        // Czy metoda drive poprawnie zwiekszy Distance
        [Test]
        public void DriveShouldIncreaseDistance()
        {
            Car car = new Car(30);

            car.Drive(10);

            Assert.That(car.Distance, Is.EqualTo(300));
        }
        [Test]
        public void MultipleDriveExecutionShouldIncreaseDistance()
        {
            Car car = new Car(30);

            car.Drive(10);
            car.Drive(10);

            Assert.That(car.Distance, Is.EqualTo(600));
        }

        // czy metoda drive z wartością ujemną rzuci błędem
        [Test]
        public void CanDriveBeExecutedNegativeSpeedValue()
        {
            var car = new Car(5);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => { car.Drive(-3); });


            //Assert.That(new Car(5).Distance == 0);
        }
    }
}
