using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// サイズ設定タイプ
    /// </summary>
    public enum SizeType
    {
        /// <summary>
        /// 正方形
        /// </summary>
        Square,

        /// <summary>
        /// 軸長の比率指定
        /// </summary>
        RatioAxis,

        /// <summary>
        /// 単位長の比率指定
        /// </summary>
        RatioUnit,
    }

    /// <summary>
    /// グラフのサイズ設定
    /// </summary>
    public class Size
    {
        /// <summary>
        /// 正方形設定
        /// </summary>
        public static readonly Size Square = new Size(SizeType.Square, 1);

        /// <summary>
        /// 軸の長さに対する比率指定
        /// <para>range 設定に関係なく，単純に軸の長さの比率を設定する．</para>
        /// </summary>
        /// <param name="value">比率 (y/x) 値</param>
        /// <returns><see cref="Size" /></returns>
        public static Size RatioAxis(double value)
        {
            return new Size(SizeType.RatioAxis, value);
        }

        /// <summary>
        /// 単位長さに対する比率指定
        /// <para>
        /// 例えば 2 と設定した場合，y 軸の単位長 1 は，x 軸の単位長 1 に対して 2 倍の長さになる．
        /// </para>
        /// </summary>
        /// <param name="value">比率 (y/x) 値</param>
        /// <returns><see cref="Size"/></returns>
        public static Size RatioUnit(double value)
        {
            return new Size(SizeType.RatioUnit, value);
        }

        #region instance

        private readonly SizeType type;
        private readonly double value;

        internal Size(SizeType type, double value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// サイズ設定タイプを取得する．
        /// </summary>
        public SizeType Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// 比率 (y/x) を取得する．
        /// </summary>
        public double RatioValue
        {
            get { return this.value; }
        }

        #endregion
    }
}
