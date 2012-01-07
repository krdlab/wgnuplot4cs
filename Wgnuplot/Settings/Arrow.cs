using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    public class Arrow
    {
        private readonly int index;
        private readonly Point2D from;
        private readonly Point2D to;

        public Arrow(Point2D from, Point2D to)
            : this(-1, from, to)
        { }

        public Arrow(int index, Point2D from, Point2D to)
        {
            this.index = index;
            this.from = from;
            this.to = to;
        }

        public int Index
        {
            get { return this.index; }
        }

        public Point2D From
        {
            get { return this.from; }
        }

        public Point2D To
        {
            get { return this.to; }
        }

        public override string ToString()
        {
            if (Index < 0)
            {
                return "from " + From + " to " + To;
            }
            else
            {
                return Index + " from " + From + " to " + To;
            }
        }
    }
}
