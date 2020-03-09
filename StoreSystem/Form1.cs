using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLibrary;

namespace StoreSystem
{
    public partial class CustomerForm : Form
    {

        private DatabaseClass DatabaseClass { set; get; }

        private string FirstName { set; get; }

        private string MiddleName { set; get; }

        private string LastName { set; get; }

        private string City { set; get; }

        private string State { set; get; }

        private string Country { set; get; }

        private string PhoneNumber { set; get; }

        private string EmailAddress { set; get; }

        private string InsertStatement { set; get; }

        public CustomerForm()
        {

            InitializeComponent();

            this.DatabaseClass = new DatabaseClass("DevelopmentSystem");


        }

        private void CustomerSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {

                string msg = TextBoxValidation();

                if (msg.Length > 0)
                {

                    MessageBox.Show(msg, "Message from Customer Form", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    ConstructandExecuteInsertStatement();

                }

            }
            catch (Exception exc)
            {

                MessageBox.Show("There was an error processing customer. Please contact for IT Adminstrator for more help.\n\n" + exc.Message , "Message from Customer Form", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private string TextBoxValidation()
        {

            string errorMessage = string.Empty;

            if (FirstNameTextBox.Text.Length > 0 && FirstNameTextBox.Text != null)
            {

                this.FirstName = FirstNameTextBox.Text;


            }
            else
            {

                errorMessage = "Invalid entry for first name. Please enter a valid first name";

                FirstNameTextBox.Focus();

            }

            if (MiddleNameTextBox.Text != null)
            {
                this.MiddleName = MiddleNameTextBox.Text;
            }
            else
            {

                errorMessage = "Invalid entry for middle name. Please enter a valid middle name";

                MiddleNameTextBox.Focus();

            }

            if (LastNameTextBox.Text.Length > 0 && LastNameTextBox.Text != null)
            {
                this.LastName = LastNameTextBox.Text;
            }
            else
            {

                errorMessage = "Invalid entry for last name. Please enter a valid last name";

                LastNameTextBox.Focus();

            }

            if (CityTextBox.Text.Length > 0 && CityTextBox.Text != null)
            {
                this.City = CityTextBox.Text;
            }
            else
            {

                errorMessage = "Invalid entry for city. Please enter a valid city";

                CityTextBox.Focus();

            }

            if (StateTextBox.Text.Length > 0 && StateTextBox.Text != null)
            {
                this.State = StateTextBox.Text;
            }
            else
            {

                errorMessage = "Invalid entry for state. Please enter a valid state";

                StateTextBox.Focus();

            }

            if (CountryTextBox.Text.Length > 0 && CountryTextBox.Text != null)
            {
                this.Country = CountryTextBox.Text;
            }
            else
            {

                errorMessage = "Invalid entry for Country. Please enter a valid country";

                CountryTextBox.Focus();

            }

            if (PhoneNumberTextBox.Text.Length > 0 && PhoneNumberTextBox.Text != null)
            {
                this.PhoneNumber = PhoneNumberTextBox.Text;
            }
            else
            {

                errorMessage = "Invalid entry for phone number. Please enter a valid phone number";

                PhoneNumberTextBox.Focus();

            }

            if (EmailAddressTextBox.Text.Length > 0 && EmailAddressTextBox.Text != null)
            {
                this.EmailAddress = EmailAddressTextBox.Text;
            }
            else
            {

                errorMessage = "Invalid entry for email address. Please enter a valid email address";

                EmailAddressTextBox.Focus();

            }

            return errorMessage;

        }

        private void ConstructandExecuteInsertStatement()
        {

            int numberOfRows = 0;

            string message = string.Empty;

            this.InsertStatement = "INSERT INTO Customers (FirstName, MiddleName, LastName, CityBirthPlace, StateBirthPlace, CountryBirthPlace, PhoneNumber, EmailAddress) ";
            this.InsertStatement += "Values ('" + FirstNameTextBox.Text + "', '" + MiddleNameTextBox.Text + "', '" + LastNameTextBox.Text + "', '" + CityTextBox.Text + "', '"
                + StateTextBox.Text + "', '" +  CountryTextBox.Text + "', '" + PhoneNumberTextBox.Text + "', '" + EmailAddressTextBox.Text + "')";

            numberOfRows = this.DatabaseClass.InsertRow(this.InsertStatement);

            if (numberOfRows > 0)
            {
                MessageBox.Show("Customer was added successfully.", "Message from Customer Form", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearTextBoxes();

            }
            else
            {

                MessageBox.Show("Customer was not added successfully.", "Message from Customer Form", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void ClearTextBoxes()
        {

            foreach (Control c in this.Controls)
            {

                if (c.GetType() == typeof(TextBox))
                {

                    c.Text = string.Empty;

                }

            }

            this.FirstNameTextBox.Focus();

        }

    }

}
