using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.BarycentricInterpolation
{
    public class BarycentricTriangleInterpolator<TValue>
    {
        private readonly IVectorOperationsExecutor<float, TValue> _vectorOperationExecutor;

        public BarycentricTriangleInterpolator(
            Point position1, TValue value1,
            Point position2, TValue value2,
            Point position3, TValue value3,
            IVectorOperationsExecutor<float, TValue> vectorOperationExecutor)
        {
            Position1 = position1;
            Value1 = value1;
            Position2 = position2;
            Value2 = value2;
            Position3 = position3;
            Value3 = value3;
            _vectorOperationExecutor = vectorOperationExecutor;
        }

        public Point Position1 { get; }
        public TValue Value1 { get; }
        public Point Position2 { get; }
        public TValue Value2 { get; }
        public Point Position3 { get; }
        public TValue Value3 { get; }

        public TValue GetWeightInPoint(Point position)
        {
            // TODO: fix casting
            var weight1 = (float)((Position2.Y - Position3.Y) * (position.X - Position3.X) + (Position3.X - Position2.X) * (position.Y - Position3.Y))
                / ((Position2.Y - Position3.Y) * (Position1.X - Position3.X) + (Position3.X - Position2.X) * (Position1.Y - Position3.Y));
            var weight2 = (float)((Position3.Y - Position1.Y) * (position.X - Position3.X) + (Position1.X - Position3.X) * (position.Y - Position3.Y))
                / ((Position2.Y - Position3.Y) * (Position1.X - Position3.X) + (Position3.X - Position2.X) * (Position1.Y - Position3.Y));
            var weight3 = 1 - weight1 - weight2;

            return 
                _vectorOperationExecutor.Add(
                    _vectorOperationExecutor.Add(
                        _vectorOperationExecutor.Scale(Value1, weight1),
                        _vectorOperationExecutor.Scale(Value2, weight2)),
                    _vectorOperationExecutor.Scale(Value3, weight3));
        }
    }
}
