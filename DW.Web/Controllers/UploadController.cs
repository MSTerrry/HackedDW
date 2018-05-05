using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeliveryWizard;
using DW.Web.Models;
using System.Collections.ObjectModel;

namespace DW.Web.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Print(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var dto = DeliverySerializer.LoadFromStream(file.InputStream);
                
                using (var db = new ApplicationDbContext())
                {
                    var row = new DbDeliveryRquest
                    {
                        ClientAddress = dto.ClientAddress,
                        Filled = dto.Filled,
                        TimeDeliver = dto.TimeDeliver,
                        TotalCost = dto.TotalCost,
                        FullName = dto.FullName
                    };

                    row.WayPoints = new Collection<DbWayPoint>();                    
                    
                    foreach (var wpDto in dto.WayPoints)
                    {                                               
                        row.WayPoints.Add(new DbWayPoint
                        {
                            Address = wpDto.Address,
                            PlaceTitle = wpDto.PlaceTitle,
                            ShopType = wpDto.ShopType,                                                         
                        });
                        var Pl = new Collection<DbProduct>();
                        foreach (var product in wpDto.ProductsList)
                        {
                            Pl.Add(new DbProduct
                            {
                                Name = product.Name,
                                Amount = product.Amount,
                                Additions = product.Additions,
                                Cost = product.Cost,                                
                            });
                        }
                        db.productList.AddRange(Pl);
                    }                    
                    db.DeliveryRequest.Add(row);                                       
                    db.SaveChanges();
                }
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}