using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// 一緒に表示するものの指定
    /// </summary>
    [Flags]
    public enum With
    {
        /// <summary>
        /// 無指定
        /// </summary>
        Null = 0x00,

        /// <summary>
        /// Y 軸方向に誤差棒を付ける．
        /// </summary>
        Yerrorbars = 0x01,
    }
}
