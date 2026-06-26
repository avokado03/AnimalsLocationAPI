using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalsLocationAPI.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngestionStreams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StreamKey = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    CountryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TaxonName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TaxonSourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestionStreams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngestionRuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StreamId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RecordsFetched = table.Column<int>(type: "integer", nullable: false),
                    RecordsInserted = table.Column<int>(type: "integer", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    RetryCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestionRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngestionRuns_IngestionStreams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "IngestionStreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngestionWatermarks",
                columns: table => new
                {
                    StreamId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastObservedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastExternalId = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastRunId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestionWatermarks", x => x.StreamId);
                    table.ForeignKey(
                        name: "FK_IngestionWatermarks_IngestionRuns_LastRunId",
                        column: x => x.LastRunId,
                        principalTable: "IngestionRuns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngestionWatermarks_IngestionStreams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "IngestionStreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawObservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StreamId = table.Column<Guid>(type: "uuid", nullable: false),
                    RunId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalObservationId = table.Column<long>(type: "bigint", nullable: false),
                    RawJson = table.Column<string>(type: "jsonb", nullable: false),
                    IngestedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SourceName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawObservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawObservations_IngestionRuns_RunId",
                        column: x => x.RunId,
                        principalTable: "IngestionRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawObservations_IngestionStreams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "IngestionStreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IngestionStreams",
                columns: new[] { "Id", "CountryCode", "CountryName", "CreatedAt", "IsActive", "SourceName", "StreamKey", "TaxonName", "TaxonSourceId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("96b6f71d-f519-43c5-b540-f8ba5dbd32a5"), "uz", "Uzbekistan", new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc), true, "INaturalist", "uz|myriapoda", "Myriapoda", 144128L, new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc) },
                    { new Guid("a5b6f71d-f519-43c5-b540-f8ba5dbd32a4"), "uz", "Uzbekistan", new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc), true, "INaturalist", "uz|arachnida", "Arachnida", 47119L, new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc) },
                    { new Guid("b4b6f71d-f519-43c5-b540-f8ba5dbd32a3"), "kg", "Kyrgystan", new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc), true, "INaturalist", "kg|myriapoda", "Myriapoda", 144128L, new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc) },
                    { new Guid("c3b6f71d-f519-43c5-b540-f8ba5dbd32a2"), "kg", "Kyrgystan", new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc), true, "INaturalist", "kg|arachnida", "Arachnida", 47119L, new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc) },
                    { new Guid("d2b6f71d-f519-43c5-b540-f8ba5dbd32a1"), "kz", "Kazakhstan", new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc), true, "INaturalist", "kz|myriapoda", "Myriapoda", 144128L, new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc) },
                    { new Guid("fbc6f71d-f519-43c5-b540-f8ba5dbd32a0"), "kz", "Kazakhstan", new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc), true, "INaturalist", "kz|arachnida", "Arachnida", 47119L, new DateTime(2026, 6, 26, 20, 6, 7, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngestionRuns_StreamId",
                table: "IngestionRuns",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_IngestionStreams_StreamKey",
                table: "IngestionStreams",
                column: "StreamKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngestionWatermarks_LastRunId",
                table: "IngestionWatermarks",
                column: "LastRunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawObservations_RunId",
                table: "RawObservations",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_RawObservations_StreamId",
                table: "RawObservations",
                column: "StreamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngestionWatermarks");

            migrationBuilder.DropTable(
                name: "RawObservations");

            migrationBuilder.DropTable(
                name: "IngestionRuns");

            migrationBuilder.DropTable(
                name: "IngestionStreams");
        }
    }
}
