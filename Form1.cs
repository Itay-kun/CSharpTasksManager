using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;
        private void ToDoList_Load(object sender, EventArgs e)
        {
            // Create columns
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            todoList.Columns.Add("Start Date");
            todoList.Columns.Add("Due By");

            // Point our datagridview to our datasource
            toDoListView.DataSource = todoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextbox.Text = "";
            startDatePicker.Text = "";
            dueByPicker.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // Fill text fields with data from table
            titleTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextbox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
            startDatePicker.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[2].ToString();
            dueByPicker.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[3].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextbox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Start Date"] = startDatePicker.Value.ToString();
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Due By"] = dueByPicker.Value.ToString();
            }
            else
            {
                todoList.Rows.Add(titleTextBox.Text, descriptionTextbox.Text, startDatePicker.Text, dueByPicker.Text);
            }
            // Clear fields
            titleTextBox.Text = "";
            descriptionTextbox.Text = "";
            isEditing = false;

            ToDoItem myTask = new ToDoItem(
                title: titleTextBox.Text,
                description: descriptionTextbox.Text,
                parentTaskKey: "",
                startDate: startDatePicker.Value,
                endDate: dueByPicker.Value
            );

            Console.WriteLine( myTask.ToString() );
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
