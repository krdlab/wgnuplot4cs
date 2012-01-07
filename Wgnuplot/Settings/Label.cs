using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// ラベル設定
    /// </summary>
    public class Label
    {
        private readonly String text;
        private readonly double x;
        private readonly double y;

        /// <summary>
        /// ラベルのみを指定して作成する．
        /// </summary>
        /// <param name="text">ラベル</param>
        public Label(String text)
            : this(text, 0, 0)
        { }

        /// <summary>
        /// ラベルと表示オフセットを指定して作成する．
        /// </summary>
        /// <param name="text">ラベル</param>
        /// <param name="x">x 方向のオフセット (例えば "1" で 1 文字分右にずれる)</param>
        /// <param name="y">y 方向のオフセット (例えば "1" で 1 文字分上にずれる)</param>
        public Label(String text, double x, double y)
        {
            this.text = text;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// テキストを取得する．
        /// </summary>
        public String Text
        {
            get { return this.text; }
        }

        /// <summary>
        /// x 方向のオフセットを取得する．
        /// </summary>
        public double X
        {
            get { return this.x; }
        }

        /// <summary>
        /// y 方向のオフセットを取得する．
        /// </summary>
        public double Y
        {
            get { return this.y; }
        }

        /// <summary>
        /// 文字列表現を返す．
        /// </summary>
        /// <returns>このオブジェクトの文字列表現</returns>
        public override string ToString()
        {
            return String.Format("\"{0}\" {1}, {2}", Text, X, Y);
        }
    }
}
