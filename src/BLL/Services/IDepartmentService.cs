using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DLL.EFCORE;
using DLL.EFCORE.Model;
using DLL.EFCORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IDepartmentService
    {
        Task<Department> Add(Department department);
        Task<List<Department>> GetAll();
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IDepartmentRepository departmentRepository,IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Department> Add(Department department)
        {
            ValidateDepartmentRequestData(department);
            var availableDepartment = await _departmentRepository.FirstOrDefaultAsync(x => x.Code == department.Code ||
                x.Name == department.Name);

            if (availableDepartment != null)
            {
                throw new Exception("name or code already in our system");
            }
            await _departmentRepository.CreateAsync(department);

            
            if (await _unitOfWork.Commit())
            {
                return department;
            }

            throw new Exception("data save not successfully");
        }

        private void ValidateDepartmentRequestData(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            if (string.IsNullOrEmpty(department.Code) || string.IsNullOrEmpty(department.Name))
            {
                throw new Exception("input is empty name or code");
            }
        }

        public async Task<List<Department>> GetAll()
        {
            return await _departmentRepository.QueryAll(null).ToListAsync();
        }
    }
}