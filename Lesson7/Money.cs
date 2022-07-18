using System;
using System.Data;

namespace Lesson7
{
    //2. Create class Money (with base operations + and -).
    public class Money
    {
        private int _amount;

        public int GetAmount()
        {
            return _amount;
        }

        public override string ToString()
        {
            return _amount.ToString();
        }

        /// <summary>
        /// Example for using .SetAmount("+500")
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int SetAmount(string amount)
        {
            if (string.IsNullOrEmpty(amount))
            {
                throw new ArgumentException("Please enter something. Read a method description for example.");
            }

            var dt = new DataTable();
            dt.Columns.Add("r", typeof(int), amount);
            dt.Rows.Add();
            int operationB = (int)dt.Rows[0][0];
            return _amount += operationB;
        }
    }
}
