using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class AddressController :ControllerBase
    {
        [Route("AddressController/InsertAddress")]
        [HttpPost]
        public int InsertAddress([FromBody] Address address)
        {
            return AddressManager.InsertAddress(address);
        }
        [Route("AddressController/UpdateAddress")]
        [HttpPost]
        public int UpdateAddress([FromBody] Address address)
        {
            return AddressManager.UpdateAddress(address);
        }
        [Route("AddressController/DeleteAddress")]
        [HttpPost]
        public int DeleteAddress([FromBody] Address address)
        {
            return AddressManager.DeleteAddress(address);
        }
        [Route("AddressController/GetAddresses")]
        [HttpGet]
        public List<Address> GetAddresses()
        {
            return AddressManager.GetAddresses();

        }
        [Route("AddressController/GetAddressById")]
        [HttpGet]
        public Address GetAddressById(int id)
        {
            return AddressManager.GetAddressById(id);
        }
        [Route("AddressController/GetAddressesByName")]
        [HttpGet]
        public List<Address> GetAddressesByName(string name)
        {
            return AddressManager.GetAddressesByName(name);

        }
        [Route("AddressController/GetAddressesByAreaId")]
        [HttpGet]
        public List<Address> GetAddressesByAreaId(int areaId)
        {
            return AddressManager.GetAddressesByAreaId(areaId);

        }
        [Route("AddressController/GetAddressByCityId")]
        [HttpGet]
        public List<Address> GetAddressByCityId(int cityId)
        {
            return AddressManager.GetAddressByCityId(cityId);

        }
        [Route("AddressController/GetAddresesCountByCityId")]
        [HttpGet]
        //zfgffff
        public int GetAddresesCountByCityId(int cityId)
        {
            return AddressManager.GetAddresesCountByCityId(cityId);
        }
        [Route("AddressController/GetAddresesCount")]
        [HttpGet]
        public int GetAddresesCount()
        {
            return AddressManager.GetAddresses().Count;
        }

    }
}
