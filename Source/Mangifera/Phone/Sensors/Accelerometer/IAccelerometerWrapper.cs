namespace Mangifera.Phone.Sensors.Accelerometer
{
    public interface IAccelerometerWrapper
    {
        void Start();
        void Stop();
        AccelerometerReading GetReading();
    }
}