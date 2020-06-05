using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperControls
{
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// 将数据添加到
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView"></param>
        /// <param name="datas"></param>
        public static void AddData<T>(this DataGridView dataGridView, IEnumerable<T> datas)
        {
            try
            {
                if (dataGridView == null || datas == null)
                {
                    return;
                }
                dataGridView.Rows.Clear();
                var type = typeof(T);
                foreach (var data in datas)
                {
                    List<object> values = new List<object>();
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        var property = type.GetProperty(column.Name);
                        if (property != null)
                        {
                            values.Add(property.GetValue(data));
                        }
                    }
                    dataGridView.Rows.Add(values.ToArray());
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridViewRow"></param>
        /// <returns></returns>
        public static T GetData<T>(this DataGridViewRow dataGridViewRow) where T : class, new()
        {
            try
            {
                if (dataGridViewRow == null)
                {
                    return default;
                }

                var type = typeof(T);

                var t = new T();

                foreach (DataGridViewColumn column in dataGridViewRow.DataGridView.Columns)
                {
                    var property = type.GetProperty(column.Name);
                    if (property != null)
                    {
                        property.SetValue(t, dataGridViewRow.Cells[column.Name].Value);
                    }
                }
                return t;
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// 获取多行数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridViewRowCollection"></param>
        /// <returns></returns>
        public static List<T> GetDatas<T>(this DataGridViewRowCollection dataGridViewRowCollection) where T : class, new()
        {
            try
            {
                var list = new List<T>();

                if (dataGridViewRowCollection == null)
                {
                    return list;
                }
                foreach (DataGridViewRow item in dataGridViewRowCollection)
                {
                    var t = item.GetData<T>();
                    if (t != default)
                    {
                        list.Add(t);
                    }
                }
                return list;
            }
            catch
            {
                return new List<T>();
            }
        }
    }
}
