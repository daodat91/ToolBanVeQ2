using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace LIS.Component
{
    public class TextBoxDate : System.Windows.Forms.MaskedTextBox
    {
        public TextBoxDate() : base()
        {
            this.Text = "";
            this.Mask = "00/00/0000";
            this.PromptChar = '_';
            this.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;           
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if ((Value == null) && (!this.Text.Trim().Equals("__/__/____")))
                this.ForeColor = System.Drawing.Color.Red;
            else
                this.ForeColor = System.Drawing.Color.Black;
            base.OnTextChanged(e);
        }

        public DateTime? Value
        {
            get
            {
                //-------------Debug 2011/08/29--------------//
                //After Contructor this.Text = "  /  /";
                if (this.Text.Trim().Equals("")) return null;
                if (this.Text.Trim().Equals("__/__/____")) return null;
                string strDay = this.Text.Substring(0, 2);
                string strMonth = this.Text.Substring(3, 2);
                string strYear = this.Text.Substring(6);
                if (strYear.Length == 1) strYear = "200" + strYear;
                else if (strYear.Length == 2) strYear = "20" + strYear;
                int iDay = 0;
                int iMonth = 0;
                int iYear = 0;
                if (int.TryParse(strDay, out iDay) && int.TryParse(strMonth, out iMonth) && int.TryParse(strYear, out iYear))
                {
                    try
                    {
                        DateTime dt = new DateTime(iYear, iMonth, iDay);
                        if (dt.Year <= 1900)
                        {
                            this.Text = "";
                            return null;
                        }
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        this.Text = "";
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == null)
                    this.Text = "";
                else
                {
                    DateTime dt = (DateTime)value;
                    string strYear = dt.Year.ToString();
                    string strMonth = dt.Month.ToString();
                    string strDay = dt.Day.ToString();
                    if (strDay.Length == 1) strDay = "0" + strDay;
                    if (strMonth.Length == 1) strMonth = "0" + strMonth;
                    this.Text = strDay + "/" + strMonth + "/" + strYear;
                }
            }
        }
    }
}
