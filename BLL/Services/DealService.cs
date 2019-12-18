using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DealService 
    {
        DBDataOperation db;

        public DealService(DBDataOperation db)
        {
            this.db = db;
        }

        //public bool MakePokypka(Pokypka pokypka)
        //{
        //    List<PokProd> pokypkiproduktov = new List<PokProd>();
        //    int Buying = pokprodDto.Id;
        //    decimal sum = 0;
        //    foreach (var pId in pokprodDto.SpisokProduktov)
        //    {
        //        Produkt phone = db.Produkt.GetItem(pId);
        //        // валидация
        //        if (phone == null)
        //            throw new Exception(" Продукт не найден");
        //        sum += phone.Cost;
        //        pokypkiproduktov.Add(new PokProd() { ProduktId = pId, PokypkaId = pokprodDto.Id });
        //    }
        //    // применяем скидку
        //    //sum = new Discount(0.1m).GetDiscountedPrice(sum);
        //    Pokypka order;
        //    if (pokprodDto.Id > 0)
        //    {
        //        order = db.Pokypka.GetItem(pokprodDto.Id);
        //        order.Date = DateTime.Now;
        //        order.Id_Sotrydnik_Fk = pokprodDto.Id_Sotrydnik_Fk;
        //        order.Stoimost = sum;
        //        db.Pokypka.Update(order);
        //    }
        //    else
        //    {
        //        order = new Pokypka
        //        {
        //            Date = DateTime.Now,
        //            Stoimost = sum,
        //            Id_Sotrydnik_Fk = pokprodDto.Id_Sotrydnik_Fk,
        //        };
        //        Buying = db.Pokypka.Create(order);
        //        foreach (PokProd i in pokypkiproduktov)
        //        {
        //            i.PokypkaId = Buying;
        //        }
        //    }
        //    if (db.Save() > 0)
        //        return true;
        //    return false;

        //}
    }
}