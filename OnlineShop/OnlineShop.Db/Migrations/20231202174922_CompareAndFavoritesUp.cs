using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class CompareAndFavoritesUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("1a9fcad7-6501-471e-a51a-db1fdba20950"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("538f2b8e-421b-444e-9487-eef8528997f2"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("625272b0-f36c-4ffb-a6dc-b885c04e4a96"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("6ff9b372-cf4e-469b-8ed7-7b394f6ec57d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0aa88d84-dd70-4957-be74-753939fc4ac4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a7fc68e-dfcc-4550-a2ed-7424c3dea12b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9e81e884-1c7f-40ff-921c-0b73172b8c54"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6195fa4-4998-4e17-a755-6283f4a1bfb8"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Compares");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Compares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImageLink", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("205db977-4475-4f29-8ad1-cdb02925d755"), 95990m, "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.", "https://hitonline.ua/icache/bigproduct_23916.jpg", "Kurzweil KA120", "Цифровое пианино" },
                    { new Guid("53713e75-ed51-4c0a-8fa4-1b7fc7a90c7f"), 84990m, "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.", "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg", "Roland FP-30x", "Цифровое пианино" },
                    { new Guid("aab6b6e7-a6ca-4863-8c17-31f115bd9407"), 79990m, "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.", "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg", "Casio Privia PX-s1100", "Цифровое пианино" },
                    { new Guid("f0cf9cc4-4fa4-4078-8349-92df11b577f8"), 94990m, "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента.", "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg", "Yamaha-P125", "Цифровое пианино" }
                });

            migrationBuilder.InsertData(
                table: "Сharacteristics",
                columns: new[] { "Id", "Color", "Polyphony", "Power", "ProductId", "Timbers" },
                values: new object[,]
                {
                    { new Guid("7ca43d39-7cc4-4a62-afac-3fcb574da79c"), "Чёрный", "192", "14", new Guid("f0cf9cc4-4fa4-4078-8349-92df11b577f8"), "24" },
                    { new Guid("b1091c03-2ac3-4f45-9b63-c78256225243"), "Красный", "192", "16", new Guid("aab6b6e7-a6ca-4863-8c17-31f115bd9407"), "18" },
                    { new Guid("b9a7def3-0cb6-4970-aec3-a81e8b36deda"), "Белый", "256", "56", new Guid("53713e75-ed51-4c0a-8fa4-1b7fc7a90c7f"), "22" },
                    { new Guid("fa08acca-387b-4bc9-aed2-e84d44b32099"), "Чёрный", "128", "14", new Guid("205db977-4475-4f29-8ad1-cdb02925d755"), "600" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("7ca43d39-7cc4-4a62-afac-3fcb574da79c"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("b1091c03-2ac3-4f45-9b63-c78256225243"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("b9a7def3-0cb6-4970-aec3-a81e8b36deda"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("fa08acca-387b-4bc9-aed2-e84d44b32099"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("205db977-4475-4f29-8ad1-cdb02925d755"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("53713e75-ed51-4c0a-8fa4-1b7fc7a90c7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aab6b6e7-a6ca-4863-8c17-31f115bd9407"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f0cf9cc4-4fa4-4078-8349-92df11b577f8"));

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Compares");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Compares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImageLink", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0aa88d84-dd70-4957-be74-753939fc4ac4"), 84990m, "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.", "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg", "Roland FP-30x", "Цифровое пианино" },
                    { new Guid("5a7fc68e-dfcc-4550-a2ed-7424c3dea12b"), 79990m, "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.", "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg", "Casio Privia PX-s1100", "Цифровое пианино" },
                    { new Guid("9e81e884-1c7f-40ff-921c-0b73172b8c54"), 95990m, "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.", "https://hitonline.ua/icache/bigproduct_23916.jpg", "Kurzweil KA120", "Цифровое пианино" },
                    { new Guid("d6195fa4-4998-4e17-a755-6283f4a1bfb8"), 94990m, "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента.", "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg", "Yamaha-P125", "Цифровое пианино" }
                });

            migrationBuilder.InsertData(
                table: "Сharacteristics",
                columns: new[] { "Id", "Color", "Polyphony", "Power", "ProductId", "Timbers" },
                values: new object[,]
                {
                    { new Guid("1a9fcad7-6501-471e-a51a-db1fdba20950"), "Белый", "256", "56", new Guid("0aa88d84-dd70-4957-be74-753939fc4ac4"), "22" },
                    { new Guid("538f2b8e-421b-444e-9487-eef8528997f2"), "Чёрный", "128", "14", new Guid("9e81e884-1c7f-40ff-921c-0b73172b8c54"), "600" },
                    { new Guid("625272b0-f36c-4ffb-a6dc-b885c04e4a96"), "Чёрный", "192", "14", new Guid("d6195fa4-4998-4e17-a755-6283f4a1bfb8"), "24" },
                    { new Guid("6ff9b372-cf4e-469b-8ed7-7b394f6ec57d"), "Красный", "192", "16", new Guid("5a7fc68e-dfcc-4550-a2ed-7424c3dea12b"), "18" }
                });
        }
    }
}
