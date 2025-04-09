using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [Route("customer")]
    public class CMSController : Controller
    {
        #region "Constructor"
        public  CMSController()
        {

        }

        #endregion

        #region "Public Methods"
        [Route("display")]
        [HttpGet]
        public async Task<ObjectResult> GetAllCustomers()
        {
            try
            {
                List<CLDisplayModel> customlabels = new List<CLDisplayModel>();
                if (FTId == 3 && objType > 0)
                {
                    customlabels = await _appClass.GetCustomLabelsByObjTypeObjPointerAsync(FTId, objType, objPointer);
                }
                else
                {
                    customlabels = await _appClass.GetTableDisplayDataAsync(LanguageId, FTId);
                }

                return _response.OK(customlabels);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

    }
}
