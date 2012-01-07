using System;
using System.Collections.Generic;
using System.Text;
using KrdLab.Tools.Wgnuplot.Exception;
using System.Diagnostics;
using System.ComponentModel;

namespace KrdLab.Tools.Wgnuplot
{
    /// <summary>
    /// wgnuplot の wrapper クラス．
    /// <para>実際には，pgnuplot.exe を使ってパイプ経由でコマンドを送り込む．</para>
    /// </summary>
    public class Wgnuplot : IDisposable
    {
        private Process process = null;

        /// <summary>
        /// gnuplot を起動し，待機状態にする．
        /// <para>既定のパスは ".\pgnuplot.exe" である．</para>
        /// </summary>
        /// <exception cref="FailedToStartProcessException">
        /// gnuplot が起動できなかった場合に throw される．
        /// </exception>
        public Wgnuplot()
            : this(@".\pgnuplot.exe")
        { }

        /// <summary>
        /// パスを指定して gnuplot を起動し，待機状態にする．
        /// </summary>
        /// <param name="path">pgnuplot.exe へのパス</param>
        /// <exception cref="FailedToStartProcessException">
        /// gnuplot が起動できなかった場合に throw される．
        /// </exception>
        public Wgnuplot(string path)
        {
            Open(path);
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~Wgnuplot()
        {
            Dispose(false);
        }

        /// <summary>
        /// 既に閉じられているかどうかを取得する．
        /// </summary>
        public bool IsClosed
        {
            get { return IsDisposed || this.process.HasExited; }
        }

        /// <summary>
        /// 既に破棄済であるかどうかを取得する．
        /// <remarks>プロセスの起動に失敗した場合にも <c>true</c> を返す．</remarks>
        /// </summary>
        public bool IsDisposed
        {
            get { return this.process == null; }
        }

        /// <summary>
        /// パスを指定して gnuplot を起動し，待機状態にする．
        /// </summary>
        /// <param name="path">pgnuplot.exe へのパス</param>
        /// <exception cref="FailedToStartProcessException">
        /// gnuplot が起動できなかった場合に throw される．
        /// </exception>
        protected void Open(string path)
        {
            // pgnuplot.exe に接続
            this.process = new Process();
            this.process.StartInfo.FileName = path;
            this.process.StartInfo.UseShellExecute = false;
            this.process.StartInfo.RedirectStandardInput = true;
            try
            {
                this.process.Start();
            }
            catch (Win32Exception e)
            {
                if (this.process != null)
                {
                    this.process.Close();
                    this.process.Dispose();
                    this.process = null;
                }
                throw new FailedToStartProcessException(
                    Properties.Resources.Message_FailedStartGnuplot, e);
            }
        }

        /// <summary>
        /// コマンドを送信する．
        /// </summary>
        /// <param name="command">gnuplot に送信したいコマンド</param>
        /// <exception cref="ObjectDisposedException">
        /// 起動に失敗した，もしくは既に破棄済のオブジェクトに対してメソッドを呼び出した場合に throw される．
        /// </exception>
        public void Send(string command)
        {
            if (IsDisposed)
            {
                // 既に破棄されている
                throw new ObjectDisposedException(
                    "Wgnuplot", Properties.Resources.Message_NotEnabledGnuplot);
            }
            this.process.StandardInput.WriteLine(command);
        }

        /// <summary>
        /// gnuplot を閉じる．終了するまで無期限に待機する．
        /// <para>リソースの破棄が必要な場合は <see cref="Wgnuplot.Dispose()"/> メソッドを呼び出すこと．</para>
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        /// 起動に失敗した，もしくは既に破棄済のオブジェクトに対してメソッドを呼び出した場合に throw される．
        /// </exception>
        public void Close()
        {
            Close(-1);
        }

        /// <summary>
        /// gnuplot を閉じる．
        /// <para>リソースの破棄が必要な場合は <see cref="Wgnuplot.Dispose()"/> メソッドを呼び出すこと．</para>
        /// </summary>
        /// <param name="waitForExitTime">
        /// gnuplot が終了するまで待機する時間 (msec)．
        /// <para>負の値を指定すると無期限に待機する．</para>
        /// </param>
        /// <exception cref="ObjectDisposedException">
        /// 起動に失敗した，もしくは既に破棄済のオブジェクトに対してメソッドを呼び出した場合に throw される．
        /// </exception>
        public void Close(int waitForExitTime)
        {
            if (IsDisposed)
            {
                // 既に破棄されている
                throw new ObjectDisposedException(
                    "Wgnuplot", Properties.Resources.Message_NotEnabledGnuplot);
            }
            if (IsClosed)
            {
                // 既に閉じているので何もしない
                return;
            }

            // gnuplot のウィンドウを閉じる
            Send("quit");

            // pgnuplot は UI 無しプロセス
            this.process.Kill();
            if (waitForExitTime < 0)
            {
                this.process.WaitForExit();
            }
            else
            {
                this.process.WaitForExit(waitForExitTime);
            }
        }

        #region 破棄

        /// <summary>
        /// リソースを破棄する．
        /// </summary>
        /// <param name="disposing">
        /// 明示的に managed を破棄する場合は <c>true</c> を指定する．
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.process != null)
            {
                try
                {
                    // 閉じていないかもしれないので
                    Close();
                }
                finally
                {
                    this.process.Close();
                    this.process.Dispose();
                    this.process = null;
                }
            }
            // unmanaged
        }

        #region IDisposable メンバ

        /// <summary>
        /// 明示的にリソースを破棄する．
        /// <para><see cref="Wgnuplot.Close()"/> も合わせて行う．</para>
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion
    }
}
