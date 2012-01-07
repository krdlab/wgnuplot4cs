using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Exception
{
    /// <summary>
    /// �v���Z�X�̋N���Ɏ��s�����ꍇ�� throw �����D
    /// </summary>
    public class FailedToStartProcessException : System.Exception
    {
        /// <summary>
        /// ���b�Z�[�W�Ȃ��ŗ�O���쐬����D
        /// </summary>
        public FailedToStartProcessException()
        { }

        /// <summary>
        /// ���b�Z�[�W���w�肵�ė�O���쐬����D
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        public FailedToStartProcessException(string message)
            : base(message)
        { }

        /// <summary>
        /// ���b�Z�[�W�ƁC���������ƂȂ�����O���w�肵�č쐬����D
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="inner">������O</param>
        public FailedToStartProcessException(string message, System.Exception inner)
            : base(message, inner)
        { }
    }
}
