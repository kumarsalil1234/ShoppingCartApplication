using ShoppingItemsContracts;
using System;
using System.Collections.Generic;

namespace PromotionContracts
{
    public class PromotionEntity
    {
        public int PromotionId { get; set; }

        public string PromotionName { get; set; }
        public List<ShoppingItemEntity> LstPromotionItems { get; set; }

        public int DiscountedCost { get; set; }

        public string PromotionDetail { get; set; }

        public PromotionEntity(int PromotionId, string PromotionName, string PromotionDetail, List<ShoppingItemEntity> LstPromotionItems, int DiscountedCost)
        {
            this.PromotionId = PromotionId;
            this.PromotionName = PromotionName;
            this.LstPromotionItems = LstPromotionItems;
            this.DiscountedCost = DiscountedCost;
            this.PromotionDetail = PromotionDetail;
        }
    }
}
