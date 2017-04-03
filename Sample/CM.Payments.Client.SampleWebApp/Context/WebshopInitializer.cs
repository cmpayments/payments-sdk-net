using System.Collections.Generic;
using System.Data.Entity;
using CM.Payments.Client.SampleWebApp.Models;

namespace CM.Payments.Client.SampleWebApp.Context
{
    public sealed class WebshopInitializer : DropCreateDatabaseIfModelChanges<SampleAppContext>
    {
        protected override void Seed(SampleAppContext context)
        {
            var accounts = new List<Account> {new Account {FirstName = "Demo", LastName = "User", Username = "Demo", Password = "demo"}};
            accounts.ForEach(s => context.Accounts.Add(s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product
                {
                    Title = "CM boekje",
                    Price = 1.50,
                    Image = "boekje.png",
                    Thumbnail = "boekje.png",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras fermentum efficitur tincidunt. Proin fringilla vitae erat a tincidunt."
                },
                new Product
                {
                    Title = "CM pen",
                    Price = 0.50,
                    Image = "pen.png",
                    Thumbnail = "pen.png",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras fermentum efficitur tincidunt. Proin fringilla vitae erat a tincidunt."
                },
                new Product
                {
                    Title = "CM keycord",
                    Price = 0.75,
                    Image = "keycord.png",
                    Thumbnail = "keycord.png",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras fermentum efficitur tincidunt. Proin fringilla vitae erat a tincidunt."
                }
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    }
}