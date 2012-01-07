using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Exception
{
    /// <summary>
    /// プロセスの起動に失敗した場合に throw される．
    /// </summary>
    public class FailedToStartProcessException : System.Exception
    {
        /// <summary>
        /// メッセージなしで例外を作成する．
        /// </summary>
        public FailedToStartProcessException()
        { }

        /// <summary>
        /// メッセージを指定して例外を作成する．
        /// </summary>
        /// <param name="message">メッセージ</param>
        public FailedToStartProcessException(string message)
            : base(message)
        { }

        /// <summary>
        /// メッセージと，発生原因となった例外を指定して作成する．
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="inner">原因例外</param>
        public FailedToStartProcessException(string message, System.Exception inner)
            : base(message, inner)
        { }
    }
}
