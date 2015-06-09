using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace SplintWForm
{
    class DataBase
    {

        public static int storedata(string name, int banbenhao, Data[] data, int cuowuleixingshumu, int dengji)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=.;database=Splint;uid=123;pwd=123";
            using (conn)
            {
                conn.Open();
                /*
                SqlDataAdapter 对象。 用于填充DataSet （数据集）。
                SqlDataReader 对象。 从数据库中读取流..
                后面要做增删改查还需要用到 DataSet 对象。
                */
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                int sum = 0;
                for (int i = 0; i < cuowuleixingshumu; i++)
                {
                    sum += data[i].num;
                }
                string ttt = "0";
                if (cuowuleixingshumu == 0)
                {
                    comm.CommandText = " insert into Splint.dbo.Result values ('"
                    + name + "'," + banbenhao.ToString() + ","
                    + sum.ToString() + ","
                    + cuowuleixingshumu.ToString() + ","
                    + "'" + ttt + "',"
                    + ttt + ","
                    + dengji.ToString() +
                    ")";
                    SqlDataReader ddd = comm.ExecuteReader();  //执行sql
                    ddd.Close();     //关闭执行
                }

                for (int i = 0; i < cuowuleixingshumu; i++)
                {
                    comm.CommandText = " insert into Splint.dbo.Result values ('"
                    + name + "'," + banbenhao.ToString() + ","
                    + sum.ToString() + ","
                    + cuowuleixingshumu.ToString() + ","
                    + "'" + data[i].name + "',"
                    + data[i].num.ToString() + ","
                    + dengji.ToString() +
                    ")";
                    SqlDataReader ddd = comm.ExecuteReader();  //执行sql
                    ddd.Close();     //关闭执行
                }
                conn.Close();//关闭数据库
                return banbenhao;
            }


        }

        /// <summary>
        /// 返回对应文件的版本数目
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int BanbenOfWenjian(string name)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=.;database=Splint;uid=123;pwd=123";
            using (conn)
            {
                conn.Open();
                /*
                SqlDataAdapter 对象。 用于填充DataSet （数据集）。
                SqlDataReader 对象。 从数据库中读取流..
                后面要做增删改查还需要用到 DataSet 对象。
                */
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select distinct banbenhao from Splint.dbo.Result where wenjianming ="
                    + "'" + name + "'";
                //             SqlDataReader dr = comm.ExecuteReader();//执行SQL语句
                SqlDataReader reader = comm.ExecuteReader();

                for (int i = 0; i != reader.VisibleFieldCount; i++)//增加列信息
                {
                    dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                }
                DataRow dr;
                while (reader.Read())//读取行数据到DataTable中
                {
                    dr = dt.NewRow();
                    for (int i = 0; i != reader.VisibleFieldCount; i++)
                    {
                        dr[i] = reader.GetValue(i);
                    }
                    dt.Rows.Add(dr);
                }
                int ttt = (int)dt.Rows.Count;
                reader.Close();     //关闭执行
                conn.Close();//关闭数据库
                return ttt;
            }
        }


        /// <summary>
        /// 获取对应文件名和其对应版本的所有错误类型及对应数目
        /// </summary>
        /// <param name="name"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<Data> GetWrongTypeNum(string name, int num)
        {

            List<Data> ppp = new List<Data>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=.;database=Splint;uid=123;pwd=123";
            using (conn)
            {
                conn.Open();
                /*
                SqlDataAdapter 对象。 用于填充DataSet （数据集）。
                SqlDataReader 对象。 从数据库中读取流..
                后面要做增删改查还需要用到 DataSet 对象。
                */
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select * from Splint.dbo.Result where wenjianming = " +
                "'" + name + "' and banbenhao=" + num.ToString();
                //             SqlDataReader dr = comm.ExecuteReader();//执行SQL语句
                SqlDataReader reader = comm.ExecuteReader();

                for (int i = 0; i != reader.VisibleFieldCount; i++)//增加列信息
                {
                    dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                }
                DataRow dr;
                while (reader.Read())//读取行数据到DataTable中
                {
                    dr = dt.NewRow();
                    for (int i = 0; i != reader.VisibleFieldCount; i++)
                    {
                        dr[i] = reader.GetValue(i);
                    }
                    dt.Rows.Add(dr);
                }
                //         Console.WriteLine(dt.Columns.Count);   //数据库列数
                //          Console.WriteLine(dt.Rows.Count);      //数据库行数
                int number = (int)dt.Rows[0][3];

                for (int i = 0; i < number; i++)
                {
                    Data temp;
                    temp = new Data(dt.Rows[i][4].ToString(), (int)dt.Rows[i][5]);
                    ppp.Add(temp);
                }
                reader.Close();     //关闭执行
                conn.Close();//关闭数据库
            }
            return ppp;
        }


    }
}
