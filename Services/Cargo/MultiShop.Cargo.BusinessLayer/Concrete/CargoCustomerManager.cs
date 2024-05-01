using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            this.cargoCustomerDal = cargoCustomerDal;
        }
        public void TDelete(int id)
        {
            cargoCustomerDal.Delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return cargoCustomerDal.GetAll();
        }

        public CargoCustomer TGetById(int id)
        {
            return cargoCustomerDal.GetById(id);
        }

        public void TInsert(CargoCustomer entity)
        {
            cargoCustomerDal.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            cargoCustomerDal.Update(entity);
        }
    }
}
