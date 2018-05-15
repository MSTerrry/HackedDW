using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DW.Web.Migrations;

namespace DW.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<DbDeliveryRquest> DeliveryRequest { get; set; }
        public DbSet<DbWayPoint> waypoints { get; set; }
        public DbSet<DbProduct> productList { get; set; }
    }
   
    public class DbDeliveryRquest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Дата заполнения
        /// </summary>
        public DateTime Filled { get; set; }

        /// <summary>
        /// ФИО клиента
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Описание пути
        /// </summary>
        public virtual Collection<DbWayPoint> WayPoints { get; set; }

        /// <summary>
        /// Время доставки
        /// </summary>
        public DateTime TimeDeliver { get; set; }

        /// <summary>
        /// Адрес клиента
        /// </summary>
        public string ClientAddress { get; set; }

        /// <summary>
        /// Общая стоимость
        /// </summary>
        public decimal TotalCost { get; set; }

        
    }

    public class DbWayPoint
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название места
        /// </summary>
        public string PlaceTitle { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Тип места
        /// </summary>
        public string ShopType { get; set; }

        /// <summary>
        /// Список продуктов к покупке в этом месте
        /// </summary>
        public virtual Collection<DbProduct> ProductsList { get; set; }

        /// <summary>
        /// Общая стоимость
        /// </summary>
        public decimal TotalCost { get; set; }

        public override string ToString()
        {
            return PlaceTitle;
        }
    }

    public class DbProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Дополнительные сведения о продукте
        /// </summary>
        public string Additions { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public float Cost { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1:0.00} {2} {3} руб.", Name, Amount, Additions, Cost);
        }
    }
}