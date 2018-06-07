using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.INTERFACES;
using TRS_Domain.CHANNEL;

namespace TRS_DAL.CONTEXT
{
    public class ChannelContext : IChannelContext
    {
        ConnectionDB ConnectDB = new ConnectionDB();

        public void AddChannel(string Name, string Description, int type)
        {
            throw new System.NotImplementedException();

            //een event forum of chat toevoegen en de trigger voegt de channel toe
        }

        public void DeleteChannel(int groupId, int Id)
        {
            throw new System.NotImplementedException();
        }

        public Channel GetChannel(int groupId, int Id)
        {
            //bij de parameters moet het type erbij
            //dit haalt de data op van de channel
            throw new System.NotImplementedException();
        }

        public Channel[] GetChannels(int groupId)
        {

            //haalt alle data van alle channels van een groep op
            throw new System.NotImplementedException();
        }

        public void UpdateDescription(string newDescription)
        {
            //past de description van een channel aan
            throw new System.NotImplementedException();
        }

        public void UpdateName(string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}
