using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using TRS_DAL.INTERFACES;

namespace TRS_DAL.CONTEXT
{
    public class ForumSqlContext : IForumContext
    {
        public List<DataRow> GetGroupNames(int groupID)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("groupID", groupID));
            return SQL.ExecuteQuery($"SELECT groups.GroupName FROM groups WHERE groups.GroupID = @groupID ", parameters);
            //is niet meer nodig considering dat we maar een forum per groep hebben en deze dus kunnen autogenereren
        }

        public List<DataRow> GetGroups(int userID)
        {
            //is niet meer nodig considering dat we maar een forum per groep hebben en deze dus kunnen autogenereren
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("userID", userID));
            return SQL.ExecuteQuery($"SELECT * FROM group_members WHERE group_members.UserID = @userID",parameters);
        }

        public void NewComment(int userId, int postId, string comment)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@userID", userId));
            parameters.Add(new MySqlParameter("@postID", postId));
            parameters.Add(new MySqlParameter("@comment", comment));
            SQL.ExecuteNonQuery($"INSERT INTO forum_comment (forum_comment.UserID, forum_comment.PostID, forum_comment.Comment, forum_comment.Date) VALUES (@userID, @postID, @comment ,CURRENT_TIMESTAMP);", parameters);
        }

        public void NewForum(string forumName, int groupID)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@forumName", forumName));
            parameters.Add(new MySqlParameter("@groupID", groupID));
            SQL.ExecuteNonQuery($"INSERT INTO forum (forum.GroupID, forum.ForumName) VALUES(@groupID, @forumName);", parameters);
        }

        public void NewPost(int forumID, int userID, string title, string postText)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@forumID", forumID));
            parameters.Add(new MySqlParameter("@userId", userID));
            parameters.Add(new MySqlParameter("@title", title));
            parameters.Add(new MySqlParameter("@postText", postText));
            SQL.ExecuteNonQuery("INSERT INTO `forum_posts` (`ForumID`, `PostCreator`, `PostTitle`, `PostText`, `post_TimeStamp`) VALUES (@forumID, @userId, @title, @postText, CURRENT_TIMESTAMP);", parameters);
        }

        public List<DataRow> SelectAllPostData(int forumId)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("forumId",forumId));
            return SQL.ExecuteQuery($"SELECT * FROM forum_posts WHERE forum_posts.ForumID = @forumId", parameters);
        }

        public List<DataRow> SelectComments(int postId)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("postId", postId));
            return SQL.ExecuteQuery($"SELECT forum_comment.UserID, forum_comment.Comment, forum_comment.Date,forum_comment.CommentID, users.UserName FROM forum_comment LEFT JOIN users on forum_comment.UserID = users.UserID WHERE forum_comment.PostID = @postId", parameters);
        }

        public List<DataRow> SelectCommentVotes(int postId)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("postId", postId));
            return SQL.ExecuteQuery($"SELECT forum_votes.CommentID, SUM( CASE WHEN votevalue = 1 THEN 1 ELSE 0 END ) AS upvotes, SUM( CASE WHEN votevalue = 0 THEN 1 ELSE 0 END ) AS downvotes FROM forum_votes INNER JOIN forum_comment ON forum_comment.CommentID = forum_votes.CommentID WHERE forum_comment.PostID = @postId GROUP BY forum_votes.CommentID", parameters);
        }

        public List<DataRow> SelectForums(int groupID)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("groupID", groupID));
            return SQL.ExecuteQuery($"SELECT * FROM forum WHERE forum.GroupID = @groupID ", parameters);
        }

        public List<DataRow> SelectPostVotes(int forumId)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("forumId", forumId));
            return SQL.ExecuteQuery($"SELECT forum_votes.PostID, SUM( CASE WHEN votevalue = 1 THEN 1 ELSE 0 END ) AS upvotes, SUM( CASE WHEN votevalue = 0 THEN 1 ELSE 0 END ) AS downvotes FROM forum_votes INNER JOIN forum_posts on forum_posts.PostID = forum_votes.PostID WHERE forum_votes.CommentID IS NULL and forum_posts.ForumID = @forumId GROUP BY forum_votes.PostID", parameters);
        }

        public void UpdateVote(int VoteId)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("VoteId", VoteId));
            SQL.ExecuteNonQuery($"UPDATE forum_votes SET forum_votes.VoteValue = IF(forum_votes.VoteValue = 1, 0, 1) WHERE forum_votes.VoteID = @VoteId",parameters);
        }

        public List<DataRow> UserHasVotedComment(int userId, int postId, int commentId)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("userId", userId));
            parameters.Add(new MySqlParameter("postId", postId));
            return SQL.ExecuteQuery($"SELECT * FROM forum_votes WHERE forum_votes.PostID = @postId AND forum_votes.UserID = @userId and forum_votes.CommentID is null", parameters);
        }

        public List<DataRow> UserHasVotedPost(int userId, int postId)
        {
            throw new NotImplementedException();
        }

        public void VoteComment(int userId, int postId, int commentId, int VoteValue)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("userId", userId));
            parameters.Add(new MySqlParameter("postId", postId));
            parameters.Add(new MySqlParameter("commentId", commentId));
            parameters.Add(new MySqlParameter("VoteValue", VoteValue));
            SQL.ExecuteNonQuery($"INSERT INTO forum_votes( `UserID`, `PostID`, `CommentID`, `VoteValue` ) VALUES(@userId, @postId, @commentId, @VoteValue)",parameters);
        }

        public void VotePost(int userId, int postId, int VoteValue)
        {
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("userId", userId));
            parameters.Add(new MySqlParameter("postId", postId));
            parameters.Add(new MySqlParameter("VoteValue", VoteValue));
            SQL.ExecuteNonQuery($"INSERT INTO forum_votes( `UserID`, `PostID`, `CommentID`, `VoteValue` ) VALUES(@userId, @postId, NULL, @VoteValue)",parameters);
        }
    }
}
