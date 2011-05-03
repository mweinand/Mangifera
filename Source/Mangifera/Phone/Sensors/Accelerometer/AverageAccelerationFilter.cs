using System;
using System.Collections.Generic;
using System.Linq;

namespace Mangifera.Phone.Sensors.Accelerometer
{
    public class AverageAccelerationFilter : IAccelerationFilter
    {
        private readonly int _queueLength;
        private readonly Queue<Vector3D> _queue;

        public AverageAccelerationFilter(int queueLength)
        {
            _queueLength = queueLength;
            _queue = new Queue<Vector3D>(queueLength);
        }

        public Vector3D ApplyFilter(Vector3D inputVector)
        {
            _queue.Enqueue(inputVector);

            var output = new Vector3D
                             {
                                 X = _queue.Average(v => v.X),
                                 Y = _queue.Average(v => v.Y),
                                 Z = _queue.Average(v => v.Z)
                             };

            if (_queue.Count > _queueLength)
            {
                _queue.Dequeue();
            }

            return output;
        }
    }
}