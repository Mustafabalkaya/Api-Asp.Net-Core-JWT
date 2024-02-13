using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestdal;

        public GuestManager(IGuestDal guestdal)
        {
            _guestdal = guestdal;
        }

        public void TDelete(Guest t)
        {
            _guestdal.Delete(t);
        }

        public Guest TGetById(int id)
        {
            return _guestdal.GetById(id);


        }

        public List<Guest> TGetList()
        {
            return _guestdal.GetList();
        }

        public void TInsert(Guest t)
        {
            _guestdal.Insert(t);
        }

        public void TUpdate(Guest t)
        {
            _guestdal.Update(t);
        }
    }
}
