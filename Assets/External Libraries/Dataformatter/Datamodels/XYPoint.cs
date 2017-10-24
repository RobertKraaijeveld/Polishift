using System;

using UnityEngine;

namespace Dataformatter.Datamodels
{
    public class XYPoint : IPoint
    {
        public float X { get; set; }
        public float Y { get; set; }

        public double EuclideanDistance(XYPoint otherPoint)
        {
            return Math.Sqrt(Math.Pow(this.X - otherPoint.X, 2) + Math.Pow(this.Y - otherPoint.Y, 2));
        }
        
        public override string ToString()
        {
            return X + " <> " + Y;
        }

        public Vector3 ToVector3()
        {
            return new Vector3 { x = this.X, y = this.Y };
        }
    }
}