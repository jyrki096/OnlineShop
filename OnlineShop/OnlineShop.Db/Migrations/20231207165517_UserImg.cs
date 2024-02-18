using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class UserImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("0323be08-4919-4117-a482-9e43e10758ac"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("2514f4bf-2c3d-4daa-b651-76b47fd48a6d"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("739b820c-929f-4710-8faa-d496473ca5ca"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("7b6360eb-5b15-4400-a005-4267e523f50a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f6757af-5502-42da-a936-9bc015d38561"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2286daf3-a752-408b-bacc-e2ae923a8a85"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3dd7834e-6922-4b2f-8909-33baa3d463de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a3470f4-c5ce-46a1-bb42-7cb136052d60"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImageLink", "ImageLinks", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("5eee31e0-4d2c-4431-9274-17ee7c23cbbb"), 84990m, "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.", "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg", "[\"https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg\"]", "Roland FP-30x", "Цифровое пианино" },
                    { new Guid("6974ea2e-0377-41e3-92cc-5860286e2953"), 79990m, "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.", "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg", "[\"https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg\"]", "Casio Privia PX-s1100", "Цифровое пианино" },
                    { new Guid("93737d83-9fbc-402f-8234-4ad97b08f0e6"), 94990m, "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента.", "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg", "[\"https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg\"]", "Yamaha-P125", "Цифровое пианино" },
                    { new Guid("e50bc048-e4e3-459e-8fa6-413b3891b9b9"), 95990m, "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.", "https://hitonline.ua/icache/bigproduct_23916.jpg", "[\"https://hitonline.ua/icache/bigproduct_23916.jpg\"]", "Kurzweil KA120", "Цифровое пианино" }
                });

            migrationBuilder.InsertData(
                table: "Сharacteristics",
                columns: new[] { "Id", "Color", "Polyphony", "Power", "ProductId", "Timbers" },
                values: new object[,]
                {
                    { new Guid("22bd446b-0aae-494a-bc8d-5668e5e349c4"), "Чёрный", "192", "14", new Guid("93737d83-9fbc-402f-8234-4ad97b08f0e6"), "24" },
                    { new Guid("a6a4bb90-dd4e-421b-9c3b-37a7436d4af2"), "Красный", "192", "16", new Guid("6974ea2e-0377-41e3-92cc-5860286e2953"), "18" },
                    { new Guid("be9f4aa8-4c36-4147-a355-9fb02a115fd8"), "Чёрный", "128", "14", new Guid("e50bc048-e4e3-459e-8fa6-413b3891b9b9"), "600" },
                    { new Guid("da794bc0-6d43-4862-8498-da5e991a0888"), "Белый", "256", "56", new Guid("5eee31e0-4d2c-4431-9274-17ee7c23cbbb"), "22" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("22bd446b-0aae-494a-bc8d-5668e5e349c4"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("a6a4bb90-dd4e-421b-9c3b-37a7436d4af2"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("be9f4aa8-4c36-4147-a355-9fb02a115fd8"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("da794bc0-6d43-4862-8498-da5e991a0888"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5eee31e0-4d2c-4431-9274-17ee7c23cbbb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6974ea2e-0377-41e3-92cc-5860286e2953"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93737d83-9fbc-402f-8234-4ad97b08f0e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e50bc048-e4e3-459e-8fa6-413b3891b9b9"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImageLink", "ImageLinks", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0f6757af-5502-42da-a936-9bc015d38561"), 94990m, "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента.", "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg", "[\"https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg\"]", "Yamaha-P125", "Цифровое пианино" },
                    { new Guid("2286daf3-a752-408b-bacc-e2ae923a8a85"), 95990m, "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.", "https://hitonline.ua/icache/bigproduct_23916.jpg", "[\"https://hitonline.ua/icache/bigproduct_23916.jpg\"]", "Kurzweil KA120", "Цифровое пианино" },
                    { new Guid("3dd7834e-6922-4b2f-8909-33baa3d463de"), 79990m, "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.", "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg", "[\"https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg\"]", "Casio Privia PX-s1100", "Цифровое пианино" },
                    { new Guid("5a3470f4-c5ce-46a1-bb42-7cb136052d60"), 84990m, "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.", "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg", "[\"https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg\"]", "Roland FP-30x", "Цифровое пианино" }
                });

            migrationBuilder.InsertData(
                table: "Сharacteristics",
                columns: new[] { "Id", "Color", "Polyphony", "Power", "ProductId", "Timbers" },
                values: new object[,]
                {
                    { new Guid("0323be08-4919-4117-a482-9e43e10758ac"), "Красный", "192", "16", new Guid("3dd7834e-6922-4b2f-8909-33baa3d463de"), "18" },
                    { new Guid("2514f4bf-2c3d-4daa-b651-76b47fd48a6d"), "Чёрный", "192", "14", new Guid("0f6757af-5502-42da-a936-9bc015d38561"), "24" },
                    { new Guid("739b820c-929f-4710-8faa-d496473ca5ca"), "Чёрный", "128", "14", new Guid("2286daf3-a752-408b-bacc-e2ae923a8a85"), "600" },
                    { new Guid("7b6360eb-5b15-4400-a005-4267e523f50a"), "Белый", "256", "56", new Guid("5a3470f4-c5ce-46a1-bb42-7cb136052d60"), "22" }
                });
        }
    }
}
