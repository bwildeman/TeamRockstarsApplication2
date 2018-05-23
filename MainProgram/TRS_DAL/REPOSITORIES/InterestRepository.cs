using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.CONTEXT;
using TRS_DAL.INTERFACES;

namespace TRS_DAL.REPOSITORIES
{
    public class InterestRepository
    {
        //  Add Context Reference:
        IInterestContext _interestContext = new InterestSqlContext();

        // Get methods
        public List<TRS_Domain.CATEGORY.Data> GetAllCategories()
        {
            return _interestContext.GetAllCategory();
        }

        public List<TRS_Domain.INTEREST.Data> GetAllVerifiedInterests()
        {
            return _interestContext.GetAllVerifiedInterests();
        }

        public List<TRS_Domain.INTEREST.Data> GetAllNotVerifiedInterests()
        {
            return _interestContext.GetAllNotVerifiedInterests();
        }

        public List<TRS_Domain.INTEREST.Data> GetUserInterests(int userId)
        {
            return _interestContext.GetUserInterests(userId);
        }

        public List<TRS_Domain.INTEREST.Data> GetUserCategoryInterests(int categoryId, int userId)
        {
            return _interestContext.GetUserCategoryInterests(categoryId, userId);
        }

        public void ClearUserInterests(int userId)
        {
            _interestContext.ClearUserInterests(userId);
        }

        public void InsertUserInterest(int userId, int interestId)
        {
            _interestContext.AddUserInterest(userId, interestId);
        }

        public void CreateNewInterest(string interestName, int interestCategoryId)
        {
            _interestContext.AddNewInterest(interestName, interestCategoryId);
        }

        public void VerifyInterst(int interestId)
        {
            _interestContext.VerifyInterest(interestId);
        }

        public void UnVerifyInterest(int interestId)
        {
            _interestContext.UnVerifyInterest(interestId);
        }
    }
}
