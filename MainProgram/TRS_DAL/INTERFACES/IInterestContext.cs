using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.INTEREST;

namespace TRS_DAL.INTERFACES
{
    interface IInterestContext
    {
        List<TRS_Domain.INTEREST.Data> GetAllVerifiedInterests();

        List<Data> GetAllNotVerifiedInterests();

        List<TRS_Domain.INTEREST.Data> GetUserInterests(int userId);

        List<TRS_Domain.CATEGORY.Data> GetAllCategory();

        List<TRS_Domain.INTEREST.Data> GetUserCategoryInterests(int categoryId, int userId);

        void ClearUserInterests(int userId);

        void AddUserInterest(int userId, int interestId);

        void AddNewInterest(string interestName, int interestCategoryId);

        void VerifyInterest(int interestId);

        void UnVerifyInterest(int interestId);


    }
}
