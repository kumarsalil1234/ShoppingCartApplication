using PromotionContracts;
using ShoppingItemsContracts;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class DataAccess
    {
        public List<ShoppingItemEntity> GetShoppingItems()
        {
            try
            {
                List<ShoppingItemEntity> lstShoppingItems = new List<ShoppingItemEntity>();
                lstShoppingItems.AddRange(new List<ShoppingItemEntity>
                {
                     new ShoppingItemEntity(1, "A",50 ),
                     new ShoppingItemEntity(2, "B",30 ),
                     new ShoppingItemEntity(3, "C",20 )
                });
                return lstShoppingItems;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PromotionEntity> GetPromotionList()
        {
            try
            {
                List<PromotionEntity> lstPromotionList = new List<PromotionEntity>();
                List<ShoppingItemEntity> lstPromotionOne = new List<ShoppingItemEntity>();
                List<ShoppingItemEntity> lstPromotionTwo = new List<ShoppingItemEntity>();
                lstPromotionOne.AddRange(new List<ShoppingItemEntity>
                {
                     new ShoppingItemEntity(1,3),
                     new ShoppingItemEntity(2,2)

                });
                lstPromotionTwo.AddRange(new List<ShoppingItemEntity>
                {
                     new ShoppingItemEntity(1,2),
                     new  ShoppingItemEntity(2,2)

                });

                lstPromotionList.AddRange(new List<PromotionEntity>
                {
                    new PromotionEntity(1,"PromotionOne","Detail one", lstPromotionOne,130 ),
                    new PromotionEntity(2,"Promotiontwo","Detailtwo", lstPromotionTwo,45)

                });
                return lstPromotionList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
