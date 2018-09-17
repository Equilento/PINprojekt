using WebApplication1.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;

namespace WebApplication1.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.ProductSorters.Any())
            {
                context.ProductSorters.AddRange(ProductSorters.Select(c => c.Value));
            }
            if (!context.UsersData.Any())
            {
                context.AddRange
                (
                    new User
                    {
                        FirstName = "Domagoj",
                        LastName = "Krajnovic",
                        Email = "dkrajnovic@vsite.hr",
                        Password = "test",
                        IsAdmin = true,
                        IsEmailVerified=true
                    },
                    new User
                    {
                        FirstName = "Pero",
                        LastName = "Djetlic",
                        Email = "pdjetlic@hotmail.com",
                        Password = "testPero",
                        IsAdmin = false,
                        IsEmailVerified = false
                    },
                    new User
                    {
                        FirstName = "Tartar",
                        LastName = "Majonezic",
                        Email = "tmajonezic@gmail.com",
                        Password = "testTartar",
                        IsAdmin = false,
                        IsEmailVerified = false
                    }
                );
            }

            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product
                    {
                        Name = "Paulaner",
                        Price = 18,
                        Description = "German beer, top kvaliteta",
                        ProductSorter = ProductSorters["Piva"],
                        ImageURL = "https://www.wishbeer.com/1023-large_default/paulaner-hefe-weissbier-naturtrub-500-ml-55.jpg",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Karlovacko",
                        Price = 12,
                        Description = "Hrvatsko pivo iz Karlovca",
                        ProductSorter = ProductSorters["Piva"],
                        ImageURL = "https://www.totalwine.com/media/sys_master/twmmedia/h6f/h7f/10675623002142.png",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Ozujsko",
                        Price = 11,
                        Description = "Hrvatsko pivo",
                        ProductSorter = ProductSorters["Piva"],
                        ImageURL = "http://res.cloudinary.com/ratebeer/image/upload/w_200,h_200,c_pad,d_beer_img_default.png,f_auto/beer_9374",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Vodka",
                        Price = 15,
                        Description = "Mother russia!",
                        ProductSorter = ProductSorters["Zestica"],
                        ImageURL = "https://img.thewhiskyexchange.com/540/vodka_bel12.jpg",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Rakija",
                        Price = 15,
                        Description = "Dobra rakija prolaza vrjedi!",
                        ProductSorter = ProductSorters["Zestica"],
                        ImageURL = "http://bulgarianfoodforyou.com/wp-content/uploads/2015/03/Rakia-Rubaiyat.jpg",
                        InStock = true,
                        IsMostLiked = true
                    },
                    new Product
                    {
                        Name = "Whiskey",
                        Price = 9,
                        Description = "Dobar viski protiv losih misli!",
                        ProductSorter = ProductSorters["Zestica"],
                        ImageURL = "https://prods3.imgix.net/images/articles/2016_11/Non-Feature-Difference-Between-Whiskey-Whisky.jpg?auto=format%2Ccompress&ixjsv=2.2.3&w=670",
                        InStock = true,
                        IsMostLiked = true
                    },
                    new Product
                    {
                        Name = "Coca-Cola",
                        Price = 10,
                        Description = "Svi znamo za coca-colu!",
                        ProductSorter = ProductSorters["Sok"],
                        ImageURL = "https://target.scene7.com/is/image/Target/12953529?wid=488&hei=488&fmt=pjpeg",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Fanta",
                        Price = 8,
                        Description = "Svi znamo za fantu",
                        ProductSorter = ProductSorters["Sok"],
                        ImageURL = "https://www.britishcornershop.co.uk/img/large/SGN0316.jpg",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Juice",
                        Price = 6,
                        Description = "Vocni sokovi s velikim udjelom voca",
                        ProductSorter = ProductSorters["Sok"],
                        ImageURL = "http://cdn3.foodviva.com/static-content/food-images/juice-recipes/orange-pineapple-juice-recipe/orange-pineapple-juice-recipe.jpg",
                        InStock = true,
                        IsMostLiked = true
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, ProductSorter> productSorters;
        public static Dictionary<string, ProductSorter> ProductSorters
        {
            get
            {
                if (productSorters == null)
                {
                    var productSortersList = new ProductSorter[]
                    {
                        new ProductSorter { Name = "Zestica", Description="Vise od 40% alkohola" },
                        new ProductSorter { Name = "Sok", Description="Bezalkoholno pice" },
                        new ProductSorter { Name = "Piva", Description="OD 4-12% alkohola" }

                    };

                    productSorters = new Dictionary<string, ProductSorter>();

                    foreach (ProductSorter sorter in productSortersList)
                    {
                        productSorters.Add(sorter.Name, sorter);
                    }
                }

                return productSorters;
            }
        }
    }
}

