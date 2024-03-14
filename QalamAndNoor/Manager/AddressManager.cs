using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class AddressManager
    {
        public static List<Address> GetAddresses()
        {
            return AddressDataManager.GetAddresses().ToList();
        }
        public static int InsertAddress(Address address)
        {
            return AddressDataManager.InsertAddress(address);
        }
        public static int UpdateAddress(Address address)
        {
            return AddressDataManager.UpdateAddress(address);
        }
        public static int DeleteAddress(Address address)
        {
            return AddressDataManager.DeleteAddress(address);
        }
        public static Address GetAddressById(int id)
        {
            List<Address> addresses = GetAddresses();
            foreach (Address address in addresses)
            {
                if (address.ID == id)
                {
                    return address;
                }
            }
            return null;
        }

        public static List<Address> GetAddressesByName(string name)
        {
            List<Address> addresses = GetAddresses();
            List<Address> result = new List<Address>();
            foreach (Address item in addresses)
            {
                if (item.Name.Trim().ToLower().Contains(name.Trim().ToLower()))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Address> GetAddressesByAreaId(int areaId)
        {
            List<Address> addresses = GetAddresses();
            List<Address> result = new List<Address>();
            foreach (Address item in addresses)
            {
                if (item.AreaId == areaId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Address> GetAddressByCityId(int cityId)
        {
            List<Area> areas = AreaManager.GetAreasByCityId(cityId);
            List<Address> result = new List<Address>();
            foreach (Area area in areas)
            {
                List<Address> addresses = GetAddressesByAreaId(area.ID);
                foreach (Address address in addresses)
                {
                    result.Add(address);
                }
            }
            return result;
        }
        public static int GetAddresesCountByCityId(int cityId)
        {
            return GetAddressByCityId(cityId).Count;
        }

        public static Address GetAddressByStudentId(int studentId) {
            Student student = StudentManager.GetStudentById(studentId);
            return GetAddressById(student.AddressId);
        
        }
    }
}
