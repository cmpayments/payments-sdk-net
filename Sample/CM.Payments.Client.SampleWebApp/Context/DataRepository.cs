using System;
using System.Collections.Generic;
using System.Linq;
using CM.Payments.Client.SampleWebApp.Models;

namespace CM.Payments.Client.SampleWebApp.Context
{
    public sealed class DataRepository
    {
        private readonly SampleAppContext _context;

        public DataRepository(SampleAppContext context)
        {
            this._context = context;
        }

        public Account AddAccount()
        {
            var account =
                this._context.Accounts.Add(new Account {FirstName = "Jorick", LastName = "de Jong", Password = "qwerty", Username = "Jorick"});
            this._context.SaveChanges();

            return account;
        }

        public Order AddOrder()
        {
            var order = this._context.Orders.Add(new Order {Created = DateTime.Now, Status = Status.Open, AccountId = 1});
            this._context.SaveChanges();

            return order;
        }

        public OrderItem AddProductToOrder()
        {
            OrderItem item;
            if (this._context.OrderItems.Any())
            {
                item = this._context.OrderItems.First();
                item.Quantity++;
            }
            else
            {
                item = this._context.OrderItems.Add(new OrderItem {OrderId = 1, ProductId = 1, AddedOn = DateTime.Now, Quantity = 1});
            }
            this._context.SaveChanges();

            return item;
        }

        public List<OrderItem> GetAllItems()
        {
            return this._context.OrderItems.ToList();
        }
    }
}