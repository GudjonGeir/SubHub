namespace SubHub.Migrations
{
    using SubHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SubHub.DAL.SubHubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SubHub.DAL.SubHubContext context)
        {

            MediaType movies = new MediaType { Type = "Kvikmyndir" };
            MediaType tvShows = new MediaType { Type = "Þættir" };
            var mediaTypes = new List<MediaType>() { movies, tvShows };
            mediaTypes.ForEach(m => context.MediaTypes.Add(m));
            context.SaveChanges();

            SubtitleLanguage enska = new SubtitleLanguage { Language = "Enska" };
            SubtitleLanguage islenska = new SubtitleLanguage { Language = "Íslenska" };
            var mediaLanguages = new List<SubtitleLanguage>() { enska, islenska };
            mediaLanguages.ForEach(m => context.SubtitleLanguages.Add(m));
            context.SaveChanges();

            MediaGenre annad = new MediaGenre { Genre = "Annað" };              //1
            MediaGenre drama = new MediaGenre { Genre = "Drama" };              //2
            MediaGenre gaman = new MediaGenre { Genre = "Gaman" };              //3
            MediaGenre hrollvekja = new MediaGenre { Genre = "Hrollvekja" };    //4
            MediaGenre islenskt = new MediaGenre { Genre = "Íslenskt-efni" };   //5
            MediaGenre romantik = new MediaGenre { Genre = "Rómantík" };        //6
            MediaGenre scifi = new MediaGenre { Genre = "Sci-Fi" };             //7
            MediaGenre spenna = new MediaGenre { Genre = "Spennutryllir" };     //8
            MediaGenre songleikur = new MediaGenre { Genre = "Söngleikur" };    //9
            MediaGenre teiknimynd = new MediaGenre { Genre = "Teiknimynd" };    //10
            MediaGenre avintyri = new MediaGenre { Genre = "Ævintýri" };       //11
            MediaGenre avisaga = new MediaGenre { Genre = "Ævisaga" };          //12
            var genres = new List<MediaGenre>() { annad, drama, gaman, hrollvekja, islenskt, romantik, scifi, spenna, songleikur, teiknimynd, avintyri, avisaga };
            genres.ForEach(g => context.MediaGenres.Add(g));
            context.SaveChanges();



            Media media1 = new Media { Name = "Catch me if you can", DateAired = new DateTime(2002, 12, 25), ImdbUrl = "http://www.imdb.com/title/tt0264464/?ref_=fn_al_tt_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTY5MzYzNjc5NV5BMl5BanBnXkFtZTYwNTUyNTc2._V1_SX640_SY720_.jpg", GenreId = 2, DownloadCount = 100 };
            Media media2 = new Media { Name = "The Notebook", DateAired = new DateTime(2003, 06, 25), ImdbUrl = "http://www.imdb.com/title/tt0332280/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUwMDg3OTA2N15BMl5BanBnXkFtZTcwNzc5OTYwOQ@@._V1_SX640_SY720_.jpg", GenreId = 6, DownloadCount = 11 };
            Media media3 = new Media { Name = "The Matrix", DateAired = new DateTime(1999, 03, 21), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTkxNDYxOTA4M15BMl5BanBnXkFtZTgwNTk0NzQxMTE@._V1_SX640_SY720_.jpg", GenreId = 7, DownloadCount = 5 };
            Media media4 = new Media { Name = "The Godfather", DateAired = new DateTime(1972, 03, 24), ImdbUrl = "http://www.imdb.com/title/tt0068646/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjEyMjcyNDI4MF5BMl5BanBnXkFtZTcwMDA5Mzg3OA@@._V1__SX640_SY720_.jpg", GenreId = 2, DownloadCount = 30 };
            Media media5 = new Media { Name = "Gladiator", DateAired = new DateTime(2000, 05, 02), ImdbUrl = "http://www.imdb.com/title/tt0172495/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTgwMzQzNTQ1Ml5BMl5BanBnXkFtZTgwMDY2NTYxMTE@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 2, DownloadCount = 9 };
            Media media6 = new Media { Name = "The Lion King", DateAired = new DateTime(1994, 07, 24), ImdbUrl = "http://www.imdb.com/title/tt0110357/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjEyMzgwNTUzMl5BMl5BanBnXkFtZTcwNTMxMzM3Ng@@._V1_SY98_CR4,0,67,98_AL_.jpg", GenreId = 10, DownloadCount = 7 };
            Media media7 = new Media { Name = "WALL-E", DateAired = new DateTime(2008, 06, 24), ImdbUrl = "http://www.imdb.com/title/tt0910970/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTczOTA3MzY2N15BMl5BanBnXkFtZTcwOTYwNjE2MQ@@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 10, DownloadCount = 10 };
            Media media8 = new Media { Name = "The Wolf of Wall Street", DateAired = new DateTime(2013, 12, 25), ImdbUrl = "http://www.imdb.com/title/tt0993846/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 2, DownloadCount = 15 };
            Media media9 = new Media { Name = "Toy Story", DateAired = new DateTime(1995, 11, 22), ImdbUrl = "http://www.imdb.com/title/tt0114709/?ref_=nv_sr_2", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTgwMjI4MzU5N15BMl5BanBnXkFtZTcwMTMyNTk3OA@@._V1_SY98_CR3,0,67,98_AL_.jpg", GenreId = 10, DownloadCount = 5 };
            Media media10 = new Media { Name = "Die Hard", DateAired = new DateTime(1988, 07, 22), ImdbUrl = "http://www.imdb.com/title/tt0095016/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTY4ODM0OTc2M15BMl5BanBnXkFtZTcwNzE0MTk3OA@@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 8, DownloadCount = 10 };
            Media media11 = new Media { Name = "The Avengers", DateAired = new DateTime(2012, 05, 04), ImdbUrl = "http://www.imdb.com/title/tt0848228/?ref_=nv_sr_2", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTk2NTI1MTU4N15BMl5BanBnXkFtZTcwODg0OTY0Nw@@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 11, DownloadCount = 17 };
            Media media12 = new Media { Name = "Gravity", DateAired = new DateTime(2013, 10, 04), ImdbUrl = "http://www.imdb.com/title/tt1454468/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BNjE5MzYwMzYxMF5BMl5BanBnXkFtZTcwOTk4MTk0OQ@@._V1_SX67_CR0,0,67,98_AL_.jpg", GenreId = 8, DownloadCount = 16 };
            Media media13 = new Media { Name = "Sister Act", DateAired = new DateTime(1992, 05, 29), ImdbUrl = "http://www.imdb.com/title/tt0105417/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTc1NzkzODcwN15BMl5BanBnXkFtZTcwNjcxODcxMQ@@._V1_SX640_SY720_.jpg", GenreId = 3, DownloadCount = 25 };
            Media media14 = new Media { Name = "A.C.O.D", DateAired = new DateTime(2013, 01, 23), ImdbUrl = "http://www.imdb.com/title/tt1311060/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTQwNTc5MjkyNF5BMl5BanBnXkFtZTgwNzQ5NTYwMDE@._V1_SX640_SY720_.jpg", GenreId = 3, DownloadCount = 32 };
            Media media15 = new Media { Name = "Jackass Presents: Bad Grandpa", DateAired = new DateTime(2013, 10, 25), ImdbUrl = "http://www.imdb.com/title/tt3063516/?ref_=fn_al_tt_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTYyMzk0MjY5NV5BMl5BanBnXkFtZTgwODI1MzIxMDE@._V1__SX640_SY720_.jpg", GenreId = 3, DownloadCount = 15 };
            Media media16 = new Media { Name = "Godzilla", DateAired = new DateTime(1998, 05, 20), ImdbUrl = "http://www.imdb.com/title/tt0120685/?ref_=fn_al_tt_2", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTgyMjE1NDczN15BMl5BanBnXkFtZTYwNDIwNjg5._V1_SX640_SY720_.jpg", GenreId = 4, DownloadCount = 23 };
            Media media17 = new Media { Name = "Djúpið", DateAired = new DateTime(2012, 05, 21), ImdbUrl = "http://www.imdb.com/title/tt1764275/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BODc3MzQyMTU0OF5BMl5BanBnXkFtZTcwNjI0MzU0OQ@@._V1_SX640_SY720_.jpg", GenreId = 5, DownloadCount = 43 };
            Media media18 = new Media { Name = "Hross í Oss", DateAired = new DateTime(2013, 08, 28), ImdbUrl = "http://www.imdb.com/title/tt3074732/?ref_=fn_al_tt_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTc5MjgxMzg0M15BMl5BanBnXkFtZTgwMDExODc3MDE@._V1_SX640_SY720_.jpg", GenreId = 5, DownloadCount = 23 };
            Media media19 = new Media { Name = "Grease", DateAired = new DateTime(1978, 06, 16), ImdbUrl = "http://www.imdb.com/title/tt0077631/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTcyMTA5MTY3MF5BMl5BanBnXkFtZTgwMTMwNzAxMDE@._V1_SX640_SY720_.jpg", GenreId = 9, DownloadCount = 14 };
            Media media20 = new Media { Name = "Rent", DateAired = new DateTime(2005, 11, 23), ImdbUrl = "http://www.imdb.com/title/tt0294870/?ref_=nv_sr_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjA3NTEwMDkyNV5BMl5BanBnXkFtZTcwNDQ4OTYzMQ@@._V1_SX640_SY720_.jpg", GenreId = 9, DownloadCount = 34 };
            Media media21 = new Media { Name = "Nixon", DateAired = new DateTime(1996, 01, 05), ImdbUrl = "http://www.imdb.com/title/tt0113987/?ref_=nv_sr_3", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTQ4ODUxNTU2OV5BMl5BanBnXkFtZTcwOTIwODMyMQ@@._V1_SX640_SY720_.jpg", GenreId = 12, DownloadCount = 2 };
            Media media22 = new Media { Name = "Walk the Line", DateAired = new DateTime(2005, 11, 18), ImdbUrl = "http://www.imdb.com/title/tt0358273/?ref_=fn_al_tt_1", TypeId = 1, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjIyOTU3MjUxOF5BMl5BanBnXkFtZTcwMTQ0NjYzMw@@._V1_SX640_SY720_.jpg", GenreId = 12, DownloadCount = 24 };
            Media media23 = new Media { Name = "Game of Thrones: S03E01", DateAired = new DateTime(2013, 03, 31), ImdbUrl = "http://www.imdb.com/title/tt2178782/?ref_=tt_ep_ep1", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTk4NjcwMzAzN15BMl5BanBnXkFtZTcwNzgxNTcyOQ@@._V1_SY317_CR131,0,214,317_AL_.jpg", GenreId = 2, DownloadCount = 100 };
            Media media24 = new Media { Name = "Arrow: S02E01", DateAired = new DateTime(2013, 10, 09), ImdbUrl = "http://www.imdb.com/title/tt2702698/?ref_=tt_ep_ep2", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUxODEwMzU5Ml5BMl5BanBnXkFtZTgwODYwMTczMDE@._V1_SX640_SY720_.jpg", GenreId = 8, DownloadCount = 23 };
            Media media25 = new Media { Name = "Greys Anatomy: S06E03", DateAired = new DateTime(2009, 10, 01), ImdbUrl = "http://www.imdb.com/title/tt1497729/?ref_=tt_ep_ep3", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BNjQ0OTU5OTE0M15BMl5BanBnXkFtZTcwMzEzNTc4Mg@@._V1_SX640_SY720_.jpg", GenreId = 2, DownloadCount = 15 };
            Media media26 = new Media { Name = "The Blacklist: S01E04", DateAired = new DateTime(2013, 10, 14), ImdbUrl = "http://www.imdb.com/title/tt2741602/?ref_=nv_sr_1", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMjEwNjM3NTc5NV5BMl5BanBnXkFtZTgwOTU4MDczMDE@._V1_SX640_SY720_.jpg", GenreId = 2, DownloadCount = 24 };
            Media media27 = new Media { Name = "Friends: S09E04", DateAired = new DateTime(2002, 10, 17), ImdbUrl = "http://www.imdb.com/title/tt0583645/?ref_=tt_ep_ep4", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTczNzcxOTI5OV5BMl5BanBnXkFtZTcwOTk2NzcyMQ@@._V1_SX640_SY720_.jpg", GenreId = 3, DownloadCount = 25 };
            Media media28 = new Media { Name = "The Big Bang Theory: S07E02", DateAired = new DateTime(2013, 09, 26), ImdbUrl = "http://www.imdb.com/title/tt2933998/?ref_=tt_ep_ep2", TypeId = 2, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BODk0MjU1MDk3OV5BMl5BanBnXkFtZTgwMjYwNjIzMDE@._V1_SX640_SY720_.jpg", GenreId = 3, DownloadCount = 30 };
            var medias = new List<Media>() { media1, media2, media3, media4, media5, media6, media7, media8, media9, media10, media11, media12, media13, media14, media15, media16, media17, media18, media19, media20, media21, media22, media23, media24, media25, media26, media27, media28 };
            medias.ForEach(m => context.Medias.Add(m));
            context.SaveChanges();
        }
        
    }
}
