using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class BasketRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("9aeb983d-6198-4349-bfc8-963288a26db2"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("d74a192e-a3e1-40ca-ad20-c42d99cf90f8"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("dbf0975c-4f5e-4369-9ff5-bf92eff7250d"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("eb445c55-9f23-451c-8d28-aaa88ae12048"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a281f34-a4de-46af-9bb6-bc71337ad890"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("720e32a1-e4cf-464c-994e-0e0160e77ae4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd1c1962-43cd-498c-8fd6-b24753cb5228"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa4d85fd-d4eb-4e73-92b8-4398b1a10f8a"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImageLink", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("03bc07bd-c8d6-4158-a8ce-42a37b1ca7e8"), 95990m, "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.", "https://hitonline.ua/icache/bigproduct_23916.jpg", "Kurzweil KA120", "Цифровое пианино" },
                    { new Guid("964378e2-69cc-4876-9ff7-831468f9aded"), 84990m, "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.", "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg", "Roland FP-30x", "Цифровое пианино" },
                    { new Guid("a7b80e5b-0be2-4162-9212-d713d3464396"), 94990m, "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента.", "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg", "Yamaha-P125", "Цифровое пианино" },
                    { new Guid("bcff0771-30cf-4d9d-9bca-8079be809a1a"), 79990m, "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.", "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg", "Casio Privia PX-s1100", "Цифровое пианино" }
                });

            migrationBuilder.InsertData(
                table: "Сharacteristics",
                columns: new[] { "Id", "Color", "Polyphony", "Power", "ProductId", "Timbers" },
                values: new object[,]
                {
                    { new Guid("344034de-d1dd-4874-81f0-ee9160fe0084"), "Белый", "256", "56", new Guid("964378e2-69cc-4876-9ff7-831468f9aded"), "22" },
                    { new Guid("5770d009-9b58-4a67-835a-54c3480ac85b"), "Красный", "192", "16", new Guid("bcff0771-30cf-4d9d-9bca-8079be809a1a"), "18" },
                    { new Guid("71439e2f-c1bf-4b97-8eb1-8ba07c8455a4"), "Чёрный", "128", "14", new Guid("03bc07bd-c8d6-4158-a8ce-42a37b1ca7e8"), "600" },
                    { new Guid("e0574e12-6d1c-44a7-83b0-16ac84fd126f"), "Чёрный", "192", "14", new Guid("a7b80e5b-0be2-4162-9212-d713d3464396"), "24" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("344034de-d1dd-4874-81f0-ee9160fe0084"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("5770d009-9b58-4a67-835a-54c3480ac85b"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("71439e2f-c1bf-4b97-8eb1-8ba07c8455a4"));

            migrationBuilder.DeleteData(
                table: "Сharacteristics",
                keyColumn: "Id",
                keyValue: new Guid("e0574e12-6d1c-44a7-83b0-16ac84fd126f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("03bc07bd-c8d6-4158-a8ce-42a37b1ca7e8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("964378e2-69cc-4876-9ff7-831468f9aded"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a7b80e5b-0be2-4162-9212-d713d3464396"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bcff0771-30cf-4d9d-9bca-8079be809a1a"));

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImageLink", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("3a281f34-a4de-46af-9bb6-bc71337ad890"), 94990m, "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента.", "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg", "Yamaha-P125", "Цифровое пианино" },
                    { new Guid("720e32a1-e4cf-464c-994e-0e0160e77ae4"), 79990m, "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.", "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg", "Casio Privia PX-s1100", "Цифровое пианино" },
                    { new Guid("dd1c1962-43cd-498c-8fd6-b24753cb5228"), 95990m, "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.", "https://hitonline.ua/icache/bigproduct_23916.jpg", "Kurzweil KA120", "Цифровое пианино" },
                    { new Guid("fa4d85fd-d4eb-4e73-92b8-4398b1a10f8a"), 84990m, "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.", "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg", "Roland FP-30x", "Цифровое пианино" }
                });

            migrationBuilder.InsertData(
                table: "Сharacteristics",
                columns: new[] { "Id", "Color", "Polyphony", "Power", "ProductId", "Timbers" },
                values: new object[,]
                {
                    { new Guid("9aeb983d-6198-4349-bfc8-963288a26db2"), "Чёрный", "192", "14", new Guid("3a281f34-a4de-46af-9bb6-bc71337ad890"), "24" },
                    { new Guid("d74a192e-a3e1-40ca-ad20-c42d99cf90f8"), "Белый", "256", "56", new Guid("fa4d85fd-d4eb-4e73-92b8-4398b1a10f8a"), "22" },
                    { new Guid("dbf0975c-4f5e-4369-9ff5-bf92eff7250d"), "Чёрный", "128", "14", new Guid("dd1c1962-43cd-498c-8fd6-b24753cb5228"), "600" },
                    { new Guid("eb445c55-9f23-451c-8d28-aaa88ae12048"), "Красный", "192", "16", new Guid("720e32a1-e4cf-464c-994e-0e0160e77ae4"), "18" }
                });
        }
    }
}
