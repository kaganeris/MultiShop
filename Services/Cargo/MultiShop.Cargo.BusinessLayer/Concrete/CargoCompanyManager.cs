using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            this.cargoCompanyDal = cargoCompanyDal;
        }
        public void TDelete(int id)
        {
            cargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
            return cargoCompanyDal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return cargoCompanyDal.GetById(id);
        }

        public void TInsert(CargoCompany entity)
        {
            cargoCompanyDal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            cargoCompanyDal.Update(entity);
        }
    }
}
