using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace PiotrRadecki
{
    public class CalculatorBox : TextBox
    {
        private Regex mvarRegex = new Regex(@"^\-?[0-9]*(?:\,[0-9]*)?$");
        public CalculatorBox()
        {
            this.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
            this.PreviewTextInput += CalculatorBox_PreviewTextInput;
            this.TextChanged += CalculatorBox_TextChanged;
        }
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CalculatorBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string lvarTextToCheck = string.Empty;

            if (this.SelectionLength >= 1)
            {
                lvarTextToCheck = this.Text;
                lvarTextToCheck = lvarTextToCheck.Remove(this.SelectionStart, this.SelectionLength);
                lvarTextToCheck = lvarTextToCheck.Insert(this.SelectionStart, e.Text);
            }
            else
                lvarTextToCheck = this.Text.Insert(this.SelectionStart, e.Text);

            if (!mvarRegex.IsMatch(lvarTextToCheck))
                e.Handled = true;
        }

        private void CalculatorBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string lvarText = "";
            int lvarPosition = this.SelectionStart;

            foreach (var lvarChar in this.Text)
            {
                if ((char.IsDigit(lvarChar) | lvarChar == ',' | lvarChar == '-'))
                    lvarText = lvarText + lvarChar;
            }

            if (this.Text != lvarText)
            {
                this.Text = lvarText;
                if (lvarPosition >= 1)
                    this.SelectionStart = lvarPosition - 1;
                else
                    this.SelectionStart = 0;
            }
        }
    }

}
