using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.CATEGORY;

namespace TRS_Domain.INTEREST
{
    public class Data
    {
        // ********** PROPERTIES **********
        public string Name { get; private set; }
        public int InterestId { get; private set; }
        public int CategoryId { get; private set; }
        public bool Pending { get; private set; }

        public Data(int interestId)
        {
            InterestId = interestId;
        }

        public Data(string name, int interestId)
        {
            Name = name;
            InterestId = interestId;
            Pending = true;
        }

        public Data(string name,  int interestId, int categoryId)
        {
            Name = name;
            InterestId = interestId;
            CategoryId = categoryId;
            Pending = true;
        }

        public Data(TRS_Domain.INTEREST.Data inputObject)
        {
            Name = inputObject.Name;
            InterestId = inputObject.InterestId;
            CategoryId = inputObject.CategoryId;
            Pending = true;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

