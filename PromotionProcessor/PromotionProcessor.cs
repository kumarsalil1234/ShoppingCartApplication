using DataAccessLayer;
using PromotionContracts;
using System;
using System.Collections.Generic;

namespace PromotionProcessor
{
    public class PromotionProcessor
    {
        public List<PromotionEntity> GetPromotionList()
        {
            DataAccess objDataAccess = new DataAccess();
            return objDataAccess.GetPromotionList();
        }
    }
}
