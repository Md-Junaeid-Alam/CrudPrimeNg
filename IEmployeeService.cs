using CrudOperation.Data;
using CrudOperation.Helper;
using CrudOperation.Models;
using CrudOperation.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Repository.Services
{
    public class IEmployeeService : IEmployee
    {
        private EmployeeDbcontext _dbContext;
        PayLoad objPayload = new PayLoad();
        public IEmployeeService(EmployeeDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PayLoad> AddEmployee(EmployeeInfo employee)
        {
            try
            {
                if (employee.EmployeeId!=null) {
                    var employeeUpdate = _dbContext.EmployeeInfos.Where( x=> x.EmployeeId == employee.EmployeeId).FirstOrDefault();
                    if (employeeUpdate != null)
                    {
                        employeeUpdate.EmployeeName = employee.EmployeeName;
                        employeeUpdate.EmployeeAge = employee.EmployeeAge;
                        await _dbContext.SaveChangesAsync();
                    }
                }
                else {
                    employee.EmployeeId = Guid.NewGuid();
                    await _dbContext.AddAsync(employee);
                    var result = await _dbContext.SaveChangesAsync();
                    if (result == 1)
                    {
                        objPayload.message = "Saved SuccessFul";
                        objPayload.status = true;
                        objPayload.data = employee;
                    }
                    else
                    {
                        objPayload.message = "Saved Failed";
                        objPayload.status = false;
                    }
                }
               
                return objPayload;
            }
            catch (Exception ex)
            {
                objPayload.message = ex.Message;
                return objPayload;
            }
           

        }

        public async Task DeleteEmployee(Guid id, EmployeeInfo employee)
        {
            var employeeInfo =await _dbContext.EmployeeInfos.FindAsync(id);
            _dbContext.EmployeeInfos.Remove(employeeInfo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeInfo>> GetAllEmployee()
        {
            var employeeList = await _dbContext.EmployeeInfos.ToListAsync();
            return employeeList;

        }

        public async Task<EmployeeInfo> GetEmployee(int id)
        {
            try
            {
                var employeeById = await _dbContext.EmployeeInfos.FindAsync(id);
                return employeeById;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }

        public async Task UpdateEmployee(EmployeeInfo employee)
        {
            var EmployeeUpdate = await _dbContext.EmployeeInfos.FindAsync(employee.Id);
            if (EmployeeUpdate != null) {
                EmployeeUpdate.EmployeeName = employee.EmployeeName;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
