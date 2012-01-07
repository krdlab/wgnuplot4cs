using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// ògê¸
    /// </summary>
    [Flags]
    public enum Border
    {
        /// <summary>
        /// â∫
        /// </summary>
        Bottom = 0x01,

        /// <summary>
        /// ç∂
        /// </summary>
        Left = 0x02,

        /// <summary>
        /// è„
        /// </summary>
        Top = 0x04,

        /// <summary>
        /// âE
        /// </summary>
        Right = 0x08,
    }
}
