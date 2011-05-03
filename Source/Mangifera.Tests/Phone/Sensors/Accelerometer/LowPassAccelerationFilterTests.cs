using Mangifera.Phone.Sensors.Accelerometer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mangifera.Tests.Phone.Sensors.Accelerometer
{
    [TestClass]
    public class LowPassAccelerationFilterTests
    {
        [TestMethod]
        public void CoefficientOneReturnsInput()
        {
            var filter = new LowPassAccelerationFilter(1);

            var firstVector = new Vector3D(2, 4, 6);
            var output1 = filter.ApplyFilter(firstVector);
            Assert.AreEqual(firstVector, output1);

            var secondVector = new Vector3D(1, 4, 3);
            var output2 = filter.ApplyFilter(secondVector);

            Assert.AreEqual(secondVector, output2);
        }

        [TestMethod]
        public void CoefficientZeroReturnsInitialValue()
        {
            var filter = new LowPassAccelerationFilter(0);

            var firstVector = new Vector3D(2, 4, 6);
            var output1 = filter.ApplyFilter(firstVector);
            Assert.AreEqual(new Vector3D(), output1);

            var secondVector = new Vector3D(1, 4, 3);
            var output2 = filter.ApplyFilter(secondVector);

            Assert.AreEqual(new Vector3D(), output2);
        }

        
        [TestMethod]
        public void CoefficientHalfSmoothesValues()
        {
            var filter = new LowPassAccelerationFilter(0.5);

            var firstVector = new Vector3D(2, 4, 6);
            var output1 = filter.ApplyFilter(firstVector);
            Assert.AreEqual(new Vector3D(1, 2, 3), output1);

            var secondVector = new Vector3D(1, 4, 3);
            var output2 = filter.ApplyFilter(secondVector);

            Assert.AreEqual(new Vector3D(1, 3, 3), output2);
        }
    }
}