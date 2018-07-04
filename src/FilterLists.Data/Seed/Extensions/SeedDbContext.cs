using System;
using System.IO;
using FilterLists.Data.Entities;
using FilterLists.Data.Entities.Junctions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FilterLists.Data.Seed.Extensions
{
    public static class SeedDbContext
    {
        private const string SeedDataPath = "..\\..\\data\\";
        private const string SeedDataExtension = ".json";

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(GetSeedData<Language>());
            modelBuilder.Entity<License>().HasData(GetSeedData<License>());
            modelBuilder.Entity<Maintainer>().HasData(GetSeedData<Maintainer>());
            modelBuilder.Entity<Software>().HasData(GetSeedData<Software>());
            modelBuilder.Entity<Syntax>().HasData(GetSeedData<Syntax>());
            modelBuilder.Entity<FilterList>().HasData(GetSeedData<FilterList>());
            modelBuilder.Entity<FilterListLanguage>().HasData(GetSeedData<FilterListLanguage>());
            modelBuilder.Entity<FilterListMaintainer>().HasData(GetSeedData<FilterListMaintainer>());
            modelBuilder.Entity<Fork>().HasData(GetSeedData<Fork>());
            modelBuilder.Entity<Merge>().HasData(GetSeedData<Merge>());
            modelBuilder.Entity<SoftwareSyntax>().HasData(GetSeedData<SoftwareSyntax>());
        }

        private static TEntityType[] GetSeedData<TEntityType>()
        {
            try
            {
                var path = SeedDataPath + typeof(TEntityType).Name + SeedDataExtension;
                var jsonData = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<TEntityType[]>(jsonData);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return new TEntityType[0];
            }
        }
    }
}