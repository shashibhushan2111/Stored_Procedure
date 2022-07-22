using Stored_Procedure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Stored_Procedure.Models
{
    public class StudentDataAccessLayer
    {
        string connectionstring = "server=(localdb)\\ProjectModels;Database=StudentDB;trusted_connection=true";

        //method for Selecting all record.
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> Liststudents = new List<Student>();
            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("stpALLstudentData",connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(); 
                while(reader.Read())
                {
                    Student students = new Student();
                    students.ID = (int)Convert.ToInt64(reader["ID"]);
                    students.Fname = reader["Fname"].ToString();
                    students.Lname = reader["Lname"].ToString() ;
                    students.Div = reader["Div"].ToString();
                    Liststudents.Add(students); 
                }
                connection.Close();
            }

            return Liststudents;
        }
        //method for inserting the record.
        public void AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("stpInsertStudent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Fname", student.Fname);
                command.Parameters.AddWithValue("@lname", student.Lname);
                command.Parameters.AddWithValue("@Div", student.Div);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            
        }

        //method for updating the student record.
        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("stpUpdateStudent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", student.ID);
                command.Parameters.AddWithValue("@Fname", student.Fname);
                command.Parameters.AddWithValue("@lname", student.Lname);
                command.Parameters.AddWithValue("@Div", student.Div);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        //method for showing the student details.
        public Student DetailsOfStudent(int? id)
        {
            Student student = new Student();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("stpSelectStudentByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ID", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.ID = (int)Convert.ToInt64(reader["ID"]);
                    student.Fname = reader["Fname"].ToString();
                    student.Lname = reader["Lname"].ToString();
                    student.Div = reader["Div"].ToString();
                }
                connection.Close();
            }
            return student;
        }
        //method for Deleting the record
        public void DeleteStudent(int? id)
        {
            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("stpDeleteStudent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
