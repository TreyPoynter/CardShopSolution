using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(c => c.TeamId);

            builder.HasData(
                // Atlanta
                new Team() { TeamId = 11, Name = "Atlanta Braves" },
                new Team() { TeamId = 12, Name = "Atlanta Falcons" },
                new Team() { TeamId = 13, Name = "Atlanta Hawks" },
                new Team() { TeamId = 14, Name = "Atlanta United" },
                // Austin
                new Team() { TeamId = 15, Name = "Austin FC" },
                // Baltimore
                new Team() { TeamId = 16, Name = "Baltimore Orioles" },
                new Team() { TeamId = 17, Name = "Baltimore Ravens" },
                // Boston
                new Team() { TeamId = 18, Name = "Boston Red Sox" },
                new Team() { TeamId = 19, Name = "New England Patriots" },
                new Team() { TeamId = 20, Name = "Boston Celtics" },
                new Team() { TeamId = 21, Name = "Boston Bruins" },
                new Team() { TeamId = 22, Name = "New England Revolution" },
                // Buffalo
                new Team() { TeamId = 23, Name = "Buffalo Bills" },
                new Team() { TeamId = 24, Name = "Buffalo Sabres" },
                // Calgary
                new Team() { TeamId = 25, Name = "Calgary Flames" },
                // Charlotte
                new Team() { TeamId = 26, Name = "Carolina Panthers" },
                new Team() { TeamId = 27, Name = "Charlotte Hornets" },
                new Team() { TeamId = 28, Name = "Charlotte FC" },
                // Chicago
                new Team() { TeamId = 29, Name = "Chicago Cubs" },
                new Team() { TeamId = 30, Name = "Chicago White Sox" },
                new Team() { TeamId = 31, Name = "Chicago Bears" },
                new Team() { TeamId = 32, Name = "Chicago Bulls" },
                new Team() { TeamId = 33, Name = "Chicago Blackhawks" },
                new Team() { TeamId = 34, Name = "Chicago Fire" },
                // Cincinnati
                new Team() { TeamId = 35, Name = "Cincinnati Reds" },
                new Team() { TeamId = 36, Name = "Cincinnati Bengals" },
                new Team() { TeamId = 37, Name = "FC Cincinnati" },
                // Cleveland
                new Team() { TeamId = 38, Name = "Cleveland Guardians" },
                new Team() { TeamId = 39, Name = "Cleveland Browns" },
                new Team() { TeamId = 40, Name = "Cleveland Cavaliers" },
                // Columbus
                new Team() { TeamId = 41, Name = "Columbus Blue Jackets" },
                new Team() { TeamId = 42, Name = "Columbus Crew" },
                // Dallas
                new Team() { TeamId = 43, Name = "Texas Rangers" },
                new Team() { TeamId = 44, Name = "Dallas Cowboys" },
                new Team() { TeamId = 45, Name = "Dallas Mavericks" },
                new Team() { TeamId = 46, Name = "Dallas Stars" },
                new Team() { TeamId = 47, Name = "FC Dallas" },
                // Denver
                new Team() { TeamId = 48, Name = "Colorado Rockies" },
                new Team() { TeamId = 49, Name = "Denver Broncos" },
                new Team() { TeamId = 50, Name = "Denver Nuggets" },
                new Team() { TeamId = 51, Name = "Colorado Avalanche" },
                new Team() { TeamId = 52, Name = "Colorado Rapids" },
                // Detroit
                new Team() { TeamId = 53, Name = "Detroit Tigers" },
                new Team() { TeamId = 54, Name = "Detroit Lions" },
                new Team() { TeamId = 55, Name = "Detroit Pistons" },
                new Team() { TeamId = 56, Name = "Detroit Red Wings" },
                // Edmonton
                new Team() { TeamId = 57, Name = "Edmonton Oilers" },
                // Green Bay
                new Team() { TeamId = 58, Name = "Green Bay Packers" },
                // Houston
                new Team() { TeamId = 59, Name = "Houston Astros" },
                new Team() { TeamId = 60, Name = "Houston Texans" },
                new Team() { TeamId = 61, Name = "Houston Rockets" },
                new Team() { TeamId = 62, Name = "Houston Dynamo" },
                // Indianapolis
                new Team() { TeamId = 63, Name = "Indianapolis Colts" },
                new Team() { TeamId = 64, Name = "Indiana Pacers" },
                // Jacksonville
                new Team() { TeamId = 65, Name = "Jacksonville Jaguars" },
                // Kansas City
                new Team() { TeamId = 66, Name = "Kansas City Royals" },
                new Team() { TeamId = 67, Name = "Kansas City Chiefs" },
                new Team() { TeamId = 68, Name = "Sporting Kansas City" },
                // Las Vegas
                new Team() { TeamId = 69, Name = "Las Vegas Raiders" },
                new Team() { TeamId = 70, Name = "Vegas Golden Knights" },
                // Los Angeles
                new Team() { TeamId = 71, Name = "Los Angeles Dodgers" },
                new Team() { TeamId = 72, Name = "Los Angeles Angels" },
                new Team() { TeamId = 73, Name = "Los Angeles Rams" },
                new Team() { TeamId = 74, Name = "Los Angeles Chargers" },
                new Team() { TeamId = 75, Name = "Los Angeles Lakers" },
                new Team() { TeamId = 76, Name = "Los Angeles Clippers" },
                new Team() { TeamId = 77, Name = "LA Kings" },
                new Team() { TeamId = 78, Name = "Anaheim Ducks" },
                new Team() { TeamId = 79, Name = "LA Galaxy" },
                new Team() { TeamId = 80, Name = "LA FC" },
                // Memphis
                new Team() { TeamId = 81, Name = "Memphis Grizzlies" },
                // Miami
                new Team() { TeamId = 82, Name = "Miami Marlins" },
                new Team() { TeamId = 83, Name = "Miami Dolphins" },
                new Team() { TeamId = 84, Name = "Miami Heat" },
                new Team() { TeamId = 85, Name = "Florida Panthers" },
                new Team() { TeamId = 86, Name = "Inter Miami" },
                // Minneapolis
                new Team() { TeamId = 87, Name = "Minnesota Twins" },
                new Team() { TeamId = 88, Name = "Minnesota Vikings" },
                new Team() { TeamId = 89, Name = "Minnesota Timberwolves" },
                new Team() { TeamId = 90, Name = "Minnesota Wild" },
                new Team() { TeamId = 91, Name = "Minnesota United" },
                // Milwaukee
                new Team() { TeamId = 92, Name = "Milwaukee Brewers" },
                new Team() { TeamId = 93, Name = "Milwaukee Bucks" },
                // Montreal
                new Team() { TeamId = 94, Name = "Montreal Canadiens" },
                new Team() { TeamId = 95, Name = "Montreal Impact" },
                // Nashville
                new Team() { TeamId = 96, Name = "Tennessee Titans" },
                new Team() { TeamId = 97, Name = "Nashville Predators" },
                new Team() { TeamId = 98, Name = "Nashville SC" },
                // New Orleans
                new Team() { TeamId = 99, Name = "New Orleans Saints" },
                new Team() { TeamId = 100, Name = "New Orleans Pelicans" },
                // New York
                new Team() { TeamId = 101, Name = "New York Yankees" },
                new Team() { TeamId = 102, Name = "New York Mets" },
                new Team() { TeamId = 103, Name = "New York Giants" },
                new Team() { TeamId = 104, Name = "New York Jets" },
                new Team() { TeamId = 105, Name = "New York Knicks" },
                new Team() { TeamId = 106, Name = "Brooklyn Nets" },
                new Team() { TeamId = 107, Name = "New York Rangers" },
                new Team() { TeamId = 108, Name = "New York Islanders" },
                new Team() { TeamId = 109, Name = "New Jersey Devils" },
                new Team() { TeamId = 110, Name = "New York Red Bulls" },
                new Team() { TeamId = 111, Name = "New York City FC" },
                // Oakland
                new Team() { TeamId = 112, Name = "Oakland A's" },
                // Oklahoma City
                new Team() { TeamId = 113, Name = "Oklahoma City Thunder" },
                // Ottawa
                new Team() { TeamId = 114, Name = "Ottawa Senators" },
                // Orlando
                new Team() { TeamId = 115, Name = "Orlando Magic" },
                new Team() { TeamId = 116, Name = "Orlando City" },
                // Philadelphia
                new Team() { TeamId = 117, Name = "Philadelphia Phillies" },
                new Team() { TeamId = 118, Name = "Philadelphia Eagles" },
                new Team() { TeamId = 119, Name = "Philadelphia 76ers" },
                new Team() { TeamId = 120, Name = "Philadelphia Flyers" },
                new Team() { TeamId = 121, Name = "Philadelphia Union" },
                // Phoenix
                new Team() { TeamId = 122, Name = "Arizona Diamondbacks" },
                new Team() { TeamId = 123, Name = "Arizona Cardinals" },
                new Team() { TeamId = 124, Name = "Phoenix Suns" },
                // Pittsburgh
                new Team() { TeamId = 125, Name = "Pittsburgh Pirates" },
                new Team() { TeamId = 126, Name = "Pittsburgh Steelers" },
                new Team() { TeamId = 127, Name = "Pittsburgh Penguins" },
                // Portland
                new Team() { TeamId = 128, Name = "Portland Trail Blazers" },
                new Team() { TeamId = 129, Name = "Portland Timbers" },
                // Raleigh
                new Team() { TeamId = 130, Name = "Carolina Hurricanes" },
                // Sacramento
                new Team() { TeamId = 131, Name = "Sacramento Kings" },
                // Salt Lake
                new Team() { TeamId = 132, Name = "Utah Jazz" },
                new Team() { TeamId = 133, Name = "Real Salt Lake" },
                // San Antonio
                new Team() { TeamId = 134, Name = "San Antonio Spurs" },
                // San Diego
                new Team() { TeamId = 135, Name = "San Diego Padres" },
                // San Francisco
                new Team() { TeamId = 136, Name = "San Francisco Giants" },
                new Team() { TeamId = 137, Name = "San Francisco 49ers" },
                new Team() { TeamId = 138, Name = "Golden State Warriors" },
                // San Jose
                new Team() { TeamId = 139, Name = "San Jose Sharks" },
                new Team() { TeamId = 140, Name = "San Jose Earthquakes" },
                // St. Louis
                new Team() { TeamId = 141, Name = "St. Louis Cardinals" },
                new Team() { TeamId = 142, Name = "St. Louis Blues" },
                new Team() { TeamId = 143, Name = "St. Louis City FC" },
                // Seattle
                new Team() { TeamId = 144, Name = "Seattle Mariners" },
                new Team() { TeamId = 145, Name = "Seattle Seahawks" },
                new Team() { TeamId = 146, Name = "Seattle Kraken" },
                new Team() { TeamId = 147, Name = "Seattle Sounders" },
                // Tampa
                new Team() { TeamId = 148, Name = "Tampa Bay Rays" },
                new Team() { TeamId = 149, Name = "Tampa Bay Buccaneers" },
                new Team() { TeamId = 150, Name = "Tampa Bay Lightning" },
                // Toronto
                new Team() { TeamId = 151, Name = "Toronto Blue Jays" },
                new Team() { TeamId = 152, Name = "Toronto Raptors" },
                new Team() { TeamId = 153, Name = "Toronto Maple Leafs" },
                new Team() { TeamId = 154, Name = "Toronto FC" },
                // Vancouver
                new Team() { TeamId = 155, Name = "Vancouver Canucks" },
                new Team() { TeamId = 156, Name = "Vancouver Whitecaps" },
                // Washington
                new Team() { TeamId = 157, Name = "Washington Nationals" },
                new Team() { TeamId = 158, Name = "Washington Commanders" },
                new Team() { TeamId = 159, Name = "Washington Wizards" },
                new Team() { TeamId = 160, Name = "Washington Capitals" },
                new Team() { TeamId = 161, Name = "DC United" }
                );
        }
    }
}
