namespace Mangifera.Phone.Sensors.Accelerometer
{
    /// <summary>
    /// An interface to filter acceleration vector data
    /// </summary>
    public interface IAccelerationFilter
    {
        Vector3D ApplyFilter(Vector3D inputVector);
    }
}
