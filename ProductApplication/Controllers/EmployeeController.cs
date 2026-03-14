using ProductApplication.Models;
using ProductApplication.Repositories;
using System.Net;
using System.Web.Http;

namespace ProductApplication.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        #region Private fields

        private readonly EmployeeRepository _employeeRepository;

        #endregion

        #region Constructors

        public EmployeeController()
            => _employeeRepository = new EmployeeRepository();

        #endregion

        #region Public logic

        [HttpGet]
        [Route("GetAllEmployeeDetails")]
        public IHttpActionResult GetAllEmployeeDetails()
        {
            try
            {
                var employees = _employeeRepository.GetAllEmployees();

                return Ok(employees);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (_employeeRepository.AddEmployee(employee))
                    return Ok("Employee details added successfully.");

                return StatusCode(HttpStatusCode.InternalServerError);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [Route("EditEmployeeDetails/{id}")]
        public IHttpActionResult EditEmployeeDetails(int id, [FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (_employeeRepository.UpdateEmployee(employee))
                    return Ok("Employee details updated successfully.");

                return NotFound();
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                if (_employeeRepository.DeleteEmployee(id))
                    return Ok("Employee details deleted successfully.");

                return NotFound();
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        #endregion
    }
}