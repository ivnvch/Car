using AutoMapper;
using Car.BusinessLogic.Contracts;
using Car.Model;
using Car.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.BusinessLogic.Implementations
{
    public class CarService : ICarService
    {
        ApplicationContext _context;
        IMapper _mapper;
        public CarService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CarViewModel car)
        {
            var _car = _mapper.Map<CarViewModel, CarC>(car);
            _context.Cars.Add(_car);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
            throw new Exception("Car not exist!");
        }

        public CarC GetCar(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CarC> GetCars()
        {
            return _context.Cars.AsNoTracking().ToList();
        }

        public void Update(int id, CarViewModel car)
        {
            var updateCar = _context.Cars.FirstOrDefault(x => x.Id == id);
            var _car = _mapper.Map<CarViewModel, CarC>(car);

            if (updateCar == null)
            {
                throw new Exception("Game not found");
            }
            updateCar = _car;
            _context.Cars.Update(updateCar);
            _context.SaveChanges();
        }
    }
}
