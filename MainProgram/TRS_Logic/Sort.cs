using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.FORUM;

namespace TRS_Logic
{
    public class Sort
    {
        //sorteert de posts naar upvotes
        public class SortByPostUpVotes : IComparer<Post>
        {
            public int Compare(Post c1, Post c2)
            {
                return c1._upvotes.CompareTo(c2._upvotes);
            }
            public int Compare(Comment c1, Comment c2)
            {
                return c1._upvotes.CompareTo(c2._upvotes);
            }
        }
        //sorteert de comment naar Upvotes
        public class SortByCommentUpVotes : IComparer<Comment>
        {
            public int Compare(Comment c1, Comment c2)
            {
                return c1._upvotes.CompareTo(c2._upvotes);
            }
        }
        //sorteert de posts naar Downvotes
        public class SortByPostDownVotes : IComparer<Post>
        {
            public int Compare(Post c1, Post c2)
            {
                return c1._downvotes.CompareTo(c2._downvotes);
            }
        }
        //sorteert de comment naar Downvotes
        public class SortByCommentDownVotes : IComparer<Comment>
        {
            public int Compare(Comment c1, Comment c2)
            {
                return c1._downvotes.CompareTo(c2._downvotes);
            }
        }
        //sorteert de posts naar tijd
        public class SortPostByTime : IComparer<Post>
        {
            public int Compare(Post c1, Post c2)
            {
                return c1.date.CompareTo(c2.date);
            }
        }
        //sorteert de comment naar tijd
        public class SortCommentByTime : IComparer<Comment>
        {
            public int Compare(Comment c1, Comment c2)
            {
                return c1.date.CompareTo(c2.date);
            }
        }
    }
}
