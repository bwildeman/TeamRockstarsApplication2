using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.REPOSITORIES;
using TRS_Domain.GROUP;

namespace TRS_Logic
{
    public class GroupControl_Logic
    {
        private static GroupRepository GP = new GroupRepository();

        public static Data GetGroupInformation(int id)
        {
            return GP.GetGroupInfo(id);
        }

        public static void SaveGroupName(int id, string text)
        {
            GP.UpdateName(id, text);
        }

        public static void SaveGroupRegion(int id, string region)
        {
            GP.UpdateRegion(id, region);
        }

        public static void SaveDescription(int id, string description)
        {
            GP.UpdateDescription(id, description);
        }

        public static void ChangeStartUpChannel(int id, string selectedValue)
        {
            GP.UpdateStartUpChannel(selectedValue);
        }

        public enum Regions
        {
            North,
            South,
            East,
            West
        }
    }
}
