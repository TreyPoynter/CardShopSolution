using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CardShop.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Qualities",
                columns: table => new
                {
                    QualityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualities", x => x.QualityId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DatePurchased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsForSale = table.Column<bool>(type: "bit", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    QualityId = table.Column<int>(type: "int", nullable: false),
                    ManufactuererId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Manufacturers_ManufactuererId",
                        column: x => x.ManufactuererId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Qualities_QualityId",
                        column: x => x.QualityId,
                        principalTable: "Qualities",
                        principalColumn: "QualityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPurchases",
                columns: table => new
                {
                    CardPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradingCardId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPurchases", x => x.CardPurchaseId);
                    table.ForeignKey(
                        name: "FK_CardPurchases_Cards_TradingCardId",
                        column: x => x.TradingCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardPurchases_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfCards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfCards", x => new { x.CardId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_TypesOfCards_CardTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CardTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypesOfCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CardTypes",
                columns: new[] { "TypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Base" },
                    { 2, "Rookie" },
                    { 3, "Insert" },
                    { 4, "Autographed" },
                    { 5, "Relic" },
                    { 6, "Parallel" },
                    { 7, "Memorabillia" },
                    { 8, "Promotional" },
                    { 9, "Chase" },
                    { 10, "Box Topper" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 1, "Topps" },
                    { 2, "Panini" },
                    { 3, "Upper Deck" },
                    { 4, "Bowman" },
                    { 5, "Leaf Trading Cards" },
                    { 6, "Donruss" },
                    { 7, "Score" },
                    { 8, "Fleer" },
                    { 9, "Pro Set" },
                    { 10, "Tristar" }
                });

            migrationBuilder.InsertData(
                table: "Qualities",
                columns: new[] { "QualityId", "Type" },
                values: new object[,]
                {
                    { 1, "Mint" },
                    { 2, "Near Mint" },
                    { 3, "Excellent" },
                    { 4, "Very Good" },
                    { 5, "Good" },
                    { 6, "Fair" },
                    { 7, "Poor" },
                    { 8, "Damaged" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { 1, "Baseball" },
                    { 2, "Football" },
                    { 3, "Hockey" },
                    { 4, "Golf" },
                    { 5, "Wrestling" },
                    { 6, "Racing" },
                    { 7, "Boxing" },
                    { 8, "MMA" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Name" },
                values: new object[,]
                {
                    { 11, "Atlanta Braves" },
                    { 12, "Atlanta Falcons" },
                    { 13, "Atlanta Hawks" },
                    { 14, "Atlanta United" },
                    { 15, "Austin FC" },
                    { 16, "Baltimore Orioles" },
                    { 17, "Baltimore Ravens" },
                    { 18, "Boston Red Sox" },
                    { 19, "New England Patriots" },
                    { 20, "Boston Celtics" },
                    { 21, "Boston Bruins" },
                    { 22, "New England Revolution" },
                    { 23, "Buffalo Bills" },
                    { 24, "Buffalo Sabres" },
                    { 25, "Calgary Flames" },
                    { 26, "Carolina Panthers" },
                    { 27, "Charlotte Hornets" },
                    { 28, "Charlotte FC" },
                    { 29, "Chicago Cubs" },
                    { 30, "Chicago White Sox" },
                    { 31, "Chicago Bears" },
                    { 32, "Chicago Bulls" },
                    { 33, "Chicago Blackhawks" },
                    { 34, "Chicago Fire" },
                    { 35, "Cincinnati Reds" },
                    { 36, "Cincinnati Bengals" },
                    { 37, "FC Cincinnati" },
                    { 38, "Cleveland Guardians" },
                    { 39, "Cleveland Browns" },
                    { 40, "Cleveland Cavaliers" },
                    { 41, "Columbus Blue Jackets" },
                    { 42, "Columbus Crew" },
                    { 43, "Texas Rangers" },
                    { 44, "Dallas Cowboys" },
                    { 45, "Dallas Mavericks" },
                    { 46, "Dallas Stars" },
                    { 47, "FC Dallas" },
                    { 48, "Colorado Rockies" },
                    { 49, "Denver Broncos" },
                    { 50, "Denver Nuggets" },
                    { 51, "Colorado Avalanche" },
                    { 52, "Colorado Rapids" },
                    { 53, "Detroit Tigers" },
                    { 54, "Detroit Lions" },
                    { 55, "Detroit Pistons" },
                    { 56, "Detroit Red Wings" },
                    { 57, "Edmonton Oilers" },
                    { 58, "Green Bay Packers" },
                    { 59, "Houston Astros" },
                    { 60, "Houston Texans" },
                    { 61, "Houston Rockets" },
                    { 62, "Houston Dynamo" },
                    { 63, "Indianapolis Colts" },
                    { 64, "Indiana Pacers" },
                    { 65, "Jacksonville Jaguars" },
                    { 66, "Kansas City Royals" },
                    { 67, "Kansas City Chiefs" },
                    { 68, "Sporting Kansas City" },
                    { 69, "Las Vegas Raiders" },
                    { 70, "Vegas Golden Knights" },
                    { 71, "Los Angeles Dodgers" },
                    { 72, "Los Angeles Angels" },
                    { 73, "Los Angeles Rams" },
                    { 74, "Los Angeles Chargers" },
                    { 75, "Los Angeles Lakers" },
                    { 76, "Los Angeles Clippers" },
                    { 77, "LA Kings" },
                    { 78, "Anaheim Ducks" },
                    { 79, "LA Galaxy" },
                    { 80, "LA FC" },
                    { 81, "Memphis Grizzlies" },
                    { 82, "Miami Marlins" },
                    { 83, "Miami Dolphins" },
                    { 84, "Miami Heat" },
                    { 85, "Florida Panthers" },
                    { 86, "Inter Miami" },
                    { 87, "Minnesota Twins" },
                    { 88, "Minnesota Vikings" },
                    { 89, "Minnesota Timberwolves" },
                    { 90, "Minnesota Wild" },
                    { 91, "Minnesota United" },
                    { 92, "Milwaukee Brewers" },
                    { 93, "Milwaukee Bucks" },
                    { 94, "Montreal Canadiens" },
                    { 95, "Montreal Impact" },
                    { 96, "Tennessee Titans" },
                    { 97, "Nashville Predators" },
                    { 98, "Nashville SC" },
                    { 99, "New Orleans Saints" },
                    { 100, "New Orleans Pelicans" },
                    { 101, "New York Yankees" },
                    { 102, "New York Mets" },
                    { 103, "New York Giants" },
                    { 104, "New York Jets" },
                    { 105, "New York Knicks" },
                    { 106, "Brooklyn Nets" },
                    { 107, "New York Rangers" },
                    { 108, "New York Islanders" },
                    { 109, "New Jersey Devils" },
                    { 110, "New York Red Bulls" },
                    { 111, "New York City FC" },
                    { 112, "Oakland A's" },
                    { 113, "Oklahoma City Thunder" },
                    { 114, "Ottawa Senators" },
                    { 115, "Orlando Magic" },
                    { 116, "Orlando City" },
                    { 117, "Philadelphia Phillies" },
                    { 118, "Philadelphia Eagles" },
                    { 119, "Philadelphia 76ers" },
                    { 120, "Philadelphia Flyers" },
                    { 121, "Philadelphia Union" },
                    { 122, "Arizona Diamondbacks" },
                    { 123, "Arizona Cardinals" },
                    { 124, "Phoenix Suns" },
                    { 125, "Pittsburgh Pirates" },
                    { 126, "Pittsburgh Steelers" },
                    { 127, "Pittsburgh Penguins" },
                    { 128, "Portland Trail Blazers" },
                    { 129, "Portland Timbers" },
                    { 130, "Carolina Hurricanes" },
                    { 131, "Sacramento Kings" },
                    { 132, "Utah Jazz" },
                    { 133, "Real Salt Lake" },
                    { 134, "San Antonio Spurs" },
                    { 135, "San Diego Padres" },
                    { 136, "San Francisco Giants" },
                    { 137, "San Francisco 49ers" },
                    { 138, "Golden State Warriors" },
                    { 139, "San Jose Sharks" },
                    { 140, "San Jose Earthquakes" },
                    { 141, "St. Louis Cardinals" },
                    { 142, "St. Louis Blues" },
                    { 143, "St. Louis City FC" },
                    { 144, "Seattle Mariners" },
                    { 145, "Seattle Seahawks" },
                    { 146, "Seattle Kraken" },
                    { 147, "Seattle Sounders" },
                    { 148, "Tampa Bay Rays" },
                    { 149, "Tampa Bay Buccaneers" },
                    { 150, "Tampa Bay Lightning" },
                    { 151, "Toronto Blue Jays" },
                    { 152, "Toronto Raptors" },
                    { 153, "Toronto Maple Leafs" },
                    { 154, "Toronto FC" },
                    { 155, "Vancouver Canucks" },
                    { 156, "Vancouver Whitecaps" },
                    { 157, "Washington Nationals" },
                    { 158, "Washington Commanders" },
                    { 159, "Washington Wizards" },
                    { 160, "Washington Capitals" },
                    { 161, "DC United" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CardPurchases_PurchaseId",
                table: "CardPurchases",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPurchases_TradingCardId",
                table: "CardPurchases",
                column: "TradingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ManufactuererId",
                table: "Cards",
                column: "ManufactuererId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_QualityId",
                table: "Cards",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SportId",
                table: "Cards",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TeamId",
                table: "Cards",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfCards_TypeId",
                table: "TypesOfCards",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardPurchases");

            migrationBuilder.DropTable(
                name: "TypesOfCards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Qualities");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
