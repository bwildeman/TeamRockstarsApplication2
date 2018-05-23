using System;
using System.Collections.Generic;
using System.Windows.Controls;
using TRS_DAL.REPOSITORIES;
using TRS_Domain.GROUP;
using TRS_Domain.USER;

namespace TRS_Logic
{
    public class Group_Logic
    {
        //  Add DAL reference:
        GroupRepository groupRepo = new GroupRepository();
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

        public bool CreateGroup(int clientID, string Name, string Description, byte[] bitMap)
        {
            //  Define output:
            bool output = false;

            //  Try-Catch for safety:
            try
            {
                if (!string.IsNullOrEmpty((Name)) && !string.IsNullOrEmpty(Description))
                {
                    if (bitMap != null)
                    {
                        try
                        {
                            output = groupRepo.AddGroupWithPic(clientID, Name, Description, bitMap);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        groupRepo.AddGroup(clientID, Name, Description);
                        output = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }
    }
}
