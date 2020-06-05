using System;
using System.Windows.Forms;

namespace SuperControls
{
    public static class TextBoxExtensions
    {
        public static int GetInt32Value(this TextBox textBox)
        {
            try
            {
                if (textBox == default)
                {
                    return default;
                }
                return Convert.ToInt32(textBox.Text);
            }
            catch
            {
                return default;
            }
        }

        public static double GetDoubleValue(this TextBox textBox)
        {
            try
            {
                if (textBox == default)
                {
                    return default;
                }
                return Convert.ToDouble(textBox.Text);
            }
            catch
            {
                return default;
            }
        }
    }
}
