using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

namespace LIS.Component
{
    public class TextBoxNumber : System.Windows.Forms.TextBox
    {
        public TextBoxNumber()
            : base()
        {
            this.Text = "";
            this.Font = new Font("Arial", 10, FontStyle.Regular);
            this.isDigitGroup = true;
        }

        protected override void OnCreateControl()
        {
            if (this.Value == 0) this.Text = "";
            base.OnCreateControl();
        }

        private bool isRound = false;
        public bool Round
        {
            get { return isRound; }
            set { isRound = value; }
        }

        private double dMin = 0;
        public double Min
        {
            get { return dMin; }
            set { dMin = value; }
        }

        private double dMax = 0;
        public double Max
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

        private bool _isDigitGroup = false;
        public bool isDigitGroup
        {
            get { return _isDigitGroup; }
            set { _isDigitGroup = value; }
        }

        private bool isProcessing = false;
        private double dValue = 0;
        private bool IsValueChanged = false;
        public double Value
        {
            get
            {
                return dValue;
            }
            set
            {
                //this.Text = value.ToString();
                string ss = this.Name;
                if ((isRound) && (iScale >= 0))
                {
                    //double dValue1 = Math.Round(value * Math.Pow(10, iScale)) / Math.Pow(10, iScale);
                    double dValue1 = Math.Round(value, iScale);
                    this.Text = dValue1.ToString();
                    dValue = dValue1;
                }
                else
                {
                    dValue = value;
                    this.Text = value.ToString();
                }

                if (_isDigitGroup)
                {
                    try
                    {
                        string strRound = "0";
                        if (isRound)
                        {
                            if (iScale > 0)
                                strRound += ".";
                            for (int i = 0; i < iScale; i++)
                            {
                                strRound += "#";
                            }
                        }
                        else
                        {
                            strRound = "0.#########";
                        }
                        string sValue = string.Format("{0:#," + strRound + "}", dValue, strRound);
                        if (dValue == 0)
                            sValue = "0";
                        else
                            this.Text = sValue;
                        this.SelectionStart = this.Text.Length;
                        this.SelectionLength = 1;
                    }
                    catch
                    {
                    }
                }
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
                        double dTest = 0;
                        if (!double.TryParse(sTest, out dTest)) e.Handled = true;
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
                dValue = 0;
                return;
            }
            double result = 0;
            double dValue1 = 0;
            string ss = this.Name;
            if (double.TryParse(this.Text, out result))
            {
                if ((isRound) && (iScale >= 0))
                {
                    dValue1 = Math.Round(result, iScale);

                }
                else
                {
                    if (dValue != result)
                        IsValueChanged = true;
                    else
                        IsValueChanged = false;
                    dValue1 = result;
                }

            }

            if (dValue != result)
                IsValueChanged = true;
            else
                IsValueChanged = false;
            dValue = dValue1;

            if (dMin < dMax)
            {
                if (dValue < dMin) Value = dMin;
                if (dValue > dMax) Value = dMax;
            }

            if (double.TryParse(this.Text, out result))
                if (ValueChanged != null) ValueChanged(e);
            if (_isDigitGroup)
            {
                try
                {
                    //NumberFormatInfo nFI = new CultureInfo("en-US", false).NumberFormat;
                    //string sValue = result.ToString("N", nFI);
                    string strRound = "0";
                    if (isRound)
                    {
                        if (iScale > 0)
                            strRound += ".";
                        for (int i = 0; i < iScale; i++)
                        {
                            strRound += "#";
                        }
                    }
                    else
                    {
                        strRound = "0.#########";
                    }
                    //string sValue = string.Format("{0:#," + strRound + "}", dValue1, strRound);
                    string sValue = string.Format("{0:#," + strRound + "}", dValue1);
                    if (dValue == 0)
                    {
                        sValue = "0";
                    }
                    else
                    {
                        if (isDouble)
                        {
                            if (IsValueChanged)
                                this.Text = sValue;
                        }
                        else
                        {
                            this.Text = sValue;
                        }
                    }
                    this.SelectionStart = this.Text.Length;
                    this.SelectionLength = 1;
                }
                catch
                {
                }
            }
            base.OnTextChanged(e);
        }
    }
}
