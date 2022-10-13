namespace FoodieOnline.Repository
{
    public class CatagoeryRepository : ICatagoeryRepository
    {
     
        private readonly FoodieContext context;

        public CatagoeryRepository(FoodieContext context)
        {
            this.context = context;
        }
        public async Task<APIResult> AddCatagoery(Catagoery catagoery)
        {
            try
            {
                catagoery.UpdatedDate = null;
                var LastInsertedId = await context.Catagoery.OrderBy(x => x.catagoeryId).LastOrDefaultAsync();
                var data = await context.Catagoery.AddAsync(catagoery);
                await context.SaveChangesAsync();
                return new APIResult
                {
                    Message = "New Catagoery Added Successfully",
                    Status = "200",
                    Id = "Last Inserted Id Value Is:" + LastInsertedId.catagoeryId,
                    CurrentId = "Current Inserted Id Value Is:" + catagoery.catagoeryId
                };
            }
            catch (Exception ex)
            {

                return new APIResult
                {
                    Message = ex.Message,
                    Status = "400"
                };
            }
            
        }

        public async Task<APIResult> DeleteCatagoery(int CatagoeryId)
        {
            try
            {
                var catagoery = await context.Catagoery.SingleOrDefaultAsync(x => x.catagoeryId == CatagoeryId);
                if(catagoery !=null)
                {
                    var data = context.Catagoery.Remove(catagoery);
                    await context.SaveChangesAsync();
                }
                else
                {
                    return new APIResult
                    {
                        Message = "No Data Found For Given Id"
                    };
                }
                
                return new APIResult
                {
                    Message = "Catagory Deleted Successfully"
                };
            }
            catch (Exception ex)
            {

                return new APIResult
                {
                    Message = ex.Message,
                    Status="400"
                };
            }
        }

        public async Task<CatagoeryViewModel> GetCatagoery()
        {
            try
            {
                var data = await context.Catagoery.ToListAsync();
                if(data == null)
                {
                    return null;
                }
                return new CatagoeryViewModel
                {
                    Count=data.Count,CatagoeryList=data
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Catagoery> GetCatagoeryById(int CatagoeryId)
        {
            try
            {
                var data = await context.Catagoery.SingleOrDefaultAsync(x=>x.catagoeryId==CatagoeryId);
                if(data==null)
                {
                    return null;
                }
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<APIResult> UpdateCatagoery(Catagoery catagoery)
        {
            try
            {
                catagoery.UpdatedDate = DateTime.Now;
                var data = context.Catagoery.Update(catagoery);
                await context.SaveChangesAsync();
                return new APIResult
                {
                    Message = "Catagoery Updated Successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {

                return new APIResult
                {
                    Message = ex.Message,
                    Status = "400"
                };
            }
        }
    }
}
