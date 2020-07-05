using System;

namespace ShoppingItemsContracts
{
    public class ShoppingItemEntity
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemCost { get; set; }

        public int ItemCountForPromotion { get; set; }

        public ShoppingItemEntity(int ItemId, string ItemName, int ItemCost)
        {

            this.ItemId = ItemId;
            this.ItemName = ItemName;
            this.ItemCost = ItemCost;
        }
        public ShoppingItemEntity(int ItemId, int ItemCountForPromotion)
        {
            this.ItemId = ItemId;
            this.ItemCountForPromotion = ItemCountForPromotion;
        }
    }

}
