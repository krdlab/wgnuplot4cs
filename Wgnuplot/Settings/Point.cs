using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    public struct Point2D
    {
        private double x;
        private double y;

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            set { this.x = value; }
            get { return this.x; }
        }

        public double Y
        {
            set { this.y = value; }
            get { return this.y; }
        }

        public override string ToString()
        {
            return X + ", " + Y;
        }
    }
}
