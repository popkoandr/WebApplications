﻿using System.Data.Entity;
using System.Web.Mvc;

namespace BookStore.Models
{
    public class BookDbInitializer: DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            context.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
            context.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
            context.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });
 
            base.Seed(context);
        }
    }
}