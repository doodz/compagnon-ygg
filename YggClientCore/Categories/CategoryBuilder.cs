using System;
using System.Collections.Generic;
using System.Linq;

namespace YggClientCore.Categories
{
    public class CategoryBuilder
    {
        public Category GetCategory(Categories categorie)
        {
            switch (categorie)
            {
                case Categories.Movies:
                    return MakeMoviesCaterogy();

                case Categories.Music:
                    return MakeMusicCaterogy();
                case Categories.Application:
                    return MakeApplicationCaterogy();
                case Categories.VideoGame:
                    return MakeVideoGameCaterogy();
                case Categories.eBook:
                    return MakeeBookCaterogy();
                case Categories.Emulation:
                    return MakeEmulationCaterogy();
                case Categories.Gps:
                    return MakeeGpsCaterogy();
                case Categories.XXX:
                    return MakeeXXXCaterogy();
                default:
                    return null;
            }

        }


        private Category MakeMoviesCaterogy()
        {
            var category = new Category(Categories.Movies);
            category.Url = CategoriesUrl.AllMoviesTorrents;
            category.Id = 2145;

            category.SubCategorieses = MakeSubCategory(Categories.Movies, CategoriesUrl.Animation,
                CategoriesUrl.Concert, CategoriesUrl.Documentaire, CategoriesUrl.TvProgramme, CategoriesUrl.Movies,
                CategoriesUrl.TvShow, CategoriesUrl.Show, CategoriesUrl.Sport, CategoriesUrl.Clips);

            return category;
        }


        private IEnumerable<SubCategory> MakeSubCategory(Categories cat, params string[] urls)
        {
            foreach (var url in urls)
            {
                var sub = new SubCategory(cat);
                sub.Url = url;

                var split = url.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var strCateg = split.Last();
                var idName = strCateg.Split('-');

                sub.Id = int.Parse(idName[0]);
                sub.Name = idName[1];
                yield return sub;
            }
        }


        private Category MakeMusicCaterogy()
        {
            var category = new Category(Categories.Music);
            category.Url = CategoriesUrl.AllMusicTorrents;
            category.Id = 2139;

            category.SubCategorieses = MakeSubCategory(Categories.Music, CategoriesUrl.Karaoke,
                CategoriesUrl.Music, CategoriesUrl.PodcastRadio, CategoriesUrl.Samples);

            return category;
        }

        private Category MakeApplicationCaterogy()
        {
            var category = new Category(Categories.Application);
            category.Url = CategoriesUrl.AllApplicationTorrents;
            category.Id = 2144;

            category.SubCategorieses = MakeSubCategory(Categories.Application, CategoriesUrl.OtherApplication,
                CategoriesUrl.TrainingApplication, CategoriesUrl.LinuxApplication, CategoriesUrl.MacOsApplication,
                CategoriesUrl.SmartphoneApplication, CategoriesUrl.TabletApplication, CategoriesUrl.WindowsApplication);

            return category;
        }

        private Category MakeVideoGameCaterogy()
        {
            var category = new Category(Categories.VideoGame);
            category.Url = CategoriesUrl.AllVideoGameTorrents;
            category.Id = 2142;

            category.SubCategorieses = MakeSubCategory(Categories.VideoGame, CategoriesUrl.OtherVideoGame,
                CategoriesUrl.LinuxVideoGame, CategoriesUrl.MacOsVideoGame, CategoriesUrl.MicrosoftVideoGame,
                CategoriesUrl.NintendoVideoGame, CategoriesUrl.SmartphoneVideoGame, CategoriesUrl.SonyVideoGame,
                CategoriesUrl.TabletVideoGame, CategoriesUrl.WindowsVideoGame);

            return category;
        }

        private Category MakeeBookCaterogy()
        {
            var category = new Category(Categories.eBook);
            category.Url = CategoriesUrl.AlleBook;
            category.Id = 2140;

            category.SubCategorieses = MakeSubCategory(Categories.eBook, CategoriesUrl.AudioeBook,
                CategoriesUrl.BdseBook, CategoriesUrl.ComicseBook, CategoriesUrl.BookseBook,
                CategoriesUrl.MangaseBook, CategoriesUrl.PresseeBook);

            return category;
        }

        private Category MakeEmulationCaterogy()
        {
            var category = new Category(Categories.Emulation);
            category.Url = CategoriesUrl.AllEmulation;
            category.Id = 2141;

            category.SubCategorieses = MakeSubCategory(Categories.Emulation, CategoriesUrl.Emulators,
                CategoriesUrl.Roms);

            return category;
        }

        private Category MakeeGpsCaterogy()
        {
            var category = new Category(Categories.Gps);
            category.Url = CategoriesUrl.AllGps;
            category.Id = 2143;

            category.SubCategorieses = MakeSubCategory(Categories.Gps, CategoriesUrl.ApplicationsGps,
                CategoriesUrl.MapsGps, CategoriesUrl.VariousGps);

            return category;
        }

        private Category MakeeXXXCaterogy()
        {
            var category = new Category(Categories.XXX);
            category.Url = CategoriesUrl.AllXXX;
            category.Id = 2188;

            category.SubCategorieses = MakeSubCategory(Categories.XXX, CategoriesUrl.MoviesXXX,
                CategoriesUrl.HentaiXXX, CategoriesUrl.PicturesXXX);

            return category;
        }
    }
}