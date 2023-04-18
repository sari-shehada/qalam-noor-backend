using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager.ViewsManager;
using QalamAndNoor.MyViews;

namespace QalamAndNoor.Controllers.ViewsController
{
    public class PublicRecordViewController : ControllerBase
    {
        [Route("PublicRecordViewController/GetPublicRecordViews")]
        [HttpGet]
        public List<PublicRecordView> GetPublicRecordViews()
        {
            return PublicRecordViewManager.GetPublicRecordViews();
        }
    }
}
