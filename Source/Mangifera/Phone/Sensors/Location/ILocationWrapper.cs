namespace Mangifera.Phone.Sensors.Location
{
    public interface ILocationWrapper
    {
        void Start();
        void Stop();
        LocationReading GetReading();
    }
}