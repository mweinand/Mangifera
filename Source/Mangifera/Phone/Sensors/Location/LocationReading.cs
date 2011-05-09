using System;

namespace Mangifera.Phone.Sensors.Location
{
    public class LocationReading
    {
        public DateTimeOffset Timestamp { get; set; }
        public double Altitude { get; set; }
        public double Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}