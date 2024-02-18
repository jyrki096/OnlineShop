﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Db.Models.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.BasketItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Compare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Compares");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasPrecision(18, 5)
                        .HasColumnType("decimal(18,5)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasPrecision(18, 5)
                        .HasColumnType("decimal(18,5)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLinks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6974ea2e-0377-41e3-92cc-5860286e2953"),
                            Cost = 79990m,
                            Description = "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.",
                            ImageLink = "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg",
                            ImageLinks = "[\"https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg\"]",
                            Name = "Casio Privia PX-s1100",
                            Type = "Цифровое пианино"
                        },
                        new
                        {
                            Id = new Guid("e50bc048-e4e3-459e-8fa6-413b3891b9b9"),
                            Cost = 95990m,
                            Description = "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.",
                            ImageLink = "https://hitonline.ua/icache/bigproduct_23916.jpg",
                            ImageLinks = "[\"https://hitonline.ua/icache/bigproduct_23916.jpg\"]",
                            Name = "Kurzweil KA120",
                            Type = "Цифровое пианино"
                        },
                        new
                        {
                            Id = new Guid("5eee31e0-4d2c-4431-9274-17ee7c23cbbb"),
                            Cost = 84990m,
                            Description = "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.",
                            ImageLink = "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg",
                            ImageLinks = "[\"https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg\"]",
                            Name = "Roland FP-30x",
                            Type = "Цифровое пианино"
                        },
                        new
                        {
                            Id = new Guid("93737d83-9fbc-402f-8234-4ad97b08f0e6"),
                            Cost = 94990m,
                            Description = "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента.",
                            ImageLink = "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg",
                            ImageLinks = "[\"https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg\"]",
                            Name = "Yamaha-P125",
                            Type = "Цифровое пианино"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Сharacteristics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Polyphony")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Power")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Timbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Сharacteristics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6a4bb90-dd4e-421b-9c3b-37a7436d4af2"),
                            Color = "Красный",
                            Polyphony = "192",
                            Power = "16",
                            ProductId = new Guid("6974ea2e-0377-41e3-92cc-5860286e2953"),
                            Timbers = "18"
                        },
                        new
                        {
                            Id = new Guid("be9f4aa8-4c36-4147-a355-9fb02a115fd8"),
                            Color = "Чёрный",
                            Polyphony = "128",
                            Power = "14",
                            ProductId = new Guid("e50bc048-e4e3-459e-8fa6-413b3891b9b9"),
                            Timbers = "600"
                        },
                        new
                        {
                            Id = new Guid("da794bc0-6d43-4862-8498-da5e991a0888"),
                            Color = "Белый",
                            Polyphony = "256",
                            Power = "56",
                            ProductId = new Guid("5eee31e0-4d2c-4431-9274-17ee7c23cbbb"),
                            Timbers = "22"
                        },
                        new
                        {
                            Id = new Guid("22bd446b-0aae-494a-bc8d-5668e5e349c4"),
                            Color = "Чёрный",
                            Polyphony = "192",
                            Power = "14",
                            ProductId = new Guid("93737d83-9fbc-402f-8234-4ad97b08f0e6"),
                            Timbers = "24"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.BasketItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("BasketItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Compare", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favorite", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Сharacteristics", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithOne("Characteristics")
                        .HasForeignKey("OnlineShop.Db.Models.Сharacteristics", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Basket", b =>
                {
                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("BasketItems");

                    b.Navigation("Characteristics");
                });
#pragma warning restore 612, 618
        }
    }
}
