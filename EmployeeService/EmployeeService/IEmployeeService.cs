using System.Collections.Generic;
using System.ServiceModel;


namespace EmployeeService
{
    //[ServiceKnownType(typeof(FullTimeEmployee))]
    //[ServiceKnownType(typeof(PartTimeEmployee))]
    [ServiceContract]
    public interface IEmployeeService
    {
        //[ServiceKnownType(typeof(FullTimeEmployee))]
        //[ServiceKnownType(typeof(PartTimeEmployee))]
        [OperationContract]
        EmployeeInfo GetEmployee(EmployeeRequest request);

        [OperationContract]
        void SaveEmployee(EmployeeInfo employee);
    }
}
