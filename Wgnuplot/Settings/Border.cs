using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// �g��
    /// </summary>
    [Flags]
    public enum Border
    {
        /// <summary>
        /// ��
        /// </summary>
        Bottom = 0x01,

        /// <summary>
        /// ��
        /// </summary>
        Left = 0x02,

        /// <summary>
        /// ��
        /// </summary>
        Top = 0x04,

        /// <summary>
        /// �E
        /// </summary>
        Right = 0x08,
    }
}
