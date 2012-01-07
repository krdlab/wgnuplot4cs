using System;
using System.Collections.Generic;
using System.Text;
using KrdLab.Tools.Wgnuplot.Exception;
using System.Diagnostics;
using System.ComponentModel;

namespace KrdLab.Tools.Wgnuplot
{
    /// <summary>
    /// wgnuplot �� wrapper �N���X�D
    /// <para>���ۂɂ́Cpgnuplot.exe ���g���ăp�C�v�o�R�ŃR�}���h�𑗂荞�ށD</para>
    /// </summary>
    public class Wgnuplot : IDisposable
    {
        private Process process = null;

        /// <summary>
        /// gnuplot ���N�����C�ҋ@��Ԃɂ���D
        /// <para>����̃p�X�� ".\pgnuplot.exe" �ł���D</para>
        /// </summary>
        /// <exception cref="FailedToStartProcessException">
        /// gnuplot ���N���ł��Ȃ������ꍇ�� throw �����D
        /// </exception>
        public Wgnuplot()
            : this(@".\pgnuplot.exe")
        { }

        /// <summary>
        /// �p�X���w�肵�� gnuplot ���N�����C�ҋ@��Ԃɂ���D
        /// </summary>
        /// <param name="path">pgnuplot.exe �ւ̃p�X</param>
        /// <exception cref="FailedToStartProcessException">
        /// gnuplot ���N���ł��Ȃ������ꍇ�� throw �����D
        /// </exception>
        public Wgnuplot(string path)
        {
            Open(path);
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~Wgnuplot()
        {
            Dispose(false);
        }

        /// <summary>
        /// ���ɕ����Ă��邩�ǂ������擾����D
        /// </summary>
        public bool IsClosed
        {
            get { return IsDisposed || this.process.HasExited; }
        }

        /// <summary>
        /// ���ɔj���ςł��邩�ǂ������擾����D
        /// <remarks>�v���Z�X�̋N���Ɏ��s�����ꍇ�ɂ� <c>true</c> ��Ԃ��D</remarks>
        /// </summary>
        public bool IsDisposed
        {
            get { return this.process == null; }
        }

        /// <summary>
        /// �p�X���w�肵�� gnuplot ���N�����C�ҋ@��Ԃɂ���D
        /// </summary>
        /// <param name="path">pgnuplot.exe �ւ̃p�X</param>
        /// <exception cref="FailedToStartProcessException">
        /// gnuplot ���N���ł��Ȃ������ꍇ�� throw �����D
        /// </exception>
        protected void Open(string path)
        {
            // pgnuplot.exe �ɐڑ�
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
        /// �R�}���h�𑗐M����D
        /// </summary>
        /// <param name="command">gnuplot �ɑ��M�������R�}���h</param>
        /// <exception cref="ObjectDisposedException">
        /// �N���Ɏ��s�����C�������͊��ɔj���ς̃I�u�W�F�N�g�ɑ΂��ă��\�b�h���Ăяo�����ꍇ�� throw �����D
        /// </exception>
        public void Send(string command)
        {
            if (IsDisposed)
            {
                // ���ɔj������Ă���
                throw new ObjectDisposedException(
                    "Wgnuplot", Properties.Resources.Message_NotEnabledGnuplot);
            }
            this.process.StandardInput.WriteLine(command);
        }

        /// <summary>
        /// gnuplot �����D�I������܂Ŗ������ɑҋ@����D
        /// <para>���\�[�X�̔j�����K�v�ȏꍇ�� <see cref="Wgnuplot.Dispose()"/> ���\�b�h���Ăяo�����ƁD</para>
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        /// �N���Ɏ��s�����C�������͊��ɔj���ς̃I�u�W�F�N�g�ɑ΂��ă��\�b�h���Ăяo�����ꍇ�� throw �����D
        /// </exception>
        public void Close()
        {
            Close(-1);
        }

        /// <summary>
        /// gnuplot �����D
        /// <para>���\�[�X�̔j�����K�v�ȏꍇ�� <see cref="Wgnuplot.Dispose()"/> ���\�b�h���Ăяo�����ƁD</para>
        /// </summary>
        /// <param name="waitForExitTime">
        /// gnuplot ���I������܂őҋ@���鎞�� (msec)�D
        /// <para>���̒l���w�肷��Ɩ������ɑҋ@����D</para>
        /// </param>
        /// <exception cref="ObjectDisposedException">
        /// �N���Ɏ��s�����C�������͊��ɔj���ς̃I�u�W�F�N�g�ɑ΂��ă��\�b�h���Ăяo�����ꍇ�� throw �����D
        /// </exception>
        public void Close(int waitForExitTime)
        {
            if (IsDisposed)
            {
                // ���ɔj������Ă���
                throw new ObjectDisposedException(
                    "Wgnuplot", Properties.Resources.Message_NotEnabledGnuplot);
            }
            if (IsClosed)
            {
                // ���ɕ��Ă���̂ŉ������Ȃ�
                return;
            }

            // gnuplot �̃E�B���h�E�����
            Send("quit");

            // pgnuplot �� UI �����v���Z�X
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

        #region �j��

        /// <summary>
        /// ���\�[�X��j������D
        /// </summary>
        /// <param name="disposing">
        /// �����I�� managed ��j������ꍇ�� <c>true</c> ���w�肷��D
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.process != null)
            {
                try
                {
                    // ���Ă��Ȃ���������Ȃ��̂�
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

        #region IDisposable �����o

        /// <summary>
        /// �����I�Ƀ��\�[�X��j������D
        /// <para><see cref="Wgnuplot.Close()"/> �����킹�čs���D</para>
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
