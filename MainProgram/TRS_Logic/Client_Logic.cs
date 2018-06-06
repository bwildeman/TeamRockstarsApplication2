using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.CHAT;
using TRS_Domain.EVENT;
using TRS_DAL.REPOSITORIES;

namespace TRS_Logic
{
    public class ClientLogic
    {
        //  Add DAL reference:
        UserRepository _userRepo = new UserRepository();
        ChatRepository _chatRepo = new ChatRepository();
        EventRepository _eventRepo = new EventRepository();
        GroupRepository _groupRepo = new GroupRepository();

        public TRS_Domain.USER.Data LoadClient(int clientId)
        {
            //  Define output:
            TRS_Domain.USER.Data output = new TRS_Domain.USER.Data();

            output = _userRepo.GetUser(clientId);
            output.SetGroups(_groupRepo.GetGroups(output.UserId));

            return output;
        }
    }
}
