using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace LIS.Component
{
    public class TextBoxNumberDecimal : System.Windows.Forms.TextBox
    {
        public TextBoxNumberDecimal()
            : base()
        {
            this.Text = "";
        }

        protected override void OnCreateControl()
        {
            if (this.Value == 0m) this.Text = "";
            base.OnCreateControl();
        }

        private bool isRound = false;
        public bool Round
        {
            get { return isRound; }
            set { isRound = value; }
        }

        private decimal dMin = 0m;
        public decimal Min
        {
            get { return dMin; }
            set { dMin = value; }
        }

        private decimal dMax = 0m;
        public decimal Max
        {
            get { return dMax; }
            set { dMax = value; }
        }

        private bool _isDouble = false;
        public bool isDouble
        {
            get { return _isDouble; }
            set { _isDouble = value; }
        }

        private bool isProcessing = false;
        private decimal dValue = 0m;
        public decimal Value
        {
            get
            {
                return dValue;
            }
            set
            {
                this.Text = value.ToString();
                if ((isRound) && (iScale >= 0))
                {
                    double dValue1 = Math.Round((double)value * Math.Pow(10, iScale)) / Math.Pow(10, iScale);
                    this.Text = dValue1.ToString();
                    dValue = (decimal)dValue1;
                }
                else
                    dValue = value;
            }
        }

        private int iScale = 0;
        public int Scale
        {
            get { return iScale; }
            set { iScale = value; }
        }

        private bool isCopyAndPaste = false;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            isProcessing = true;
            if ((e.Control == true) && ((e.KeyCode == Keys.V) || (e.KeyCode == Keys.C)))
                isCopyAndPaste = true;
            else if (e.KeyCode == Keys.Delete)
                this.Text = "";
            else isCopyAndPaste = false;
            base.OnKeyDown(e);
            isProcessing = false;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            isProcessing = true;
            if ((!Char.IsDigit(e.KeyChar)) && (!isCopyAndPaste))
            {
                if (_isDouble)
                {
                    if (e.KeyChar == '.')
                    {
                        if ((this.Text.IndexOf(".", 0)) >= 0) e.Handled = true;
                    }
                    else
                        if ((e.KeyChar != Convert.ToChar(Keys.Back)) &&
                            (e.KeyChar != '-')) e.Handled = true;

                    if ((!e.Handled) && ((e.KeyChar != Convert.ToChar(Keys.Back)) &&
                            (e.KeyChar != '-')))
                    {
                        string sTest = this.Text + Convert.ToString(e.KeyChar);
                        decimal dTest = 0m;
                        if (!decimal.TryParse(sTest, out dTest)) e.Handled = true;
                    }
                }
                else
                    if ((e.KeyChar != Convert.ToChar(Keys.Back)) &&
                            (e.KeyChar != '-')) e.Handled = true;
            }
            isCopyAndPaste = false;
            base.OnKeyPress(e);
            isProcessing = false;
        }

        public delegate void ValueChangedEventHandler(EventArgs e);
        public event ValueChangedEventHandler ValueChanged;

        protected override void OnTextChanged(EventArgs e)
        {
            if (isProcessing) return;
            if (this.Text.Equals(""))
            {
                dValue = 0m;
                return;
            }
            decimal result;
            if (decimal.TryParse(this.Text, out result))
                dValue = result;
            else
                Value = 0m;

            if (dMin < dMax)
            {
                if (dValue < dMin) Value = dMin;
                if (dValue > dMax) Value = dMax;
            }

            if (decimal.TryParse(this.Text, out result))
                if (ValueChanged != null) ValueChanged(e);

            base.OnTextChanged(e);
        }
    }
}
