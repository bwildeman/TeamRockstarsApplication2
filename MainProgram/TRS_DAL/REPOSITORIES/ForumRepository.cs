using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TRS_DAL.CONTEXT;
using TRS_DAL.INTERFACES;

namespace TRS_DAL.REPOSITORIES
{
    public class ForumRepository
    {
        IForumContext forumContext = new ForumSqlContext();
        public void NewPost(int forumID, int userID, string title, string postText)
        {
            forumContext.NewPost(forumID, userID, title, postText);
        }

        public void NewComment(int userId, int postId, string comment)
        {
            forumContext.NewComment(userId,postId,comment);
        }

        public void NewForum(string forumName, int groupID)
        {
            forumContext.NewForum(forumName,groupID);
        }

        public List<DataRow> SelectAllPostData(int forumId)
        {
            return forumContext.SelectAllPostData(forumId);
        }

        public List<DataRow> SelectPostVotes(int forumId)
        {
            return forumContext.SelectPostVotes(forumId);
        }

        public List<DataRow> SelectCommentVotes(int postId)
        {
            return forumContext.SelectCommentVotes(postId);
        }

        public List<DataRow> SelectForums(int groupID)
        {
            return forumContext.SelectForums(groupID);
        }

        public List<DataRow> SelectComments(int postId)
        {
            return forumContext.SelectComments(postId);
        }

        public void VotePost(int userId, int postId, int VoteValue)
        {
            forumContext.VotePost(userId,postId,VoteValue);
        }

        public void VoteComment(int userId, int postId, int commentId, int VoteValue)
        {
            forumContext.VoteComment(userId,postId,commentId,VoteValue);
        }

        public void UpdateVote(int VoteId)
        {
            forumContext.UpdateVote(VoteId);
        }

        public List<DataRow> UserHasVotedPost(int userId, int postId)
        {
            return forumContext.UserHasVotedPost(userId,postId);
        }

        public List<DataRow> UserHasVotedComment(int userId, int postId, int commentId)
        {
            return forumContext.UserHasVotedComment(userId,postId,commentId);
        }

        public List<DataRow> GetGroups(int userID)
        {
            return forumContext.GetGroups(userID);
            //TODO move to group sql
        }

        public List<DataRow> GetGroupNames(int groupID)
        {
            return forumContext.GetGroupNames(groupID);
            //TODO move to group sql
        }
    }
}
