using System;
using System.Collections.Generic;
using TRS_DAL.REPOSITORIES;
using TRS_Domain.EXCEPTIONS;

namespace TRS_Logic
{
    public class Group_Logic
    {
        //  Add reference:
        GroupRepository groupRepo = new GroupRepository();
        ExceptionHandler exHandler = new ExceptionHandler();

        public int ChangeChannel(int currentIndex, int minEnumValue, int maxEnumValue, bool ChannelUp)
        {
            if (ChannelUp)
            {
                if (currentIndex == maxEnumValue)
                {
                    return minEnumValue;
                }
                else
                {
                    return currentIndex + 1;
                }
            }
            else
            {
                if (currentIndex == minEnumValue)
                {
                    return maxEnumValue;
                }
                else
                {
                    return currentIndex - 1;
                }
            }
        }

        public List<TRS_Domain.GROUP.Data> GetAllGroupsThatUserIsNotIn(int UserID)
        {
            return groupRepo.GetAllGroupsThatUserIsNotIn(UserID);
        }

        public bool JoinGroup(TRS_Domain.USER.Data client,TRS_Domain.GROUP.Data Group)
        {
            return groupRepo.JoinGroup(client,Group);
        }

        public void Leavegroup(int userid, int groupid)
        {
            groupRepo.LeaveGroup(userid,groupid);
        }
        public bool CreateGroup(TRS_Domain.USER.Data client, string Name, string Description, object selectedInterest, string picturePath, byte[] bitMap, string region)
        {
            //  Define output:
            bool output = false;

            //  Try-Catch for safety:
            try
            {
                //  ExHanding:
                if (exHandler.NewGroup(Name, Description, selectedInterest, picturePath))
                {
                    if (bitMap != null)
                    {
                        output = groupRepo.AddGroup(client, Name, Description, bitMap, region);
                    }
                    else
                    {
                        output = groupRepo.AddGroup(client, Name, Description, region);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }
    }
}
