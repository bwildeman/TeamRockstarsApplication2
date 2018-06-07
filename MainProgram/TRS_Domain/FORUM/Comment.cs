using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.FORUM
{
    public class Comment 
    {
        public int _commentID { get; }
        public int _upvotes { get; }
        public int _downvotes { get; }
        public DateTime date { get;}
        public string _content { get;}
        public string _commentPlacerName { get; }

        public Comment(int upvotes, int downvotes, string datum, string content, string user, int commentID)
        {
            _upvotes = Convert.ToInt32(upvotes);
            _downvotes = Convert.ToInt32(downvotes);
            date = Convert.ToDateTime(datum);
            _content = content;
            _commentPlacerName = user;
            _commentID = commentID;

        }

    }
}
