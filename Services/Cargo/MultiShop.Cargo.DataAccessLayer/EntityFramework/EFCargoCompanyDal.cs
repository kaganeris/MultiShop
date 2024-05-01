using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EFCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EFCargoCompanyDal(CargoContext context) : base(context)
        {
        }
    }
}
