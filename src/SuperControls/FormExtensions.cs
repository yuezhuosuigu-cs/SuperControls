using System.Windows.Forms;

namespace SuperControls
{
    public static class FormExtensions
    {
        /// <summary>
        /// 将窗体添加到Panel中并显示
        /// </summary>
        /// <param name="f"></param>
        /// <param name="panel"></param>
        public static void AddTo(this Form f, Panel panel)
        {
            try
            {
                if (f == null && panel == null)
                {
                    return;
                }

                foreach (Control item in panel.Controls)
                {
                    if (item is Form form)
                    {
                        form.Close();
                    }
                }

                f.TopLevel = false;
                panel.Controls.Add(f);
                f.Show();
            }
            catch
            { }
        }
    }
}
