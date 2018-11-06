using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeWebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeService.IEmployeeService client = new
                EmployeeService.EmployeeServiceClient();

            EmployeeService.EmployeeRequest request = new EmployeeService.EmployeeRequest();
            request.LicenseKey = "SuperSecret123!!";
            request.EmployeeId = Convert.ToInt32(txtId.Text);


            EmployeeService.EmployeeInfo employee = client.GetEmployee(request);

            txtName.Text = employee.Name;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DoB.ToShortDateString();
            DropDownList1.SelectedValue = ((int)employee.Type).ToString();
            if(employee.Type == EmployeeService.EmployeeType.FullTimeEmployee)
            {
                txtMonthlySalary.Text = employee.MonthlySalary.ToString();
                trMonthlySalary.Visible = true;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                txtHourlyPay.Text = employee.HourlyPay.ToString();
                txtHoursWorked.Text = employee.HoursWorked.ToString();
                trMonthlySalary.Visible = false;
                trHourlyPay.Visible = true;
                trHoursWorked.Visible = true;
            }

            lblMessage.Text = "Employee retrieved";
        }

        protected void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue == "-1")
            {
                lblMessage.Text = "Please select Employee Type";
            }
            else
            { 
                EmployeeService.IEmployeeService client = new
                    EmployeeService.EmployeeServiceClient();

                EmployeeService.EmployeeInfo employee = new EmployeeService.EmployeeInfo();


                if(((EmployeeService.EmployeeType)Convert.ToInt32(DropDownList1.SelectedValue))
                    == EmployeeService.EmployeeType.FullTimeEmployee)
                {
                    employee.Type = EmployeeService.EmployeeType.FullTimeEmployee;
                    employee.MonthlySalary = Convert.ToInt32(txtMonthlySalary.Text);
                }
                else if (((EmployeeService.EmployeeType)Convert.ToInt32(DropDownList1.SelectedValue))
                    == EmployeeService.EmployeeType.PartTimeEmployee)
                {

                    employee.Type = EmployeeService.EmployeeType.PartTimeEmployee;
                    employee.HourlyPay = Convert.ToInt32(txtHourlyPay.Text);
                    employee.HoursWorked = Convert.ToInt32(txtHoursWorked.Text);
                }
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Gender = txtGender.Text;
                employee.DoB = Convert.ToDateTime(txtDateOfBirth.Text);

 
                client.SaveEmployee(employee);

                lblMessage.Text = "Employee saved";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue == "-1")
            {
                trMonthlySalary.Visible = false;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "1")
            {
                trMonthlySalary.Visible = true;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                trMonthlySalary.Visible = false;
                trHourlyPay.Visible = true;
                trHoursWorked.Visible = true;
            }


        }
    }
}