using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// �ꏏ�ɕ\��������̂̎w��
    /// </summary>
    [Flags]
    public enum With
    {
        /// <summary>
        /// ���w��
        /// </summary>
        Null = 0x00,

        /// <summary>
        /// Y �������Ɍ덷�_��t����D
        /// </summary>
        Yerrorbars = 0x01,
    }
}
