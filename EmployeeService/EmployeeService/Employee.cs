using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EmployeeService
{
    [MessageContract(IsWrapped = true, 
        WrapperName = "EmployeeRequestObject",
        WrapperNamespace = "http://arthead.se/Employee")]
    public class EmployeeRequest
    {
        [MessageHeader(Namespace = "http://arthead.se/Employee")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://arthead.se/Employee")]
        public int EmployeeId { get; set; }
    }


    [MessageContract(IsWrapped = true,
        WrapperName = "EmployeeInfoObject",
        WrapperNamespace = "http://arthead.se/Employee")]
    public class EmployeeInfo
    {
        public EmployeeInfo() { }

        public EmployeeInfo(Employee employee)
        {
            this.Id = employee.Id;
            this.Name = employee.Name;
            this.Gender = employee.Gender;
            this.DoB = employee.DateOfBirth;
            this.Type = employee.Type;
            if(this.Type == EmployeeType.FullTimeEmployee)
            {
                this.MonthlySalary = ((FullTimeEmployee)employee).MonthlySalary;
            }
            else
            {
                this.HourlyPay = ((PartTimeEmployee)employee).HourlyPay;
                this.HoursWorked = ((PartTimeEmployee)employee).HoursWorked;
            }
        }

        [MessageBodyMember(Order = 1, Namespace = "http://arthead.se/Employee")]
        public int Id { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://arthead.se/Employee")]
        public string Name { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://arthead.se/Employee")]
        public string Gender { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://arthead.se/Employee")]
        public DateTime DoB { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://arthead.se/Employee")]
        public EmployeeType Type { get; set; }

        [MessageBodyMember(Order = 6, Namespace = "http://arthead.se/Employee")]
        public int MonthlySalary { get; set; }

        [MessageBodyMember(Order = 7, Namespace = "http://arthead.se/Employee")]
        public int HourlyPay { get; set; }

        [MessageBodyMember(Order = 8, Namespace = "http://arthead.se/Employee")]
        public int HoursWorked { get; set; }
    }

    [KnownType(typeof(FullTimeEmployee))]
    [KnownType(typeof(PartTimeEmployee))]
    [DataContract(Namespace ="http://arthead.se/2018/10/29/Employee")]
    public class Employee
    {
        private int _id;
        private string _name;
        private string _gender;
        private DateTime _dateOfBirth;

        [DataMember(Order = 1, Name ="ID")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember(Order = 2)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember(Order = 3)]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        [DataMember(Order = 4)]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        [DataMember(Order = 5)]
        public EmployeeType Type { get; set; }
    }

    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }
}
