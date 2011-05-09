using System;
using System.Device.Location;

namespace Mangifera.Phone.Sensors.Location
{
    public class LocationWrapper : ILocationWrapper
    {
        private readonly GeoCoordinateWatcher _watcher;
        private LocationReading _lastReading;
        private GeoPositionStatus _status;

        public LocationWrapper()
        {
            _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default) {MovementThreshold = 0.1};
            _watcher.StatusChanged += WatcherStatusChanged;
            _watcher.PositionChanged += WatcherPositionChanged;
        }

        private void WatcherPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            _lastReading = new LocationReading
                               {
                                   Altitude = e.Position.Location.Altitude,
                                   Latitude = e.Position.Location.Latitude,
                                   Longitude = e.Position.Location.Longitude,
                                   Speed = e.Position.Location.Speed,
                                   Timestamp = e.Position.Timestamp
                               };
        }

        private void WatcherStatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            _status = e.Status;
        }

        public void Start()
        {
            _watcher.Start();
        }

        public void Stop()
        {
            _watcher.Stop();
        }

        public LocationReading GetReading()
        {
            if(_status != GeoPositionStatus.Ready)
            {
                throw new Exception("Could not get location data. Please check the status.");
            }
            return _lastReading;
        }
    }
}