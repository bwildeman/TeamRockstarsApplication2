using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.FORUM
{
    public class Post
    {
        public int _postID { get; }
        public int _votes { get; }
        public DateTime date { get; set; }
        public string _titel { get; private set; }
        public string _content;

        public Post(int postID, int votes, string datum, string titel, string content)
        {
            _postID = postID;
            _votes = votes;
            date = Convert.ToDateTime(datum);
            _titel = titel;
            _content = content;
        }
    }    
}
