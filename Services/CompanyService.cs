using PromotionBannerManagement.DTOs;
using PromotionBannerManagement.Entities;
using PromotionBannerManagement.Repositories;

namespace PromotionBannerManagement.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public List<Company> GetAllCompanies()
        {
            return _companyRepository.GetAll();
        }

        public Company GetCompanyById(int id)
        {
            var company = _companyRepository.GetById(id);
            return company ?? throw new KeyNotFoundException("Company not found.");
        }

        public bool CreateCompany(CreateCompanyDTO company)
        {
            var newCompany = new Company()
            {
                Name = company.Name,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
            };

            var createdCompany = _companyRepository.Create(newCompany);

            return createdCompany != null;
        }

        public bool UpdateCompany(int id, UpdateCompanyDTO company)
        {
            var existingCompany = _companyRepository.GetById(id);

            if (existingCompany == null)
            {
                return false;
            }

            existingCompany.Name = company.Name;
            existingCompany.Address = company.Address;

            var updatedCompany = _companyRepository.Update(existingCompany);

            return updatedCompany != null;
        }

        public bool DeleteCompany(int id)
        {
            var existingCompany = _companyRepository.GetById(id);

            if (existingCompany == null)
            {
                return false;
            }

            var deleteSuccess = _companyRepository.Delete(existingCompany);

            return deleteSuccess;
        }
    }
}