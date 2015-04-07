using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    /// <summary>
    /// ExecuteReader, ExecuteNonQuery, ExecuteScalar
    /// </summary>
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                   //查詢
                    cmd.CommandText = "select * from Studentdata where StudentName like @name";
                    cmd.Parameters.Add(new SqlParameter("@name", "%" + txtSearch.Text + "%"));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        gvResult.DataSource = dt;
                        gvResult.DataBind();
                        dr.Close();
                    }
                }
            }
        }

        //ExecuteScalar
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //新增語法
            string sql = @"INSERT INTO [dbo].[Studentdata]([StudentName],[StudentPhone],[StudentAddress])
                             VALUES
                               (@Name
                               ,@Phone
                               ,@Address);SELECT CAST(scope_identity() AS int);";
            //連資料庫語法
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    //新增資料對應資料庫欄位
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@Name", txtName.Text));
                    cmd.Parameters.Add(new SqlParameter("@Phone", txtPhone.Text));
                    cmd.Parameters.Add(new SqlParameter("@Address", TextAddress.Text));

                    txtID.Text = cmd.ExecuteScalar().ToString();
                }
                //新增完 重新搜尋(動態更新效果)
                btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //修改
            string sql = @"update [Studentdata] set [StudentName] = @Name, [StudentPhone] = @Phone, [StudentAddress] = @Address
                             where StudentId = @ID";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@ID", txtE_ID.Text));
                    cmd.Parameters.Add(new SqlParameter("@Name", txtE_Name.Text));
                    cmd.Parameters.Add(new SqlParameter("@Phone", txtE_Phone.Text));
                    cmd.Parameters.Add(new SqlParameter("@Address", txtE_Address.Text));

                    cmd.ExecuteNonQuery();
                }
                btnSearch_Click(null, null);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString);
            //刪除
            string sqlStatement = "DELETE FROM Studentdata WHERE StudentId = @StudentId";

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                cmd.Parameters.AddWithValue("@StudentId", txtD_ID.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            finally
            {
                connection.Close();
                btnSearch_Click(null, null);
            }
        }
    }
}