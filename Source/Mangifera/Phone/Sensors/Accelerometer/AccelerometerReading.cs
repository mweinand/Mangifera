using System;

namespace Mangifera.Phone.Sensors.Accelerometer
{
    public class AccelerometerReading
    {
        public DateTimeOffset Timestamp { get; set; }
        public Vector3D Reading { get; set; }
    }
}