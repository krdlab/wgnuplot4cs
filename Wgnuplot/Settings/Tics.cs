using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// 目盛り表示指定
    /// </summary>
    public class Tics
    {
        private Dictionary<String, double> map;

        private double? from;
        private double step;
        private double? to;

        /// <summary>
        /// 増分を指定して作成する．
        /// </summary>
        /// <param name="step">増分</param>
        public Tics(double step)
            : this(null, step, null)
        { }

        /// <summary>
        /// 開始値と増分を指定して作成する．
        /// </summary>
        /// <param name="from">開始</param>
        /// <param name="step">増分</param>
        public Tics(double from, double step)
            : this(from, step, null)
        { }

        /// <summary>
        /// 開始値/増分/終了値を指定して作成する．
        /// </summary>
        /// <param name="from">開始</param>
        /// <param name="step">増分</param>
        /// <param name="to">終了</param>
        public Tics(double? from, double step, double? to)
        {
            this.map = null;
            this.from = from;
            this.step = step;
            this.to = to;
        }

        public Tics(Dictionary<String, double> map)
            : this(null, -1, null)
        {
            Debug.Assert(map != null);
            this.map = map;
        }

        /// <summary>
        /// 開始値を設定/取得する．
        /// </summary>
        public double? From
        {
            set { this.from = value; }
            get { return this.from; }
        }

        /// <summary>
        /// 増分を設定/取得する．
        /// </summary>
        public double Step
        {
            set { this.step = value; }
            get { return this.step; }
        }

        /// <summary>
        /// 終了値を設定/取得する．
        /// </summary>
        public double? To
        {
            set { this.to = value; }
            get { return this.to; }
        }

        public override string ToString()
        {
            if (this.map != null)
            {
                String ret = "(";
                foreach (KeyValuePair<String, double> pair in this.map)
                {
                    ret += String.Format("\"{0}\" {1},", pair.Key, pair.Value);
                }
                ret = ret.Remove(ret.Length - ",".Length) + ")";
                return ret;
            }
            else
            {
                String ret = "";
                if (From.HasValue)
                {
                    ret += From + ",";
                    // "from,"
                }
                ret += Step;
                // "from,step" or "step"
                if (From.HasValue && To.HasValue)
                {
                    ret += "," + To;
                    // "from,step,to"
                }
                // "from,step,to" or "from,step" or "step"
                return ret;
            }
        }
    }
}
