using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// �ڐ���\���w��
    /// </summary>
    public class Tics
    {
        private Dictionary<String, double> map;

        private double? from;
        private double step;
        private double? to;

        /// <summary>
        /// �������w�肵�č쐬����D
        /// </summary>
        /// <param name="step">����</param>
        public Tics(double step)
            : this(null, step, null)
        { }

        /// <summary>
        /// �J�n�l�Ƒ������w�肵�č쐬����D
        /// </summary>
        /// <param name="from">�J�n</param>
        /// <param name="step">����</param>
        public Tics(double from, double step)
            : this(from, step, null)
        { }

        /// <summary>
        /// �J�n�l/����/�I���l���w�肵�č쐬����D
        /// </summary>
        /// <param name="from">�J�n</param>
        /// <param name="step">����</param>
        /// <param name="to">�I��</param>
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
        /// �J�n�l��ݒ�/�擾����D
        /// </summary>
        public double? From
        {
            set { this.from = value; }
            get { return this.from; }
        }

        /// <summary>
        /// ������ݒ�/�擾����D
        /// </summary>
        public double Step
        {
            set { this.step = value; }
            get { return this.step; }
        }

        /// <summary>
        /// �I���l��ݒ�/�擾����D
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
