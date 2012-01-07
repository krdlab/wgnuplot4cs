using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// �T�C�Y�ݒ�^�C�v
    /// </summary>
    public enum SizeType
    {
        /// <summary>
        /// �����`
        /// </summary>
        Square,

        /// <summary>
        /// �����̔䗦�w��
        /// </summary>
        RatioAxis,

        /// <summary>
        /// �P�ʒ��̔䗦�w��
        /// </summary>
        RatioUnit,
    }

    /// <summary>
    /// �O���t�̃T�C�Y�ݒ�
    /// </summary>
    public class Size
    {
        /// <summary>
        /// �����`�ݒ�
        /// </summary>
        public static readonly Size Square = new Size(SizeType.Square, 1);

        /// <summary>
        /// ���̒����ɑ΂���䗦�w��
        /// <para>range �ݒ�Ɋ֌W�Ȃ��C�P���Ɏ��̒����̔䗦��ݒ肷��D</para>
        /// </summary>
        /// <param name="value">�䗦 (y/x) �l</param>
        /// <returns><see cref="Size" /></returns>
        public static Size RatioAxis(double value)
        {
            return new Size(SizeType.RatioAxis, value);
        }

        /// <summary>
        /// �P�ʒ����ɑ΂���䗦�w��
        /// <para>
        /// �Ⴆ�� 2 �Ɛݒ肵���ꍇ�Cy ���̒P�ʒ� 1 �́Cx ���̒P�ʒ� 1 �ɑ΂��� 2 �{�̒����ɂȂ�D
        /// </para>
        /// </summary>
        /// <param name="value">�䗦 (y/x) �l</param>
        /// <returns><see cref="Size"/></returns>
        public static Size RatioUnit(double value)
        {
            return new Size(SizeType.RatioUnit, value);
        }

        #region instance

        private readonly SizeType type;
        private readonly double value;

        internal Size(SizeType type, double value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// �T�C�Y�ݒ�^�C�v���擾����D
        /// </summary>
        public SizeType Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// �䗦 (y/x) ���擾����D
        /// </summary>
        public double RatioValue
        {
            get { return this.value; }
        }

        #endregion
    }
}
