using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubHub.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SubHub.DAL
{
    public class SubHubDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<SubHubContext>
    {
        protected override void Seed(SubHubContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.Create(new ApplicationUser { UserName = "user1" }, "123456");
            userManager.Create(new ApplicationUser { UserName = "user2" }, "123456");
            userManager.Create(new ApplicationUser { UserName = "user3" }, "123456");


            


            MediaType movies = new MediaType { Type = "Movie" };
            MediaType tvShows = new MediaType { Type = "TvShow" };
            var mediaTypes = new List<MediaType>() { movies, tvShows };
            mediaTypes.ForEach(m => context.MediaTypes.Add(m));
            context.SaveChanges();

            SubtitleLanguage english = new SubtitleLanguage { Language = "English" };
            SubtitleLanguage icelandic = new SubtitleLanguage { Language = "Icelandic" };
            var mediaLanguages = new List<SubtitleLanguage>() { english, icelandic };
            mediaLanguages.ForEach(m => context.MediaLanguages.Add(m));
            context.SaveChanges();


            MediaGenre adventures = new MediaGenre { Genre = "Adventures" };   //1
            MediaGenre biography = new MediaGenre { Genre = "Biography" };    //2
            MediaGenre children = new MediaGenre { Genre = "Children" };     //3
            MediaGenre comedy = new MediaGenre { Genre = "Comedy" };        //4
            MediaGenre drama = new MediaGenre { Genre = "Drama" };         //5
            MediaGenre horror = new MediaGenre { Genre = "Horror" };      //6
            MediaGenre romance = new MediaGenre { Genre = "Romance "};   //7
            MediaGenre scifi = new MediaGenre { Genre = "Sci-Fi" };     //8
            MediaGenre thriller = new MediaGenre { Genre = "Thriller" }; //9
            var genres = new List<MediaGenre>() { adventures, biography, children, comedy, drama, horror, romance, scifi, thriller };
            genres.ForEach(g => context.MediaGenres.Add(g));
            context.SaveChanges();


            Request request1 = new Request { Completed = false, DateSubmitted = DateTime.Now.AddDays(-3), Name = "Avatar", User = userManager.FindByName("user1"), LanguageId = 1 };
            Request request2 = new Request { Completed = true, DateSubmitted = DateTime.Now.AddDays(-4), Name = "Catch me if you can", User = userManager.FindByName("user3"), LanguageId = 2 };
            Request request3 = new Request { Completed = false, DateSubmitted = DateTime.Now.AddDays(-5), Name = "Highlander", User = userManager.FindByName("user2") , LanguageId = 1};
            var requests = new List<Request>() { request1, request2, request3 };
            requests.ForEach(r => context.Requests.Add(r));
            context.SaveChanges();


            RequestRating requestRating1 = new RequestRating { count = 2, RequestId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user2"), userManager.FindByName("user3") } };
            RequestRating requestRating2 = new RequestRating { count = 3, RequestId = 2, Users = new List<ApplicationUser> { userManager.FindByName("user1"), userManager.FindByName("user2"), userManager.FindByName("user3") } };
            RequestRating requestRating3 = new RequestRating { count = 1, RequestId = 3, Users = new List<ApplicationUser> { userManager.FindByName("user3") } };
            var requestRatings = new List<RequestRating>() { requestRating1, requestRating2, requestRating3 };
            requestRatings.ForEach(r => context.RequestRatings.Add(r));
            context.SaveChanges();


            Media media1 = new Media { Name = "Catch me if you can", DateAired = new DateTime(2002, 12, 25), ImdbUrl = "http://www.imdb.com/title/tt0264464/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTY5MzYzNjc5NV5BMl5BanBnXkFtZTYwNTUyNTc2._V1_SX640_SY720_.jpg", GenreId = 2 };
            Media media2 = new Media { Name = "The Notebook", DateAired = new DateTime(2003, 06, 25), ImdbUrl = "http://www.imdb.com/title/tt0332280/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUwMDg3OTA2N15BMl5BanBnXkFtZTcwNzc5OTYwOQ@@._V1_SX640_SY720_.jpg", GenreId = 5 };
            Media media3 = new Media { Name = "The Matrix", DateAired = new DateTime(1999, 03, 21), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTkxNDYxOTA4M15BMl5BanBnXkFtZTgwNTk0NzQxMTE@._V1_SX640_SY720_.jpg" , GenreId = 8 };
            Media media4 = new Media { Name = "The Godfather", DateAired = new DateTime(1972, 03, 24), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjEyMjcyNDI4MF5BMl5BanBnXkFtZTcwMDA5Mzg3OA@@._V1__SX640_SY720_.jpg", GenreId = 5 };
            Media media5 = new Media { Name = "Gladiator", DateAired = new DateTime(2000, 05, 02), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTgwMzQzNTQ1Ml5BMl5BanBnXkFtZTgwMDY2NTYxMTE@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 1 };
            Media media6 = new Media { Name = "The Lion King", DateAired = new DateTime(1994, 07, 24), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjEyMzgwNTUzMl5BMl5BanBnXkFtZTcwNTMxMzM3Ng@@._V1_SY98_CR4,0,67,98_AL_.jpg", GenreId = 3 };
            Media media7 = new Media { Name = "WALL-E", DateAired = new DateTime(2008, 06, 24), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTczOTA3MzY2N15BMl5BanBnXkFtZTcwOTYwNjE2MQ@@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 3 };
            Media media8 = new Media { Name = "The Wolf of Wall Street", DateAired = new DateTime(2013, 12, 25), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 4 };
            Media media9 = new Media { Name = "Toy Story", DateAired = new DateTime(1995, 11, 22), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTgwMjI4MzU5N15BMl5BanBnXkFtZTcwMTMyNTk3OA@@._V1_SY98_CR3,0,67,98_AL_.jpg", GenreId = 3 };
            Media media10 = new Media { Name = "Die Hart", DateAired = new DateTime(1988, 07, 22), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTY4ODM0OTc2M15BMl5BanBnXkFtZTcwNzE0MTk3OA@@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 9 };
            Media media11 = new Media { Name = "The Avengers", DateAired = new DateTime(2012, 05, 04), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTk2NTI1MTU4N15BMl5BanBnXkFtZTcwODg0OTY0Nw@@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 3 };
            Media media12 = new Media { Name = "Gravity", DateAired = new DateTime(2013, 10, 04), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BNjE5MzYwMzYxMF5BMl5BanBnXkFtZTcwOTk4MTk0OQ@@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 1 };
            Media media13 = new Media { Name = "Game of Thrones: S03E01", DateAired = new DateTime(2013, 03, 31), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTk4NjcwMzAzN15BMl5BanBnXkFtZTcwNzgxNTcyOQ@@._V1_SY317_CR131,0,214,317_AL_.jpg", GenreId = 1 };
            Media media14 = new Media { Name = "Arrow: S02E01", DateAired = new DateTime(2013, 10, 09), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUxODEwMzU5Ml5BMl5BanBnXkFtZTgwODYwMTczMDE@._V1_SX640_SY720_.jpg", GenreId = 9 };
            Media media15 = new Media { Name = "Greys Anatomy: S06E03", DateAired = new DateTime(2009, 10, 01), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BNjQ0OTU5OTE0M15BMl5BanBnXkFtZTcwMzEzNTc4Mg@@._V1_SX640_SY720_.jpg", GenreId = 9 };
            Media media16 = new Media { Name = "The Blacklist: S01E04", DateAired = new DateTime(2013, 10, 14), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjEwNjM3NTc5NV5BMl5BanBnXkFtZTgwOTU4MDczMDE@._V1_SX640_SY720_.jpg", GenreId = 1 };
            Media media17 = new Media { Name = "Friends: S09E04", DateAired = new DateTime(2002, 10, 17), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTczNzcxOTI5OV5BMl5BanBnXkFtZTcwOTk2NzcyMQ@@._V1_SX640_SY720_.jpg", GenreId = 5 };           
            Media media18 = new Media { Name = "The Big Bang Theory: S07E02", DateAired = new DateTime(2013, 09, 26), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BODk0MjU1MDk3OV5BMl5BanBnXkFtZTgwMjYwNjIzMDE@._V1_SX640_SY720_.jpg", GenreId = 9 };
            var medias = new List<Media>() { media1, media2, media3, media4, media5, media6, media7, media8, media9, media10, media11, media12, media13, media14, media15, media16, media17, media18 };
            medias.ForEach(m => context.Medias.Add(m));
            context.SaveChanges();

            Subtitle subtitle1 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-3), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1") }, MediaId = 1 };
            Subtitle subtitle2 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-10),LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1"), userManager.FindByName("user2") }, MediaId = 2 };
            Subtitle subtitle3 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-13), LanguageId = 2, Users = new List<ApplicationUser> { userManager.FindByName("user2"), userManager.FindByName("user3") }, MediaId = 3 };
            Subtitle subtitle4 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-1), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1") }, MediaId = 4 };
            Subtitle subtitle5 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-3), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1") }, MediaId = 5 };
            Subtitle subtitle6 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-5), LanguageId = 2, Users = new List<ApplicationUser> { userManager.FindByName("user1"), userManager.FindByName("user2") }, MediaId = 6 };
            Subtitle subtitle7 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-1), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1") }, MediaId = 7 };
            Subtitle subtitle8 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-8), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1") }, MediaId = 8 };
            Subtitle subtitle9 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-2), LanguageId = 2, Users = new List<ApplicationUser> { userManager.FindByName("user2"), userManager.FindByName("user3") }, MediaId = 9 };
            Subtitle subtitle10 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-4), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1") }, MediaId = 10 };
            Subtitle subtitle11 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-9), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user3") }, MediaId = 11 };
            Subtitle subtitle12 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-2), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1"), userManager.FindByName("user2") }, MediaId = 12 };
            Subtitle subtitle13 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-6), LanguageId = 2, Users = new List<ApplicationUser> { userManager.FindByName("user1") }, MediaId = 13 };
            Subtitle subtitle14 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-13), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user2"), userManager.FindByName("user3") }, MediaId = 14 };
            Subtitle subtitle15 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-7), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1") }, MediaId = 15 };
            Subtitle subtitle16 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-1), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user1"), userManager.FindByName("user2") }, MediaId = 16 };
            Subtitle subtitle17 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-2), LanguageId = 2, Users = new List<ApplicationUser> { userManager.FindByName("user3") }, MediaId = 17 };
            Subtitle subtitle18 = new Subtitle { DateSubmitted = DateTime.Now.AddDays(-3), LanguageId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user2"), userManager.FindByName("user3") }, MediaId = 18 };
            var subtitles = new List<Subtitle>() { subtitle1, subtitle2, subtitle3, subtitle4, subtitle5, subtitle6, subtitle7, subtitle8, subtitle9, subtitle10, subtitle11, subtitle12, subtitle13, subtitle14, subtitle15, subtitle16, subtitle17, subtitle18 };
            subtitles.ForEach(s => context.Subtitles.Add(s));
            context.SaveChanges();

            Comment comment1 = new Comment { CommentText = "Very cool", DateSubmitted = DateTime.Now.AddDays(-3), Subtitle = subtitle1, User = userManager.FindByName("user1"), SubtitleId = 1 };
            Comment comment2 = new Comment { CommentText = "Not very cool", DateSubmitted = DateTime.Now.AddDays(-2), Subtitle = subtitle2, User = userManager.FindByName("user2"), SubtitleId = 2 };
            Comment comment3 = new Comment { CommentText = "Not not very cool", DateSubmitted = DateTime.Now.AddDays(-1), Subtitle = subtitle3, User = userManager.FindByName("user3"), SubtitleId = 3 };
            var comments = new List<Comment>() { comment1, comment2, comment3 };
            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();

            SubtitleLine subtitle1Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "(WATER SPLASHES)", LineTwo = "", SubtitleId = 1 };
            SubtitleLine subtitle1Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "(LILTING MELODY PLAYED ON ACOUSTIC GUITAR)", LineTwo = "", SubtitleId = 1 };
            SubtitleLine subtitle1Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "(VIOLINS JOIN IN)", LineTwo = "(FRENCH HORNS PLAYING)", SubtitleId = 1 };

            SubtitleLine subtitle2Line1 = new SubtitleLine { LineNumber = 1, Time = "00:02:57,210 --> 00:02:59,576", LineOne = "Excuse me.", LineTwo = "", SubtitleId = 2 };
            SubtitleLine subtitle2Line2 = new SubtitleLine { LineNumber = 2, Time = "00:03:02,081 --> 00:03:05,209", LineOne = "Come on, honey, let's", LineTwo = "get you ready for bed.", SubtitleId = 2 };
            SubtitleLine subtitle2Line3 = new SubtitleLine { LineNumber = 3, Time = "00:03:17,664 --> 00:03:19,757", LineOne = "I am no one special,", LineTwo = "", SubtitleId = 2 };

            SubtitleLine subtitle3Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:48,300 --> 00:00:50,550", LineOne = "<i>- Yeah.", LineTwo = "- Is everything in place?</i>", SubtitleId = 3 };
            SubtitleLine subtitle3Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:50,552 --> 00:00:52,363", LineOne = "<i>You weren't supposed to relieve me.</i>", LineTwo = "", SubtitleId = 3 };
            SubtitleLine subtitle3Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:52,613 --> 00:00:55,640", LineOne = "<i>I know,", LineTwo = "but I felt like taking your shift.</i>", SubtitleId = 3 };
            
            SubtitleLine subtitle4Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "I love this weather", LineTwo = "", SubtitleId = 4 };
            SubtitleLine subtitle4Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "Thankyou comeagain", LineTwo = "", SubtitleId = 4 };
            SubtitleLine subtitle4Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "you have to destroy the brain..", LineTwo = "shoot 'em in the head", SubtitleId = 4 };

            SubtitleLine subtitle5Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "Call me Commander", LineTwo = "", SubtitleId = 4 };
            SubtitleLine subtitle5Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "You were only supposed to", LineTwo = "blow the bloody doors off!", SubtitleId = 4 };
            SubtitleLine subtitle5Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "Doctor...that's an order", LineTwo = "", SubtitleId = 4 };

            SubtitleLine subtitle6Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "good luck...", LineTwo = "", SubtitleId = 5 };
            SubtitleLine subtitle6Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "I'm a lead farmer,", LineTwo = " motherfucka!!!", SubtitleId = 5 };
            SubtitleLine subtitle6Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "Say hellooooooo to my ", LineTwo = " little friend!!", SubtitleId = 5 };

            SubtitleLine subtitle7Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "His name is Jason...and it's", LineTwo = "his birthday today.", SubtitleId = 6 };
            SubtitleLine subtitle7Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "People perceive you as somewhat...", LineTwo = "", SubtitleId = 6 };
            SubtitleLine subtitle7Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "Tempestuous?", LineTwo = "", SubtitleId = 6 };

            SubtitleLine subtitle8Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "Are you guys even real cops?", LineTwo = "You look like the kids on Halloween.", SubtitleId = 7 };
            SubtitleLine subtitle8Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "If them boys is cops, I'm DEA.", LineTwo = "[Schmidt does a fake laugh]", SubtitleId = 7 };
            SubtitleLine subtitle8Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "I know! Right? I know! It's hilarious.", LineTwo = "[Schmidt stops laughing]", SubtitleId = 7 };

            SubtitleLine subtitle9Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "Fuck you, pig!", LineTwo = "", SubtitleId = 8 };
            SubtitleLine subtitle9Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "(LILTING MELODY PLAYED ON ACOUSTIC GUITAR)", LineTwo = "", SubtitleId = 8 };
            SubtitleLine subtitle9Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "Hasta la vista, baby", LineTwo = "", SubtitleId = 8 };

            SubtitleLine subtitle10Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "(WATER SPLASHES)", LineTwo = "", SubtitleId = 9 };
            SubtitleLine subtitle10Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "(LILTING MELODY PLAYED ON ACOUSTIC GUITAR)", LineTwo = "", SubtitleId = 9 };
            SubtitleLine subtitle10Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "(VIOLINS JOIN IN)", LineTwo = "(FRENCH HORNS PLAYING)", SubtitleId = 9 };

            SubtitleLine subtitle11Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "Here's my motherfucking", LineTwo = "farm!!!", SubtitleId = 10 };
            SubtitleLine subtitle11Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "You mean, the little dimples", LineTwo = "around the tits?", SubtitleId = 10 };
            SubtitleLine subtitle11Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "I am your father", LineTwo = "", SubtitleId = 10 };

            SubtitleLine subtitle12Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "Do you guys have drugs?", LineTwo = "", SubtitleId = 11 };
            SubtitleLine subtitle12Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "Does Lipitor count?", LineTwo = "", SubtitleId = 11 };
            SubtitleLine subtitle12Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "How many times do I have to kill", LineTwo = "the same stinking panda?!", SubtitleId = 11 };

            SubtitleLine subtitle13Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "Dude, I think it's best to", LineTwo = "just tell 'em.", SubtitleId = 12 };
            SubtitleLine subtitle13Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "I'm Pregnant.", LineTwo = "", SubtitleId = 12 };
            SubtitleLine subtitle13Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "Oh, God.", LineTwo = "", SubtitleId = 12 };

            SubtitleLine subtitle14Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "Well I am who I am!", LineTwo = "", SubtitleId = 13 };
            SubtitleLine subtitle14Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "Well maybe you were, five", LineTwo = "procedures ago.", SubtitleId = 13 };
            SubtitleLine subtitle14Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "Are you going bald?", LineTwo = "", SubtitleId = 13 };

            SubtitleLine subtitle15Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "Motherfucker Jones.", LineTwo = "", SubtitleId = 14 };
            SubtitleLine subtitle15Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "Your first name is", LineTwo = "Motherfucker?!", SubtitleId = 14 };
            SubtitleLine subtitle15Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "Last name Jones. You got", LineTwo = "a problem with that?", SubtitleId = 14 };

            SubtitleLine subtitle16Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "My real name is Dean.", LineTwo = "", SubtitleId = 15 };
            SubtitleLine subtitle16Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = " I know who he is, bitch! ", LineTwo = "", SubtitleId = 15 };
            SubtitleLine subtitle16Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "Sorry!", LineTwo = "", SubtitleId = 15 };

            SubtitleLine subtitle17Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:11,019 --> 00:00:12,719", LineOne = "I got a job today.", LineTwo = "", SubtitleId = 16 };
            SubtitleLine subtitle17Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:12,720 --> 00:00:015,322", LineOne = "Where?", LineTwo = "", SubtitleId = 16 };
            SubtitleLine subtitle17Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:15,323 --> 00:00:17,324", LineOne = "Writin' for the Jackson Journal.", LineTwo = "", SubtitleId = 16 };

            SubtitleLine subtitle18Line1 = new SubtitleLine { LineNumber = 1, Time = "00:00:05,019 --> 00:00:06,719", LineOne = "You, me? Fat chance!", LineTwo = "", SubtitleId = 17 };
            SubtitleLine subtitle18Line2 = new SubtitleLine { LineNumber = 2, Time = "00:00:06,720 --> 00:00:09,322", LineOne = "I have a chance!", LineTwo = "And it's fat!", SubtitleId = 17 };
            SubtitleLine subtitle18Line3 = new SubtitleLine { LineNumber = 3, Time = "00:00:09,323 --> 00:00:11,324", LineOne = "This is so illegal.", LineTwo = "", SubtitleId = 17 };

            var subtitleLiness = new List<SubtitleLine>() { subtitle1Line1, subtitle1Line2, subtitle1Line3, subtitle2Line1, subtitle2Line2, subtitle2Line3, subtitle3Line1, subtitle3Line2, subtitle3Line3, 
                                                            subtitle4Line1, subtitle4Line2, subtitle4Line3, subtitle5Line1, subtitle5Line2, subtitle5Line3, subtitle6Line1, subtitle6Line2, subtitle6Line3,
                                                            subtitle7Line1, subtitle7Line2, subtitle7Line3, subtitle8Line1, subtitle8Line2, subtitle8Line3, subtitle9Line1, subtitle9Line2, subtitle9Line3,
                                                            subtitle10Line1, subtitle10Line2, subtitle10Line3, subtitle11Line1, subtitle11Line2, subtitle11Line3, subtitle12Line1, subtitle12Line2, subtitle12Line3,
                                                            subtitle13Line1, subtitle13Line2, subtitle13Line3, subtitle14Line1, subtitle14Line2, subtitle14Line3, subtitle15Line1, subtitle15Line2, subtitle15Line3,
                                                            subtitle16Line1, subtitle16Line2, subtitle16Line3, subtitle17Line1, subtitle17Line2, subtitle17Line3, subtitle18Line1, subtitle18Line2, subtitle18Line3 };
            subtitleLiness.ForEach(s => context.SubtitleLines.Add(s));
            context.SaveChanges();

            SubtitleRating subtitleRating1 = new SubtitleRating { Count = 2, SubtitleId = 1, Users = new List<ApplicationUser> { userManager.FindByName("user2"), userManager.FindByName("user3") } };
            SubtitleRating subtitleRating2 = new SubtitleRating { Count = 1, SubtitleId = 2, Users = new List<ApplicationUser> { userManager.FindByName("user3") } };
            SubtitleRating subtitleRating3 = new SubtitleRating { Count = 2, SubtitleId = 3, Users = new List<ApplicationUser> { userManager.FindByName("user1"), userManager.FindByName("user2"), userManager.FindByName("user3") } };
            var subtitleRatings = new List<SubtitleRating>() { subtitleRating1, subtitleRating2, subtitleRating3 };
            subtitleRatings.ForEach(u => context.SubtitleRatings.Add(u));
            context.SaveChanges();
        }
    }
}
