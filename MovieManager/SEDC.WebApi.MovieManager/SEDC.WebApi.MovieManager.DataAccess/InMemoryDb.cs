using SEDC.WebApi.MovieManager.DataModels.Enums;
using SEDC.WebApi.MovieManager.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DataAccess
{
    public static class InMemoryDb
    {
        public static List<Movie> Movies { get; set; } = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Top Gun",
                Description = "As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom.",
                Year = 1986,
                Genre = Genre.Action
            },
            new Movie
            {
                Id = 2,
                Title = "Predators",
                Description = "A group of elite warriors parachute into an unfamiliar jungle and are hunted by members of a merciless alien race.",
                Year = 2010,
                Genre = Genre.Action
            },
            new Movie
            {
                Id = 3,
                Title = "Snowpiercer",
                Description = "In a future where a failed climate change experiment has killed all life except for the survivors who boarded the Snowpiercer (a train that travels around the globe), a new class system emerges.",
                Year = 2013,
                Genre = Genre.Action
            },
            new Movie
            {
                Id = 4,
                Title = "Dumb and Dumber",
                Description = "After a woman leaves a briefcase at the airport terminal, a dumb limo driver and his dumber friend set out on a hilarious cross-country road trip to Aspen.",
                Year = 1994,
                Genre = Genre.Comedy
            },
            new Movie
            {
                Id = 5,
                Title = "Bridesmaids",
                Description = "Competition between the maid of honor and a bridesmaid, over who is the bride's best friend, threatens to upend the life of an out-of-work pastry chef.",
                Year = 2011,
                Genre = Genre.Comedy
            },
            new Movie
            {
                Id = 6,
                Title = "Gladiator",
                Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                Year = 2000,
                Genre = Genre.Drama
            },
            new Movie
            {
                Id = 7,
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Year = 1994,
                Genre = Genre.Drama
            },
            new Movie
            {
                Id = 8,
                Title = "The Conjuring",
                Description = "Paranormal investigators Ed and Lorraine Warren work to help a family terrorized by a dark presence in their farmhouse.",
                Year = 1994,
                Genre = Genre.Horror
            },
            new Movie
            {
                Id = 9,
                Title = "The Ring",
                Description = "A journalist must investigate a mysterious videotape which seems to cause the death of anyone one week to the day after they view it.",
                Year = 1994,
                Genre = Genre.Horror
            },
            new Movie
            {
                Id = 10,
                Title = "Interstellar",
                Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                Year = 2014,
                Genre = Genre.ScienceFiction
            },
            new Movie
            {
                Id = 11,
                Title = "Inception",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                Year = 2010,
                Genre = Genre.ScienceFiction
            },
            new Movie
            {
                Id = 12,
                Title = "Shutter Island",
                Description = "In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.",
                Year = 2010,
                Genre = Genre.Thriller
            },
            new Movie
            {
                Id = 13,
                Title = "Argo",
                Description = "Acting under the cover of a Hollywood producer scouting a location for a science fiction film, a CIA agent launches a dangerous operation to rescue six Americans in Tehran during the U.S. hostage crisis in Iran in 1979.",
                Year = 2012,
                Genre = Genre.Thriller
            },
            new Movie
            {
                Id = 14,
                Title = "Memento",
                Description = "A man with short-term memory loss attempts to track down his wife's murderer.",
                Year = 2000,
                Genre = Genre.Thriller
            },
            new Movie
            {
                Id = 15,
                Title = "Thor",
                Description = "The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders.",
                Year = 2011,
                Genre = Genre.Adventure
            },
            new Movie
            {
                Id = 16,
                Title = "Dune",
                Description = "A noble family becomes embroiled in a war for control over the galaxy's most valuable asset while its heir becomes troubled by visions of a dark future.",
                Year = 2021,
                Genre = Genre.Adventure
            },
            new Movie
            {
                Id = 16,
                Title = "Iron Man",
                Description = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",
                Year = 2008,
                Genre = Genre.Adventure
            },
        };
    }
}
