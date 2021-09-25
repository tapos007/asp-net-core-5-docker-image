using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BLL.Services;
using DLL.EFCORE;
using DLL.EFCORE.Model;
using DLL.EFCORE.Repositories;
using Moq;
using Xunit;

namespace BLL.UnitTests
{
    public class DepartmentInsertTest
    {
        private readonly DepartmentService _departmentService;
        private readonly Department _department;
        private readonly Mock<IDepartmentRepository> _departmentRepositoryMock;
        private readonly List<Department> _availableDepartment;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        public DepartmentInsertTest()
        {
            
            _departmentRepositoryMock = new Mock<IDepartmentRepository>();
            
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            
            _departmentService = new DepartmentService(_departmentRepositoryMock.Object,_unitOfWorkMock.Object);
            _department = new Department()
            {
                Name = "bachalor of business",
                Code = "bba"
            };
            _availableDepartment = new List<Department>()
            {
                new Department()
                {
                    Name = "computer science & engineering",
                    Code = "cse"
                }
            };
        }

        [Fact]
        public async Task ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _departmentService.Add(null));
            Assert.Equal("department", exception.ParamName);
            var dataEmptyException =
                await Assert.ThrowsAsync<Exception>(() => _departmentService.Add(new Department()));
            Assert.Equal("input is empty name or code", dataEmptyException.Message);
        }

        [Fact]
        public async Task ShouldNotStoreDepartmentIfNameOrCodeAlreadyInSystem()
        {
            Expression<Func<Department, bool>> testExpression = binding =>
                (binding.Name == _department.Name || binding.Code == _department.Code);

            _departmentRepositoryMock.Setup(x =>
                    x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Department, bool>>>()))
                .ReturnsAsync(_department);

           
            var dataEmptyException =
                await Assert.ThrowsAsync<Exception>(() => _departmentService.Add(_department));
            Assert.Equal("name or code already in our system", dataEmptyException.Message);
           
        }

        [Fact]
        public async Task ShouldSaveDepartment()
        {
            _departmentRepositoryMock.Setup(x =>
                    x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Department, bool>>>()))
                .ReturnsAsync(() => null);

            _unitOfWorkMock.Setup(x => x.Commit()).ReturnsAsync(true);
           var response =  await _departmentService.Add(_department);
            _departmentRepositoryMock.Verify(x => x.CreateAsync(_department), Times.Once);
            
            _unitOfWorkMock.Verify(x => x.Commit(), Times.Once);

           
            
            Assert.Equal(_department.Code,response.Code);
            Assert.Equal(_department.Name,response.Name);
            
            
        }
    }
}