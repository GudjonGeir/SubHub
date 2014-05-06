using SubHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.DAL
{
    public class SubHubDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<SubHubContext>
    {
        protected override void Seed(SubHubContext context)
        {
            
            //User user1 = new User { Email = "user1@user1.com", Password = "1234", Name = "User1", UserName = "User1", DateCreated = DateTime.Now.AddDays(-5) };
            //User user2 = new User { Email = "user2@user2.com", Password = "1234", Name = "User2", UserName = "User2", DateCreated = DateTime.Now.AddDays(-10) };
            //User user3 = new User { Email = "user3@user3.com", Password = "1234", Name = "User3", UserName = "User3", DateCreated = DateTime.Now.AddDays(-20) };
            //var users = new List<User>() { user1, user2, user3 };

            //Comment comment1 = new Comment { CommentText = "Very cool", DateSubmitted = DateTime.Now.AddDays(-3), User = user1 };
            //Comment comment2 = new Comment { CommentText = "Not very cool", DateSubmitted = DateTime.Now.AddDays(-2), User = user2 };
            //Comment comment3 = new Comment { CommentText = "Not not very cool", DateSubmitted = DateTime.Now.AddDays(-1), User = user3 };
            //var comments = new List<Comment>() { comment1, comment2, comment3 };

            //Request request1 = new Request { Completed = false, DateSubmitted = DateTime.Now.AddDays(-3), Name = "Avatar", User = user1 };
            //Request request2 = new Request { Completed = true, DateSubmitted = DateTime.Now.AddDays(-4), Name = "Catch me if you can", User = user2 };
            //Request request3 = new Request { Completed = false, DateSubmitted = DateTime.Now.AddDays(-5), Name = "Highlander", User = user3 };
            //var requests = new List<Request>() { request1, request2, request3 };

            //RequestRating requestRating1 = new RequestRating { count = 2, Users = new List<User>() { user1, user2 }, RequestId = 1 };
            //RequestRating requestRating2 = new RequestRating { count = 3, Users = new List<User>() { user1, user2, user3 }, RequestId = 2 };
            //RequestRating requestRating3 = new RequestRating { count = 1, Users = new List<User>() { user1 }, RequestId = 3 };
            //var requestRatings = new List<RequestRating>() { requestRating1, requestRating2, requestRating3 };

            Subtitle subtitle1 = new Subtitle { Name = "Catch me if you can", DateAired = new DateTime(2002, 12, 25), DateSubmitted = DateTime.Now.AddDays(-3), Genre = "Biography", ImdbUrl = "http://www.imdb.com/title/tt0264464/?ref_=nv_sr_1", Language = "English", PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTY5MzYzNjc5NV5BMl5BanBnXkFtZTYwNTUyNTc2._V1_SX640_SY720_.jpg", Type = "Movie" };
            Subtitle subtitle2 = new Subtitle { Name = "The Notebook", DateAired = new DateTime(2003, 06, 25), DateSubmitted = DateTime.Now.AddDays(-10), Genre = "Romace", ImdbUrl = "http://www.imdb.com/title/tt0332280/?ref_=nv_sr_1", Language = "English", PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUwMDg3OTA2N15BMl5BanBnXkFtZTcwNzc5OTYwOQ@@._V1_SX640_SY720_.jpg", Type = "Movie" };
            Subtitle subtitle3 = new Subtitle { Name = "The Matrix", DateAired = new DateTime(1999, 3, 21), DateSubmitted = DateTime.Now.AddDays(-13), Genre = "Sci-Fi", ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", Language = "English", PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTkxNDYxOTA4M15BMl5BanBnXkFtZTgwNTk0NzQxMTE@._V1_SX640_SY720_.jpg", Type = "Movie" };
            var subtitles = new List<Subtitle>() { subtitle1, subtitle2, subtitle3 };
            subtitles.ForEach(s => context.Subtitles.Add(s));

            //SubtitleLine subtitle1Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "(WATER SPLASHES)", LineTwo = "", SubtitleId = 1 };
            //SubtitleLine subtitle1Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "(LILTING MELODY PLAYED ON ACOUSTIC GUITAR)", LineTwo = "", SubtitleId = 1 };
            //SubtitleLine subtitle1Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "(VIOLINS JOIN IN)", LineTwo = "(FRENCH HORNS PLAYING)", SubtitleId = 1 };

            //SubtitleLine subtitle2Line1 = new SubtitleLine { LineNumber = 1, Time = "00:02:57,210 --> 00:02:59,576", LineOne = "Excuse me.", LineTwo = "", SubtitleId = 2 };
            //SubtitleLine subtitle2Line2 = new SubtitleLine { LineNumber = 2, Time = "00:03:02,081 --> 00:03:05,209", LineOne = "Come on, honey, let's", LineTwo = "get you ready for bed.", SubtitleId = 2 };
            //SubtitleLine subtitle2Line3 = new SubtitleLine { LineNumber = 3, Time = "00:03:17,664 --> 00:03:19,757", LineOne = "I am no one special,", LineTwo = "", SubtitleId = 2 };

            //SubtitleLine subtitle3Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:48,300 --> 00:00:50,550", LineOne = "<i>- Yeah.", LineTwo = "- Is everything in place?</i>", SubtitleId = 3 };
            //SubtitleLine subtitle3Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:50,552 --> 00:00:52,363", LineOne = "<i>You weren't supposed to relieve me.</i>", LineTwo = "", SubtitleId = 3 };
            //SubtitleLine subtitle3Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:52,613 --> 00:00:55,640", LineOne = "<i>I know,", LineTwo = "but I felt like taking your shift.</i>", SubtitleId = 3 };
            //var subtitleLiness = new List<SubtitleLine>() { subtitle1Line1, subtitle1Line2, subtitle1Line3, subtitle2Line1, subtitle2Line2, subtitle2Line3, subtitle3Line1, subtitle3Line2, subtitle3Line3 };

            //SubtitleRating subtitleRating1 = new SubtitleRating { Count = 2, SubtitleId = 1, Users = new List<User>() { user1, user2 } };
            //SubtitleRating subtitleRating2 = new SubtitleRating { Count = 1, SubtitleId = 2, Users = new List<User>() { user2 } };
            //SubtitleRating subtitleRating3 = new SubtitleRating { Count = 2, SubtitleId = 1, Users = new List<User>() { user3, user2 } };
            //var subtitleRatings = new List<SubtitleRating>() { subtitleRating1, subtitleRating2, subtitleRating3 };
            //users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }
}
