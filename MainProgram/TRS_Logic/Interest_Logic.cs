using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Controls.Primitives;
using TRS_Domain;
using TRS_DAL;
using TRS_DAL.REPOSITORIES;
using TRS_Domain.INTEREST;

namespace TRS_Logic
{
    public class InterestLogic
    {
        // Add DAL reference
        InterestRepository _interestRepo = new InterestRepository();

        public List<TRS_Domain.INTEREST.Data> GetAllVerifiedInterests()
        {
            return _interestRepo.GetAllVerifiedInterests();
        }

        public List<TRS_Domain.INTEREST.Data> GetAllNotVerifiedInterests()
        {
            return _interestRepo.GetAllNotVerifiedInterests();
        }

        public List<TRS_Domain.CATEGORY.Data> GetAllInterestCategories()
        {
            return _interestRepo.GetAllCategories();
        }

        public List<TRS_Domain.INTEREST.Data> GetAllUsertInterests(int userId)
        {
            return _interestRepo.GetUserInterests(userId);
        }

        public List<TRS_Domain.INTEREST.Data> GetUserCategoryInterests(int categoryId, int userId)
        {
            // get category interests
            List<TRS_Domain.INTEREST.Data> categoryInterests = new List<Data>(_interestRepo.GetUserCategoryInterests(categoryId, userId));
            // get user interests
            List<TRS_Domain.INTEREST.Data> userInterests = new List<Data>(_interestRepo.GetUserInterests(userId));

            foreach (var s in userInterests)
            {
                // check if categoryInterest already exists in user interest list
                categoryInterests.RemoveAll((x) => x.InterestId == s.InterestId);
            }

            return categoryInterests;
        }

        public void SaveInterests(List<TRS_Domain.INTEREST.Data> interests, int userId)
        {
            // clear existing interests
            _interestRepo.ClearUserInterests(userId);
            // insert interest list
            foreach (var variable in interests)
            {
                _interestRepo.InsertUserInterest(userId, variable.InterestId);
            }
        }

        public void AddUsertInterest(int userId, TRS_Domain.INTEREST.Data interest)
        {
            _interestRepo.InsertUserInterest(userId, interest.InterestId);
        }

        public void CreateNewInterest(string interestName, int categoryId)
        {
            _interestRepo.CreateNewInterest(interestName, categoryId);
        }

        public void VerifyInterest(int interestId)
        {
            _interestRepo.VerifyInterst(interestId);
        }

        public void UnVerifyInterest(int interestId)
        {
            _interestRepo.UnVerifyInterest(interestId);
        }
    }
}
