using DataAccessLayer;
using ShoppingItemsContracts;
using System;
using System.Collections.Generic;

namespace ShoppingItemsProcessor
{
    public class ShoppingItemProcessor
    {
        public List<ShoppingItemEntity> GetShoppingItems()
        {
            DataAccess objDataAccess = new DataAccess();
            return objDataAccess.GetShoppingItems();
        }
    }
}
