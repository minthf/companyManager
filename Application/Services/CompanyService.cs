using Application.Dtos.Company;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
        {
            var Companys = await _companyRepository.GetAllAsync();

            return Companys.Adapt<IEnumerable<CompanyDto>>();
        }

        public async Task<CompanyDto> GetCompanyByIdAsync(int id)
        {
            var Company = await _companyRepository.GetByIdAsync(id);


            return Company.Adapt<CompanyDto>();
        }


        public async Task<int> CreateCompanyAsync(CompanyInDto CompanyDto)
        {
            var Company = CompanyDto.Adapt<Company>();

            var result = await _companyRepository.CreateAsync(Company, true);

            return result.Id;
        }

        public async Task<CompanyDto> UpdateCompanyAsync(CompanyDto companyDto)
        {
            var product = await _companyRepository.GetByIdAsync(companyDto.Id);

            var config = new TypeAdapterConfig();
            config.NewConfig<CompanyDto, Company>()
                  .IgnoreNullValues(true);

            companyDto.Adapt(product, config);

            await _companyRepository.Update(product, true);

            return product.Adapt<CompanyDto>();

        }

        public async Task DeleteCompanyAsync(int id)
        {
            var Company = await _companyRepository.GetByIdAsync(id);
            await _companyRepository.Delete(Company, true);
        }

        public async Task<CompanyDetailsDto> GetCompanyDetailsByIdAsync(int id)
        {
            var Company = await _companyRepository.GetByIdDetailsAsync(id);


            return Company.Adapt<CompanyDetailsDto>();
        }
    }
}
