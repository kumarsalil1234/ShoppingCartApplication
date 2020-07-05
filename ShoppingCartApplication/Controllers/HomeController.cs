using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PromotionContracts;
using ShoppingItemsContracts;
using ShoppingItemsProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ShoppingItemProcessor objShoppingItemProcessor = new ShoppingItemProcessor();
            PromotionProcessor.PromotionProcessor objPromotionProcessor = new PromotionProcessor.PromotionProcessor();
            ViewBag.ItemList = ToSelectList(objShoppingItemProcessor.GetShoppingItems());
            ViewBag.PromotionList = ToSelectListForPromotion(objPromotionProcessor.GetPromotionList());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public JsonResult CalculateShoppingCost(string jsonData)
        {
            PromotionProcessor.PromotionProcessor objPromotionProcessor = new PromotionProcessor.PromotionProcessor();
            int promoId = (int)JArray.Parse(jsonData).Children()["PromoId"].First();
            PromotionEntity objPromotion = objPromotionProcessor.GetPromotionList().Where(x => x.PromotionId == promoId).ToList()[0];
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonData);
            int jCount = jsonObj.Count;
            int netShoppingCost = 0;
            int i = 1;
            foreach (var obj in jsonObj)
            {
                if (i < jCount)
                {
                    int itemid = Convert.ToInt32(obj.Itemid);
                    int itemCount = Convert.ToInt32(obj.ItemIdCount);
                    netShoppingCost += TotalItemCostWithOrWithoutPromotion(objPromotion, itemid, itemCount);
                    i++;
                }

            }

            return Json("data", JsonRequestBehavior.AllowGet);
        }

        public int TotalItemCostWithOrWithoutPromotion(PromotionEntity objPromotion, int itemId, int itemCount)
        {
            ShoppingItemProcessor objShoppingItemProcessor = new ShoppingItemProcessor();
            ShoppingItemEntity objShoppingItem = objShoppingItemProcessor.GetShoppingItems().Where(x => x.ItemId == itemId).ToList()[0];
            int promoTotalCost = 0;
            int itemNotEligibleForDiscount = itemCount;// if promocode is not applicable
            int itemEligibleForPromotionCount = 0;
            int totalCost = 0;
            if (objPromotion != null)
            {
                var objPromotionShopItem = objPromotion.LstPromotionItems.Where(x => x.ItemId == itemId).ToList()[0];
                itemNotEligibleForDiscount = itemCount % objPromotionShopItem.ItemCountForPromotion;
                itemEligibleForPromotionCount = itemCount - itemNotEligibleForDiscount;
                if (itemEligibleForPromotionCount > 0)
                {
                    promoTotalCost = (itemEligibleForPromotionCount / objPromotionShopItem.ItemCountForPromotion) * objPromotion.DiscountedCost;

                }
            }
            totalCost = (itemNotEligibleForDiscount * objShoppingItem.ItemCost) + promoTotalCost;
            return totalCost;

        }
        public SelectList ToSelectListForPromotion(List<PromotionEntity> lstPromotionItem)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = "Select"
            });
            foreach (PromotionEntity row in lstPromotionItem)
            {
                list.Add(new SelectListItem()
                {
                    Text = row.PromotionName.ToString(),
                    Value = row.PromotionId.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }


        public SelectList ToSelectList(List<ShoppingItemEntity> lstShopItems)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (ShoppingItemEntity row in lstShopItems)
            {
                list.Add(new SelectListItem()
                {
                    Text = row.ItemName.ToString(),
                    Value = row.ItemId.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}