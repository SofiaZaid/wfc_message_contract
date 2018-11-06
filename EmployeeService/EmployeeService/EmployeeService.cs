using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel.Web;
using System.Net;

namespace EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeInfo GetEmployee(EmployeeRequest request)
        {
            if (request.LicenseKey != "SuperSecret123")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden);
            }
            else
            {
                Employee employee = null;
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameterId = new SqlParameter();
                    parameterId.ParameterName = "@Id";
                    parameterId.Value = request.EmployeeId;

                    cmd.Parameters.Add(parameterId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((EmployeeType)reader["EmployeeType"] == EmployeeType.FullTimeEmployee)
                        {
                            employee = new FullTimeEmployee
                            {
                                Type = EmployeeType.FullTimeEmployee,
                                MonthlySalary = Convert.ToInt32(reader["MonthlySalary"])
                            };
                        }
                        else
                        {
                            employee = new PartTimeEmployee
                            {
                                Type = EmployeeType.PartTimeEmployee,
                                HourlyPay = Convert.ToInt32(reader["HourlyPay"]),
                                HoursWorked = Convert.ToInt32(reader["HoursWorked"])
                            };
                        }
                        employee.Id = Convert.ToInt32(reader["Id"]);
                        employee.Name = reader["Name"].ToString();
                        employee.Gender = reader["Gender"].ToString();
                        employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    }
                }
                return new EmployeeInfo(employee);
            }
        }

        public void SaveEmployee(EmployeeInfo employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = employee.Id
                };
                cmd.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = employee.Name
                };
                cmd.Parameters.Add(parameterName);

                SqlParameter parameterGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = employee.Gender
                };
                cmd.Parameters.Add(parameterGender);


                SqlParameter parameterDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DoB
                };
                cmd.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterEmployeeType = new SqlParameter
                {
                    ParameterName = "@EmployeeType",
                    Value = employee.Type
                };
                cmd.Parameters.Add(parameterEmployeeType);

                if (employee.Type == EmployeeType.FullTimeEmployee)
                {
                    SqlParameter parameterMonthlySalary = new SqlParameter
                    {
                        ParameterName = "@MonthlySalary",
                        Value = employee.MonthlySalary
                    };
                    cmd.Parameters.Add(parameterMonthlySalary);
                }
                else
                {
                    SqlParameter parameterHourlyPay = new SqlParameter
                    {
                        ParameterName = "@HourlyPay",
                        Value = employee.HourlyPay
                    };
                    cmd.Parameters.Add(parameterHourlyPay);

                    SqlParameter parameterHoursWorked = new SqlParameter
                    {
                        ParameterName = "@HoursWorked",
                        Value = employee.HoursWorked
                    };
                    cmd.Parameters.Add(parameterHoursWorked);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
