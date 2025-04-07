using PromotionBannerManagement.Entities;

namespace PromotionBannerManagement.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Company> GetAll()
        {
            return _dbContext.Companies.ToList(); 
        }

        public Company? GetById(int id)
        {
            return _dbContext.Companies.FirstOrDefault(c => c.Id == id); 
        }

        public Company Create(Company company)
        {
            var newCompanyEntry = _dbContext.Companies.Add(company);
            _dbContext.SaveChanges(); 
            return newCompanyEntry.Entity; 
        }

        public Company Update(Company company)
        {
            var updatedCompanyEntry = _dbContext.Companies.Update(company);
            _dbContext.SaveChanges();
            return updatedCompanyEntry.Entity;
        }

        public bool Delete(Company company)
        {
            _dbContext.Companies.Remove(company); 
            _dbContext.SaveChanges();
            return true;
        }
    }
}