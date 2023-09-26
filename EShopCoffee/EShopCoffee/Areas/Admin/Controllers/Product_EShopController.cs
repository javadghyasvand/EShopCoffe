using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShopCoffee.Models.DataLayer;
using InsertShowImage;
using KooyWebApp_MVC.Classes;
using MyShop.Utilities;

namespace EShopCoffee.Areas.Admin.Controllers
{
    public class Product_EShopController : Controller
    {
        private readonly EShopCoffe_DBEntities _db = new EShopCoffe_DBEntities();

        #region Product

        // GET: Admin/Product_EShop
        public ActionResult Index()
        {
            var productList=_db.Product_EShop.OrderByDescending(p => p.Product_CreateDate);
            return View(productList.Where(p => p.Product_Is_Delete == false).ToList());
        }
        // GET: Admin/Product_EShop/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product_EShop productEShop = _db.Product_EShop.Find(id);
            if (productEShop == null)
            {
                return HttpNotFound();
            }

            return View(productEShop);
        }

        // GET: Admin/Product_EShop/Create
        public ActionResult Create()
        {
            ViewBag.Groups = _db.Product_Groups.ToList();
            return View();
        }

        // POST: Admin/Product_EShop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include =
                "ProductId,Proudct_Title,Product_Count,Product_IsInStock,Product_Discription,ProductPrice,Product_ImageName,Product_CreateDate,Product_Is_Delete")]
            Product_EShop productEShop, HttpPostedFileBase imageProduct, string tags, List<int> selectedGroup)
        {
            if (ModelState.IsValid)
            {
                if (selectedGroup == null)
                {
                    ViewBag.ErorrSelectedGroups = true;
                    ViewBag.Groups = _db.Product_Groups.ToList();
                    return View(productEShop);
                }

                productEShop.Product_ImageName = "images.png";
                if (imageProduct != null && imageProduct.IsImage())
                {
                    productEShop.Product_ImageName =
                        Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + productEShop.Product_ImageName));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Images/ProductImages/" + productEShop.Product_ImageName),
                        Server.MapPath("/Images/ProductImages/Thumbnail/" + productEShop.Product_ImageName));
                }
                else
                {
                    ViewBag.ErorrIsImage = true;
                    ViewBag.Groups = _db.Product_Groups.ToList();
                    return View(productEShop);
                }
                productEShop.Product_CreateDate = DateTime.Now;
                _db.Product_EShop.Add(productEShop);
                foreach (int group in selectedGroup)
                {
                    _db.Product_Select_Groups.Add(new Product_Select_Groups()
                    {
                        Product_Id = productEShop.Product_Id,
                        Group_Id = group
                    });
                }

                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tagsArray = tags.Split('#');
                    foreach (string tag in tagsArray)
                    {
                        _db.Product_Tags.Add(new Product_Tags()
                        {
                            Product_Id = productEShop.Product_Id,
                            Tag = tag.Trim(),
                        });
                    }
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productEShop);
        }

        // GET: Admin/Product_EShop/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product_EShop products = _db.Product_EShop.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }

            ViewBag.SelectedGroups = products.Product_Select_Groups.ToList();
           
            ViewBag.Groups = _db.Product_Groups.ToList();
            ViewBag.Tags = string.Join("#", products.Product_Tags.Select(t => t.Tag).ToList());

            return View(products);
        }

        // POST: Admin/Product_EShop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include =
                "ProductId,Proudct_Title,Product_Count,Product_IsInStock,Product_Discription,ProductPrice,Product_ImageName,Product_CreateDate,Product_Is_Delete")]
            Product_EShop productEShop, HttpPostedFileBase imageProduct, string tags, List<int> selectedGroup)

        {
            if (ModelState.IsValid)
            {
                if (imageProduct != null && imageProduct.IsImage())
                {
                    if (imageProduct.FileName == "images.png")
                    {
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/ProductImages/" +
                                                             productEShop.Product_ImageName));
                        System.IO.File.Delete(Server.MapPath("/Images/ProductImages/Thumbnail/" +
                                                             productEShop.Product_ImageName));
                        productEShop.Product_ImageName =
                            Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                        imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + productEShop.Product_ImageName));
                        ImageResizer imageResizer = new ImageResizer();
                        imageResizer.Resize(Server.MapPath("/Images/ProductImages/" + productEShop.Product_ImageName),
                            Server.MapPath("/Images/ProductImages/Thumbnail/" + productEShop.Product_ImageName));
                    }
                }

                _db.Entry(productEShop).State = EntityState.Modified;
                _db.Product_Tags.Where(t => t.Product_Id == productEShop.Product_Id).ToList()
                    .ForEach(t => _db.Product_Tags.Remove(t));
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tagsArray = tags.Split('#');
                    foreach (string tag in tagsArray)
                    {
                        _db.Product_Tags.Add(new Product_Tags()
                        {
                            Product_Id = productEShop.Product_Id,
                            Tag = tag.Trim(),
                        });
                    }
                }

                _db.Product_Select_Groups.Where(g => g.Product_Id == productEShop.Product_Id).ToList()
                    .ForEach(groups => _db.Product_Select_Groups.Remove(groups));
                if (selectedGroup != null && selectedGroup.Any())
                {
                    foreach (int group in selectedGroup)
                    {
                        _db.Product_Select_Groups.Add(new Product_Select_Groups()
                        {
                            Product_Id = productEShop.Product_Id,
                            Group_Id = group
                        });
                    }
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SelectedGroups = selectedGroup;
            ViewBag.Groups = _db.Product_Groups.ToList();
            ViewBag.Tags = tags;
            return View(productEShop);
        }

        // GET: Admin/Product_EShop/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product_EShop product_EShop = _db.Product_EShop.Find(id);
            if (product_EShop == null)
            {
                return HttpNotFound();
            }

            return View(product_EShop);
        }

        // POST: Admin/Product_EShop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product_EShop product_EShop = _db.Product_EShop.Find(id);
            _db.Product_EShop.Remove(product_EShop);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

        public ActionResult RemoveProductsList()
        {
            return View(_db.Product_EShop.Where(p => p.Product_Is_Delete == true));
        }

        #endregion

        #region Gallery
        public ActionResult Gallery(int id)
        {
            ViewBag.Gallery = _db.Product_Galllery.Where(g => g.Product_Id == id).ToList();
            return View(new Product_Galllery()
            {
                Product_Id = id,
            });
        }
        [HttpPost]
        public ActionResult Gallery(Product_Galllery productGalleries, HttpPostedFileBase imageProduct)
        {
            if (ModelState.IsValid)
            {
                if (imageProduct != null && imageProduct.IsImage())
                {
                    productGalleries.Gallery_Image_Name = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + productGalleries.Gallery_Image_Name));
                    ImageResizer imgResizer = new ImageResizer();
                    imgResizer.Resize(Server.MapPath("/Images/ProductImages/" + productGalleries.Gallery_Image_Name),
                        Server.MapPath("/Images/ProductImages/Thumbnail/" + productGalleries.Gallery_Image_Name));
                    _db.Product_Galllery.Add(productGalleries);
                    _db.SaveChanges();
                    return RedirectToAction("Gallery", new { id = productGalleries.Product_Id });
                }
            }
            return RedirectToAction("Gallery", new { id = productGalleries.Product_Id });
        }

        public ActionResult DeleteGallery(int id)
        {
            var gallery = _db.Product_Galllery.Find(id);
            System.IO.File.Delete(Server.MapPath("/Images/ProductImages/" + gallery.Gallery_Image_Name));
            System.IO.File.Delete(Server.MapPath("/Images/ProductImages/Thumbnail/" + gallery.Gallery_Image_Name));
            _db.Product_Galllery.Remove(gallery);
            _db.SaveChanges();
            return RedirectToAction("Gallery", new { id = gallery.Product_Id });
        }
        #endregion

        #region Property
        public ActionResult ProductProperty(int id)
        {
            ViewBag.Property = _db.Product_Proerty_Select.Where(f => f.Product_Id == id);
            ViewBag.PropertyId = _db.Product_Property.ToList();
            return View(new Product_Proerty_Select()
            {
                Product_Id = id
            });
        }

        [HttpPost]
        public ActionResult ProductProperty(Product_Proerty_Select property)
        {
            if (ModelState.IsValid)
            {
                _db.Product_Proerty_Select.Add(property);
                _db.SaveChanges();
            }
            return RedirectToAction("ProductProperty", new { id = property.Product_Id });
        }
        public void DeleteFeature(int id)
        {
            var feature = _db.Product_Proerty_Select.Find(id);
            if (feature != null) _db.Product_Proerty_Select.Remove(feature);
            _db.SaveChanges();

        }
        #endregion

        #region Discount

        public ActionResult DiscountProduct(long id)
        {
            ViewBag.ProductTitle = _db.Product_EShop.Single(p => p.Product_Id == id).Proudct_Title;
            if (_db.PersntOff.Any(g => g.Product_Id == id))
            {
                var discount = _db.PersntOff.Single(p => p.Product_Id == id);
                ViewBag.Header = "ویرایش";
                return View(new PersntOff()
                {
                    Product_Id =discount.Product_Id,
                    Start_Date =discount.Start_Date ,
                    End_Date = discount.End_Date,
                    Persent_Off = discount.Persent_Off,
                    Off_Id =discount.Off_Id,
                    IsExpire = discount.IsExpire
                });
            }
            ViewBag.Header = "افزودن";
            return View(new PersntOff()
            {
                Product_Id = _db.Product_EShop.Single(p => p.Product_Id == id).Product_Id,
                End_Date = DateTime.Today.Date,
                Start_Date = DateTime.Today.Date,

            });
        }
        [HttpPost]
        public ActionResult DiscountProduct(PersntOff persntoff)
        {
            ViewBag.ProductTitle = _db.Product_EShop.Single(p => p.Product_Id == persntoff.Product_Id).Proudct_Title;
            if (ModelState.IsValid)
            {
                if (persntoff.Persent_Off != 0)
                {
                    if (!_db.PersntOff.Any(p => p.Product_Id == persntoff.Product_Id))
                    {
                        ViewBag.Header = "افزودن";
                        _db.PersntOff.Add(persntoff);
                    }
                    else
                    {
                        ViewBag.Header = "ویرایش";
                        _db.Entry(persntoff).State = EntityState.Modified;
                    }
                    _db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Persent_Off","درصد تخفیف نمی تواند 0 باشد");
              
                }
                
                
            }
            return View (persntoff);
        }
        #endregion
    }

}

