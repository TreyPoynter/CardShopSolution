using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardShop.Migrations
{
    /// <inheritdoc />
    public partial class AddedCardPurchases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedCards");

            migrationBuilder.CreateTable(
                name: "CardPurchases",
                columns: table => new
                {
                    CardPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_CardPurchases_PurchaseId",
                table: "CardPurchases",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPurchases_TradingCardId",
                table: "CardPurchases",
                column: "TradingCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardPurchases");

            migrationBuilder.CreateTable(
                name: "PurchasedCards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedCards", x => new { x.CardId, x.PurchaseId });
                    table.ForeignKey(
                        name: "FK_PurchasedCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasedCards_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedCards_PurchaseId",
                table: "PurchasedCards",
                column: "PurchaseId");
        }
    }
}
