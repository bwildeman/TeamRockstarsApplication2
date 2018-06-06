using System.Collections.Generic;
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

        public List<TRS_Domain.EVENT.Data> GetAllEvents(int groupId)
        {
            //Todo create event space in database



            //TODO remove following code;
            List<TRS_Domain.EVENT.Data> output = new List<TRS_Domain.EVENT.Data>
            {
                new TRS_Domain.EVENT.Data(1, "First event", "Descr"),
                new TRS_Domain.EVENT.Data(2, "Second event", "Descr"),
                new TRS_Domain.EVENT.Data(3, "Third event", "Descr")
            };

            return output;
        }
    }
}
