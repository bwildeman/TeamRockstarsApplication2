using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.FORUM
{
    public class Forum
    {
        int _forumId;
        int _groupId;
        string _forumTitle;

        public Forum( int forumId, int groupId, string forumTitle)
        {
            _forumId = forumId;
            _groupId = groupId;
            _forumTitle = forumTitle;
        }

        public int ForumId { get => _forumId;}
        public int GroupId { get => _groupId;}
        public string ForumTitle { get => _forumTitle;}
    }
}
