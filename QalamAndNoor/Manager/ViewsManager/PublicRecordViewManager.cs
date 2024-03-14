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
        public static List<PublicRecordView> GetPublicRecordViewsByClassId(int cls)
        {
            List<PublicRecordView> publicRecordViews = GetPublicRecordViews();
            List<PublicRecordView>result=new List<PublicRecordView>();
            foreach (PublicRecordView recordView in publicRecordViews)
            {
                if (recordView.ClassId==cls)
                {
                    result.Add(recordView);
                }
            }
            return result;
        }

      
    }
}
