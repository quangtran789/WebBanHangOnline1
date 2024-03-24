using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Areas.Admin.Controllers.Prototype;

namespace WebBanHangOnline.Models.EF
{
    [Table("db_Product")]
    public class Product : CommonAbstract, IProductPrototype
    {
        public Product()
        {
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal PriceSale { get; set; }
        public string Quantity { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        public int ProductCategoryId { get; set; }
        public string SepTitle { get; set; }

        [StringLength(250)]
        public string SeoDescription { get; set; }

        [StringLength(500)]
        public string SeoKeywords { get; set; }

        [StringLength(250)]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Product Clone()
        {
            // Create a deep copy of the Product object
            return new Product
            {
                Title = this.Title,
                Alias = this.Alias,
                ProductCode = this.ProductCode,
                Description = this.Description,
                Detail = this.Detail,
                Image = this.Image,
                Price = this.Price,
                OriginalPrice = this.OriginalPrice,
                PriceSale = this.PriceSale,
                Quantity = this.Quantity,
                IsHome = this.IsHome,
                IsSale = this.IsSale,
                IsFeature = this.IsFeature,
                IsHot = this.IsHot,
                IsActive = this.IsActive,
                ProductCategoryId = this.ProductCategoryId,
                SepTitle = this.SepTitle,
                SeoDescription = this.SeoDescription,
                SeoKeywords = this.SeoKeywords,
                // You might need to copy other related entities if needed
            };
        }
    }
}
