using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Сharacteristics> Сharacteristics { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(e => e.Characteristics)
        .WithOne(e => e.Product)
            .HasForeignKey<Сharacteristics>()
            .IsRequired();

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Casio Privia PX-s1100",
                Type = "Цифровое пианино",
                ImageLink = "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg",
                ImageLinks = new List<string>() { "https://cdn.long-mcquade.com/files/273956/md_7281b630a2baa8fb63fa2fa81dbbdc2f.jpg" },
                Cost = 79990,
                Description = "Ставшая настоящим дизайнерским открытием PX-S1000 несколько лет назад, новая модель Касио не произвела очередного откровения. Отметим, что в PX-S1100 установлена механика с трехсенсорной клавиатурой (более чувствительной по сравнению с двухсенсорной), а также двойная репетиция (особенность клавиатуры рояля). Для более естественного звучания в цифровом пианино реализованы демпферный и струнный резонансы, а также призвуки демпферов и работы клавиш. Дополнительные функции будут полезны в повседневной игре: метроном, запись звука, пошаговая система обучения, наложение тембров и различные варианты реверберации.",
            };

            modelBuilder.Entity<Product>().HasData(product);

            var characteristics = new Сharacteristics()
            {
                Id = Guid.NewGuid(),
                Color = "Красный",
                Polyphony = "192",
                Timbers = "18",
                Power = "16",
                ProductId = product.Id
            };
            modelBuilder.Entity<Сharacteristics>().HasData(characteristics);

            var product2 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Kurzweil KA120",
                Type = "Цифровое пианино",
                ImageLink = "https://hitonline.ua/icache/bigproduct_23916.jpg",
                ImageLinks = new List<string>() { "https://hitonline.ua/icache/bigproduct_23916.jpg" },
                Cost = 95990,
                Description = "Kurzweil KA120 – небольшое и компактное цифровое пианино от Kurzweil. Несмотря на свои размеры, оно имеет полноценную 88-клавишную молоточковую фортепианную механику с 4 уровнями чувствительности и сочетает в себе лучшие качества цифрового пианино и синтезатора. KA120 предлагает широкий функционал, включающий 600 тембров и 230 стилей автоаккомпанемента, что делает его идеальным для использования в студии или на сцене.",
            };

            modelBuilder.Entity<Product>().HasData(product2);

            var characteristics2 = new Сharacteristics()
            {
                Id = Guid.NewGuid(),
                Color = "Чёрный",
                Polyphony = "128",
                Timbers = "600",
                Power = "14",
                ProductId = product2.Id
            };

            modelBuilder.Entity<Сharacteristics>().HasData(characteristics2);

            var product3 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Roland FP-30x",
                Type = "Цифровое пианино",
                ImageLink = "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg",
                ImageLinks = new List<string>() { "https://ae04.alicdn.com/kf/U4d96094b8a9e453ea675f40106537dc9c.jpg" },
                Cost = 84990,
                Description = "Roland FP-30X - это компактное и портативное цифровое фортепиано, созданное для музыкантов, которые ищут высокое качество звучания и удобство использования. Этот инструмент сочетает в себе передовую цифровую технологию и эргономичный дизайн, делая его идеальным выбором для домашней игры, студийной работы или живых выступлений.",
            };

            modelBuilder.Entity<Product>().HasData(product3);

            var characteristics3 = new Сharacteristics()
            {
                Id = Guid.NewGuid(),
                Color = "Белый",
                Polyphony = "256",
                Timbers = "22",
                Power = "56",
                ProductId = product3.Id
            };

            modelBuilder.Entity<Сharacteristics>().HasData(characteristics3);

            var product4 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Yamaha-P125",
                Type = "Цифровое пианино",
                ImageLink = "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg",
                ImageLinks = new List<string>() { "https://foralltune.ru/upload/iblock/d7d/d7d3bb85e2437cedf4695a714df1f0a0.jpg" },
                Cost = 94990,
                Description = "Основой цифрового пианино Yamaha P-125 стала легендарная 115-я модель. Но Yamaha P-125 превзошла предшественника по ряду важных параметров. 192-нотная полифония и мощный звуковой процессор Pure-CF здесь дополнены 24 тембрами и 20 темпами, что улучшило звуковые характеристики пианино. Изменился облик модели, благодаря усовершенствованным педалям. Изготовленные по типу рояльной лиры, они выглядят более эстетично и дают дополнительные удобства при использовании инструмента."
            };

            modelBuilder.Entity<Product>().HasData(product4);

            var characteristics4 = new Сharacteristics()
            {
                Id = Guid.NewGuid(),
                Color = "Чёрный",
                Polyphony = "192",
                Timbers = "24",
                Power = "14",
                ProductId = product4.Id
            };

            modelBuilder.Entity<Сharacteristics>().HasData(characteristics4);
        }
    }
}
