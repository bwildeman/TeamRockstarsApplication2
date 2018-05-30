using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TRS_DAL.INTERFACES;

namespace TRS_DAL.CONTEXT
{
    public class ForumSqlContext : IForumContext
    {
        public List<DataRow> GetGroupNames(int groupID)
        {
            throw new NotImplementedException();
        }

        public List<DataRow> GetGroups(int userID)
        {
            throw new NotImplementedException();
        }

        public void NewComment(int userId, int postId, string comment)
        {
            throw new NotImplementedException();
        }

        public void NewForum(string forumName, int groupID)
        {
            throw new NotImplementedException();
        }

        public void NewPost(int forumID, int userID, string title, string postText)
        {
            throw new NotImplementedException();
        }

        public List<DataRow> SelectAllPostData(int forumId)
        {
            throw new NotImplementedException();
        }

        public List<DataRow> SelectComments(int postId)
        {
            throw new NotImplementedException();
        }

        public List<DataRow> SelectCommentVotes(int postId)
        {
            throw new NotImplementedException();
        }

        public List<DataRow> SelectForums(int groupID)
        {
            throw new NotImplementedException();
        }

        public List<DataRow> SelectPostVotes(int forumId)
        {
            throw new NotImplementedException();
        }

        public void UpdateVote(int VoteId)
        {
            throw new NotImplementedException();
        }

        public List<DataRow> UserHasVotedComment(int userId, int postId, int commentId)
        {
            throw new NotImplementedException();
        }

        public List<DataRow> UserHasVotedPost(int userId, int postId)
        {
            throw new NotImplementedException();
        }

        public void VoteComment(int userId, int postId, int commentId, int VoteValue)
        {
            throw new NotImplementedException();
        }

        public void VotePost(int userId, int postId, int VoteValue)
        {
            throw new NotImplementedException();
        }
    }
}
