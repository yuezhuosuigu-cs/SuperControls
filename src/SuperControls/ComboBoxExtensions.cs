using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperControls
{
    public static class ComboBoxExtensions
    {
        /// <summary>
        /// 向ComboBox中添加项，Key是要显示的文本，Value是选中项的Value
        /// first为是否向最前端添加一项
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="datas"></param>
        /// <param name="first"></param>
        public static void AddData(this ComboBox comboBox, List<KeyValuePair<string, string>> datas, KeyValuePair<string, string>? first = null)
        {
            comboBox.Invoke((MethodInvoker)delegate
            {
                try
                {
                    if (comboBox == null || datas == null)
                    {
                        return;
                    }

                    comboBox.Items.Clear();

                    if (first != null)
                    {
                        datas.Insert(0, (KeyValuePair<string, string>)first);
                    }
                    comboBox.DataSource = datas;
                    comboBox.DisplayMember = "Key";
                    comboBox.ValueMember = "Value";

                    if (comboBox.Items.Count > 0)
                    {
                        comboBox.SelectedIndex = 0;
                    }
                }
                catch
                { }
            });
        }
    }
}
