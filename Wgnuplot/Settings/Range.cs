using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// 範囲指定
    /// </summary>
    public class Range
    {
        private double from;
        private double to;

        /// <summary>
        /// 範囲 (閉区間) を指定して作成する．
        /// </summary>
        /// <param name="from">開始点</param>
        /// <param name="to">終了点</param>
        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        /// <summary>
        /// 開始点を設定/取得する．
        /// </summary>
        public double From
        {
            set { this.from = value; }
            get { return this.from; }
        }

        /// <summary>
        /// 終了点を設定/取得する．
        /// </summary>
        public double To
        {
            set { this.to = value; }
            get { return this.to; }
        }

        /// <summary>
        /// オフセットを加える．
        /// </summary>
        /// <param name="value">オフセット値</param>
        public void Offset(double value)
        {
            this.from += value;
            this.to += value;
        }
    }
}
