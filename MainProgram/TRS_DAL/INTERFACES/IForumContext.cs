using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IForumContext
    {
        void NewPost(int forumID, int userID, string title, string postText);

        void NewComment(int userId, int postId, string comment);

        void NewForum(string forumName, int groupID);

        List<DataRow> SelectAllPostData(int forumId);

        List<DataRow> SelectPostVotes(int forumId);

        List<DataRow> SelectCommentVotes(int postId);

        List<DataRow> SelectForums(int groupID);

        List<DataRow> SelectComments(int postId);

        void VotePost(int userId, int postId, int VoteValue);

        void VoteComment(int userId, int postId, int commentId, int VoteValue);

        void UpdateVote(int VoteId);

        List<DataRow> UserHasVotedPost(int userId, int postId);

        List<DataRow> UserHasVotedComment(int userId, int postId, int commentId);

        List<DataRow> GetGroups(int userID);

        List<DataRow> GetGroupNames(int groupID)
    }
}
