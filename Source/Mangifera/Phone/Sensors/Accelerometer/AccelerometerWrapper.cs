using System;

namespace Mangifera.Phone.Sensors.Accelerometer
{
    public class AccelerometerWrapper : IAccelerometerWrapper, IDisposable
    {
        private readonly Microsoft.Devices.Sensors.Accelerometer _accelerometer;
        private readonly IAccelerationFilter _accelerationFilter;
        private AccelerometerReading _lastReading;
        private bool _isRunning;

        public AccelerometerWrapper(IAccelerationFilter accelerationFilter)
        {
            _accelerometer = new Microsoft.Devices.Sensors.Accelerometer();
            _accelerometer.ReadingChanged += AccelerometerReadingChanged;
            _accelerationFilter = accelerationFilter;
        }

        private void AccelerometerReadingChanged(object sender, Microsoft.Devices.Sensors.AccelerometerReadingEventArgs e)
        {
            var vector = new Vector3D(e.X, e.Y, e.Z);
            var filteredVector = _accelerationFilter.ApplyFilter(vector);
            _lastReading = new AccelerometerReading
                               {
                                   Timestamp = e.Timestamp,
                                   Reading = filteredVector
                               };
        }

        public void Start()
        {
            _accelerometer.Start();
            _isRunning = true;
        }

        public void Stop()
        {
            _accelerometer.Stop();
            _isRunning = false;
        }

        public AccelerometerReading GetReading()
        {
            if(!_isRunning)
            {
                return null;
            }
            return _lastReading;
        }

        public void Dispose()
        {
            _accelerometer.Dispose();
        }
    }
}