using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.CATEGORY
{
    public class Data
    {
        public string Name { get; private set; }
        public int CategoryId { get; private set; }

        public Data(string name)
        {
            Name = name;
        }

        public Data(Data inputObject)
        {
            Name = inputObject.Name;
            CategoryId = inputObject.CategoryId;
        }

        public Data(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public override string ToString()
        {
            return Convert.ToString(CategoryId);
        }
    }
}
