using System;

namespace Mangifera.Phone.Sensors.Accelerometer
{
    public class LowPassAccelerationFilter : IAccelerationFilter
    {
        private Vector3D _lastValue;
        private readonly double _coefficient;

        public LowPassAccelerationFilter(double coefficient)
        {
            _coefficient = coefficient;
        }

        public Vector3D ApplyFilter(Vector3D inputVector)
        {
            var newValue = _lastValue + _coefficient*(inputVector - _lastValue);
            _lastValue = newValue;
            return _lastValue;
        }
    }
}