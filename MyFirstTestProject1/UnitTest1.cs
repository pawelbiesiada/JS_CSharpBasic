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


            //Assert.That(new Car(5).Distance == 0);
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


        // czy metoda drive z wartością ujemną rzuci błędem
    }
}
