using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        public async Task<ObjectResult> GetAllCustomers(int FTId,int objType)
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
        public async Task<ObjectResult> GetCustomersById(int FTId, int objType)
        {
            try
            {
                CLDisplayModel customlabels = new CLDisplayModel();
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
