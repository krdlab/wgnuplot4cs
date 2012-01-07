using System;
using System.Collections.Generic;
using System.Text;

namespace KrdLab.Tools.Wgnuplot.Settings
{
    /// <summary>
    /// ���x���ݒ�
    /// </summary>
    public class Label
    {
        private readonly String text;
        private readonly double x;
        private readonly double y;

        /// <summary>
        /// ���x���݂̂��w�肵�č쐬����D
        /// </summary>
        /// <param name="text">���x��</param>
        public Label(String text)
            : this(text, 0, 0)
        { }

        /// <summary>
        /// ���x���ƕ\���I�t�Z�b�g���w�肵�č쐬����D
        /// </summary>
        /// <param name="text">���x��</param>
        /// <param name="x">x �����̃I�t�Z�b�g (�Ⴆ�� "1" �� 1 �������E�ɂ����)</param>
        /// <param name="y">y �����̃I�t�Z�b�g (�Ⴆ�� "1" �� 1 ��������ɂ����)</param>
        public Label(String text, double x, double y)
        {
            this.text = text;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// �e�L�X�g���擾����D
        /// </summary>
        public String Text
        {
            get { return this.text; }
        }

        /// <summary>
        /// x �����̃I�t�Z�b�g���擾����D
        /// </summary>
        public double X
        {
            get { return this.x; }
        }

        /// <summary>
        /// y �����̃I�t�Z�b�g���擾����D
        /// </summary>
        public double Y
        {
            get { return this.y; }
        }

        /// <summary>
        /// ������\����Ԃ��D
        /// </summary>
        /// <returns>���̃I�u�W�F�N�g�̕�����\��</returns>
        public override string ToString()
        {
            return String.Format("\"{0}\" {1}, {2}", Text, X, Y);
        }
    }
}
