using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_end.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Musics_MusicId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_MusicId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "MusicId",
                table: "Playlists");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistModelIdPlaylist",
                table: "Musics",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_PlaylistModelIdPlaylist",
                table: "Musics",
                column: "PlaylistModelIdPlaylist");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Playlists_PlaylistModelIdPlaylist",
                table: "Musics",
                column: "PlaylistModelIdPlaylist",
                principalTable: "Playlists",
                principalColumn: "IdPlaylist");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Playlists_PlaylistModelIdPlaylist",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_PlaylistModelIdPlaylist",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "PlaylistModelIdPlaylist",
                table: "Musics");

            migrationBuilder.AddColumn<int>(
                name: "MusicId",
                table: "Playlists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_MusicId",
                table: "Playlists",
                column: "MusicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Musics_MusicId",
                table: "Playlists",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
