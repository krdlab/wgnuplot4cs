using System;
using System.Collections.Generic;
using System.Text;
using KrdLab.Tools.Wgnuplot.Settings;

namespace KrdLab.Tools.Wgnuplot
{
    public static class WgnuplotExtender
    {
        public static void Test(this Wgnuplot plot)
        {
            Console.WriteLine("test");
        }

        public static void SetArrow(this Wgnuplot plot, Arrow arrow)
        {
        }

        public static void UnsetArrow(this Wgnuplot plot)
        {
        }

        #region 設定

        /// <summary>
        /// x 軸のラベルを設定する．
        /// </summary>
        public static void SetXLabel(this Wgnuplot plot, Label value)
        {
            plot.Send(value != null ? "set xlabel " + value : "unset xlabel");
        }

        /// <summary>
        /// y 軸のラベルを設定する．
        /// </summary>
        public static void SetYLabel(this Wgnuplot plot, Label value)
        {
            plot.Send(value != null ? "set ylabel " + value : "unset ylabel");
        }

        /// <summary>
        /// x 軸の範囲を設定する．
        /// </summary>
        public static void SetXRange(this Wgnuplot plot, Range value)
        {
            String command = String.Format("set xrange [{0}:{1}]", value.From, value.To);
            plot.Send(command);
        }

        /// <summary>
        /// x2 軸の範囲を設定する．
        /// </summary>
        public static void SetX2Range(this Wgnuplot plot, Range value)
        {
            String command = String.Format("set x2range [{0}:{1}]", value.From, value.To);
            plot.Send(command);
        }

        /// <summary>
        /// y 軸の範囲を設定する．
        /// </summary>
        public static void SetYRange(this Wgnuplot plot, Range value)
        {
            String command = String.Format("set yrange [{0}:{1}]", value.From, value.To);
            plot.Send(command);
        }

        /// <summary>
        /// y2 軸の範囲を設定する．
        /// </summary>
        public static void SetY2Range(this Wgnuplot plot, Range value)
        {
            String command = String.Format("set y2range [{0}:{1}]", value.From, value.To);
            plot.Send(command);
        }

        /// <summary>
        /// x 軸の目盛を設定する．
        /// </summary>
        public static void SetXTics(this Wgnuplot plot, Tics value)
        {
            plot.Send(value != null ? "set xtics " + value : "unset xtics");
        }

        /// <summary>
        /// x2 軸の目盛を設定する．
        /// </summary>
        public static void SetX2Tics(this Wgnuplot plot, Tics value)
        {
            plot.Send(value != null ? "set x2tics " + value : "unset x2tics");
        }

        /// <summary>
        /// x 軸のミラー設定を行う．
        /// <para><c>false</c> を設定すると，上下軸の目盛が一致しなくなる．</para>
        /// </summary>
        public static void SetXTicsMirror(this Wgnuplot plot, bool value)
        {
            plot.Send("set xtics " + (value ? "" : "no") + "mirror");
        }

        /// <summary>
        /// y 軸の目盛を設定する．
        /// </summary>
        public static void SetYTics(this Wgnuplot plot, Tics value)
        {
            plot.Send(value != null ? "set ytics " + value : "unset ytics");
        }

        /// <summary>
        /// y2 軸の目盛を設定する．
        /// </summary>
        public static void SetY2Tics(this Wgnuplot plot, Tics value)
        {
            plot.Send(value != null ? "set y2tics " + value : "unset y2tics");
        }

        /// <summary>
        /// y 軸のミラー設定を行う．
        /// <para><c>false</c> を設定すると，左右軸の目盛が一致しなくなる．</para>
        /// </summary>
        public static void SetYTicsMirror(this Wgnuplot plot, bool value)
        {
            plot.Send("set ytics " + (value ? "" : "no") + "mirror");
        }

        /// <summary>
        /// x 軸目盛の分割数を設定する．
        /// <para>例えば 2 を設定した場合，目盛が 2 分割されるため，目盛の間に補助目盛が 1 つ表示される．</para>
        /// </summary>
        public static void SetMXTics(this Wgnuplot plot, int value)
        {
            plot.Send("set mxtics " + value);
        }

        /// <summary>
        /// y 軸目盛の分割数を設定する．
        /// <para>例えば 2 を設定した場合，目盛が 2 分割されるため，目盛の間に補助目盛が 1 つ表示される．</para>
        /// </summary>
        public static void SetMYTics(this Wgnuplot plot, int value)
        {
            plot.Send("set mytics " + value);
        }

        /// <summary>
        /// x 軸を log スケールに設定する．
        /// <remarks>
        /// <c>true</c> の場合は log スケールに，<c>false</c> の場合は log スケール設定を解除する．
        /// </remarks>
        /// </summary>
        public static void SetLogScaleX(this Wgnuplot plot, bool value)
        {
            plot.Send((value ? "" : "un") + "set logscale x");
        }

        /// <summary>
        /// y 軸を log スケールに設定する．
        /// <remarks>
        /// <c>true</c> の場合は log スケールに，<c>false</c> の場合は log スケール設定を解除する．
        /// </remarks>
        /// </summary>
        public static void SetLogScaleY(this Wgnuplot plot, bool value)
        {
            plot.Send((value ? "" : "un") + "set logscale y");
        }

        /// <summary>
        /// 枠線を設定する．
        /// </summary>
        public static void SetBorder(this Wgnuplot plot, Border value)
        {
            plot.Send("set border " + (int)value);
        }

        /// <summary>
        /// サイズを設定する．
        /// </summary>
        public static void SetSize(this Wgnuplot plot, Size value)
        {
            String command = "";
            switch (value.Type)
            {
                case SizeType.Square:

                    command = "set size square";
                    break;
                case SizeType.RatioAxis:
                    command = "set size ratio " + value.RatioValue;
                    break;
                case SizeType.RatioUnit:
                    command = "set size ratio -" + value.RatioValue;
                    break;
            }
            plot.Send(command);
        }

        public static void UnsetSize(this Wgnuplot plot)
        {
            plot.Send("unset size");
        }

        #endregion
    }
}
