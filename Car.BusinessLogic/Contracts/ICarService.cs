using Car.Model;
using Car.ViewModel;

namespace Car.BusinessLogic.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarC> GetCars();
        CarC GetCar(int id);
        void Create(CarViewModel carView);
        void Update(int id, CarViewModel carView);
        void Delete(int id);
    }
}
