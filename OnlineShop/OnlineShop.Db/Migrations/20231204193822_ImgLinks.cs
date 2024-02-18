using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ImgLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageLinks",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImageLink", "ImageLinks", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("1f4fcca5-1115-4d69-a437-dfa20887a6de"), 79990m, "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.", "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg", "", "Casio Privia PX-s1100", "Цифровое пианино" },
                    { new Guid("22b450e8-d39c-4593-b701-fa87467663d6"), 94990m, "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента.", "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg", "", "Yamaha-P125", "Цифровое пианино" },
                    { new Guid("289e53f5-d177-4f51-948f-b66869bf5f62"), 84990m, "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.", "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg", "", "Roland FP-30x", "Цифровое пианино" },
                    { new Guid("f1dd9bda-7cd8-42f8-a138-efa0757e4ffe"), 95990m, "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.", "https://hitonline.ua/icache/bigproduct_23916.jpg", "", "Kurzweil KA120", "Цифровое пианино" }
                });

            migrationBuilder.InsertData(
                table: "Сharacteristics",
                columns: new[] { "Id", "Color", "Polyphony", "Power", "ProductId", "Timbers" },
                values: new object[,]
                {
                    { new Guid("20fc8f8d-3070-4704-82b4-02a34d78c3ef"), "Чёрный", "192", "14", new Guid("22b450e8-d39c-4593-b701-fa87467663d6"), "24" },
                    { new Guid("dda640ea-b5e9-487c-98ce-fc86b2e7a5c9"), "Красный", "192", "16", new Guid("1f4fcca5-1115-4d69-a437-dfa20887a6de"), "18" },
                    { new Guid("dfd1377e-0784-430a-81a5-8b07058843a7"), "Чёрный", "128", "14", new Guid("f1dd9bda-7cd8-42f8-a138-efa0757e4ffe"), "600" },
                    { new Guid("f09607f2-a533-4fc1-a96f-331a3b980780"), "Белый", "256", "56", new Guid("289e53f5-d177-4f51-948f-b66869bf5f62"), "22" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("20fc8f8d-3070-4704-82b4-02a34d78c3ef"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("dda640ea-b5e9-487c-98ce-fc86b2e7a5c9"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("dfd1377e-0784-430a-81a5-8b07058843a7"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("f09607f2-a533-4fc1-a96f-331a3b980780"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1f4fcca5-1115-4d69-a437-dfa20887a6de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22b450e8-d39c-4593-b701-fa87467663d6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("289e53f5-d177-4f51-948f-b66869bf5f62"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1dd9bda-7cd8-42f8-a138-efa0757e4ffe"));

            migrationBuilder.DropColumn(
                name: "ImageLinks",
                table: "Products");

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
    }
}
