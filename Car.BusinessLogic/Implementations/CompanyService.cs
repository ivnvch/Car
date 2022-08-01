using AutoMapper;
using Car.BusinessLogic.Contracts;
using Car.Model;
using Car.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Car.BusinessLogic.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationContext _context;
        IMapper _mapper;
        public CompanyService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CompanyViewModel company)
        {
            var comp = _mapper.Map<CompanyViewModel, Company>( company );
            _context.Companies.Add(comp);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
            throw new Exception("Company not exist!");
        }

        public IEnumerable<Company> GetCompany()
        {
           return _context.Companies.AsNoTracking().ToList();
        }

        public Company GetCompany(int id)
        {
            return _context.Companies.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, CompanyViewModel company)
        {
            var comp = _mapper.Map<CompanyViewModel, Company>(company);
            _context.Update(comp);
            _context.SaveChanges();
        }
    }
}
