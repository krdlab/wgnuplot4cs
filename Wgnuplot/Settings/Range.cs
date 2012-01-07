using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// �͈͎w��
    /// </summary>
    public class Range
    {
        private double from;
        private double to;

        /// <summary>
        /// �͈� (���) ���w�肵�č쐬����D
        /// </summary>
        /// <param name="from">�J�n�_</param>
        /// <param name="to">�I���_</param>
        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        /// <summary>
        /// �J�n�_��ݒ�/�擾����D
        /// </summary>
        public double From
        {
            set { this.from = value; }
            get { return this.from; }
        }

        /// <summary>
        /// �I���_��ݒ�/�擾����D
        /// </summary>
        public double To
        {
            set { this.to = value; }
            get { return this.to; }
        }

        /// <summary>
        /// �I�t�Z�b�g��������D
        /// </summary>
        /// <param name="value">�I�t�Z�b�g�l</param>
        public void Offset(double value)
        {
            this.from += value;
            this.to += value;
        }
    }
}
