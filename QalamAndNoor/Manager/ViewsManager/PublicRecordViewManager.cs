using QalamAndNoor.DataManager.ViewsDataManager;
using QalamAndNoor.MyViews;

namespace QalamAndNoor.Manager.ViewsManager
{
    public abstract class PublicRecordViewManager
    {
        public static List<PublicRecordView> GetPublicRecordViews()
        {
            return PublicRecordViewDataManager.GetPublicRecordViews().ToList();
        }
    }
}
