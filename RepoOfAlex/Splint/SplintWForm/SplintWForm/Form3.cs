using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SplintWForm
{
    
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int num2 = 0;
        private void 文件名ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
        int []aa=new int[2];
        int flag44=0;
        int flag45 = 0;
        public List<DataAll> name4 = new List<DataAll>(); //初始化文件名和id对应的数组
        private void 版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a1 = 2, a2 = 5, a3 = 4, a4 = 7;
            int a = 10, b = 20, c = 30, d = 40;
            int haha = 0;
            num2 = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                    if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                    {
                        ++num2;
                        //index1 = i;
                    }
            }
            if (num2 == 2)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                        if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                        {
                            //++num2;
                            aa[haha]=i;
                            haha++;
                        }
                }
                name4 = GetAll();
                int flag1 = 0;
                int flag2 = 0;
                for (int i = 0; i < name4.Count; i++)
                {
                    if(flag1==0)
                    if (name4[i].wenjianming.ToString() == dataGridView1.Rows[aa[0]].Cells[1].Value.ToString() && name4[i].banbenhao.ToString() == dataGridView1.Rows[aa[0]].Cells[2].Value.ToString())
                    {
                        a = name4[i].dengji;
                        a1 = a;
                        flag1 = 1;
                    }
                    if (flag2 == 0)
                        if (name4[i].wenjianming.ToString() == dataGridView1.Rows[aa[1]].Cells[1].Value.ToString() && name4[i].banbenhao.ToString() == dataGridView1.Rows[aa[1]].Cells[2].Value.ToString())
                        {
                            b = name4[i].dengji;
                            a2 = b;
                            flag2 = 1;
                        }
                    if (flag1 == 1 && flag2 == 1)
                    {
                        break;
                    }

                }
           

                List<int> x = new List<int>();
                List<int> y = new List<int>();
                List<string> xData = new List<string>() { "第一个版本", "第二个版本" };

                List<int> yData = new List<int>() { a, b };
                chart2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
                chart2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
                chart2.Series[0].Points.DataBindXY(xData, yData);

                if(flag44==0)
                for (int i = 0; i < 1; i++)
                {
                    x.Add(i+1);
                    y.Add(i+1);
                    flag44 = 2;
                }
                if (flag45 == 0)
                {
                    this.chart1.Series[0].Points.Clear();
                    this.chart1.Series[0].Points.AddXY(0, a1);
                    this.chart1.Series[0].Points.AddXY(1, a2);
                    flag45 = 1;
                }
                // this.chart1.Series[0].Points.AddXY(2, a3);
                // this.chart1.Series[0].Points.AddXY(3, a4);
            }
            else {
                MessageBox.Show("请选择2个版本进行对比");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewCheckBoxColumn c1 = new DataGridViewCheckBoxColumn(); this.dataGridView1.Columns.Add(c1);
        }
        public List<DataIdName> name2 = new List<DataIdName>(); //初始化文件名和id对应的数组
        public List<DataAll> name3 = new List<DataAll>(); //初始化文件名和id对应的数组

        public List<DataIdName> GetIdName()
        {

            List<DataIdName> ppp = new List<DataIdName>();
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
                DataTable dt = new DataTable();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select distinct wenjianming,banbenhao,dengji from Splint.dbo.Result";
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

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataIdName temp;
                    temp = new DataIdName(dt.Rows[i][0].ToString(), (int)dt.Rows[i][1], (int)dt.Rows[i][2]);
                    ppp.Add(temp);
                }
                reader.Close();     //关闭执行
                conn.Close();//关闭数据库
            }
            return ppp;
        }
/*
        public List<DataAll> GetAll() //还有这个也是我用来测试写的--亚航
        {
            List<DataAll> name1 = new List<DataAll>(); //初始化文件名和id对应的数组
            name1.Add(new DataAll("this1", 1,15,25,"error1",3, 1));
            name1.Add(new DataAll("this1", 1, 35, 45, "error2", 6, 2));
            name1.Add(new DataAll("this1", 2, 55, 65, "error3", 1, 3));
            name1.Add(new DataAll("this1", 3, 75, 85, "error4", 5, 4));
            name1.Add(new DataAll("this1", 4, 51, 52, "error1", 3, 5));
            name1.Add(new DataAll("this1", 5, 53, 54, "error1", 3, 6));
            name1.Add(new DataAll("this2",1, 55, 56, "error12", 3, 7));
            name1.Add(new DataAll("this2", 2, 57, 58, "error13", 5, 8));
            name1.Add(new DataAll("this2", 3, 59, 60, "error113", 5, 9));
            name1.Add(new DataAll("this2", 4, 11, 12, "error113", 5, 10));
            name1.Add(new DataAll("this3", 1, 13, 14, "error131", 3, 11));
            return name1;
        }*/

        public List<DataAll> GetAll()
        {
            List<DataAll> ppp = new List<DataAll>();

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
                DataTable dt = new DataTable();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select * from Splint.dbo.Result";
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

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataAll temp;
                    temp = new DataAll(dt.Rows[i][0].ToString(), (int)dt.Rows[i][1], (int)dt.Rows[i][2],
                        (int)dt.Rows[i][3], dt.Rows[i][4].ToString(), (int)dt.Rows[i][5], (int)dt.Rows[i][6]);
                    ppp.Add(temp);
                }
                reader.Close();     //关闭执行
                conn.Close();//关闭数据库
            }
            return ppp;
        }

        /// <summary>
        /// /////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ////////////////////////
        //public List<DataIdName> name2 = new List<DataIdName>(); //初始化文件名和id对应的数组
        //public List<DataAll> name3 = new List<DataAll>(); //初始化文件名和id对应的数组
        public List<DataIdName> GetIdName1() //我把这个函数自己写了一下，然后初始化了一些测试用的数据，拼接的时候灵活删除即可--亚航
        {
            List<DataIdName> name1 = new List<DataIdName>(); //初始化文件名和id对应的数组
            name1.Add(new DataIdName("this1", 1, 1));
            name1.Add(new DataIdName("this1", 2, 1));
            name1.Add(new DataIdName("this1", 3, 1));
            name1.Add(new DataIdName("this1", 4, 1));
            name1.Add(new DataIdName("this1", 5, 1));
            name1.Add(new DataIdName("this2", 1, 1));
            name1.Add(new DataIdName("this2", 2, 1));
            name1.Add(new DataIdName("this2", 3, 1));
            name1.Add(new DataIdName("this2", 4, 1));
            name1.Add(new DataIdName("this3", 1, 1));
            return name1;
        }
        public List<DataAll> GetAll1() //还有这个也是我用来测试写的--亚航
        {
            List<DataAll> name1 = new List<DataAll>(); //初始化文件名和id对应的数组
            name1.Add(new DataAll("this1", 1, 15, 25, "error1", 3, 1));
            name1.Add(new DataAll("this1", 1, 35, 45, "error2", 6, 2));
            name1.Add(new DataAll("this1", 2, 55, 65, "error3", 1, 3));
            name1.Add(new DataAll("this1", 3, 75, 85, "error4", 5, 4));
            name1.Add(new DataAll("this1", 4, 51, 52, "error1", 3, 5));
            name1.Add(new DataAll("this1", 5, 53, 54, "error1", 3, 6));
            name1.Add(new DataAll("this2", 1, 55, 56, "error12", 3, 7));
            name1.Add(new DataAll("this2", 2, 57, 58, "error13", 5, 8));
            name1.Add(new DataAll("this2", 3, 59, 60, "error113", 5, 9));
            name1.Add(new DataAll("this2", 4, 11, 12, "error113", 5, 10));
            name1.Add(new DataAll("this3", 1, 13, 14, "error131", 3, 11));
            return name1;
        }
        /// /////////////////////////////
      
        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //显示内容
            string s1=null;
            int s2 = 0;
            string s3 = null;
            num2 = 0;
            int index1 = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value !=null )
                    if((bool)dataGridView1.Rows[i].Cells[0].Value==true)
                {
                    ++num2;
                    index1 = i;
                }
            }
            
            if (num2>1)
            {
                MessageBox.Show("提示：请勿勾选多个版本，请重新选择一个版本");
            }
            else if (num2 == 1)
            {
                MessageBox.Show("你正在查看该历史版本");
                s1 = dataGridView1.Rows[index1].Cells[1].Value.ToString();
                s3 = dataGridView1.Rows[index1].Cells[2].Value.ToString();
                s2 = Int32.Parse(s3);
                int shy = 0;
                int flag = 0;
                name3 = GetAll();
                List<DataAll> newList = new List<DataAll>();
                for (int i = 0; i < name3.Count; i++)
                {
                    if (name3[i].wenjianming == s1 && name3[i].banbenhao.ToString() == s3)
                    {
                        //dataSet2
                        newList.Add(name3[i]);
                        //dataSet2.Tables.Add(name3[i].错误类型名称.ToString(), name3[i].错误类型数目.ToString());
                        shy = i;
                        flag = 1;
                    }
                }
                dataGridView2.DataSource = newList;

                if (flag == 1)
                {
                    textBox1.Text = name3[shy].cuowuleixingshumu.ToString();
                    textBox2.Text = name3[shy].cuowuzongshu.ToString();
                    dataGridView2.Columns[0].Width = 300;
                    dataGridView2.Columns[1].Width = 300;
                }
                else
                {
                    int aaa = 0;
                    textBox1.Text = aaa.ToString();
                    textBox2.Text = aaa.ToString();
                }
            }
        }


        DataTable s1 = new DataTable();

        private void Form3_Load(object sender, EventArgs e)
        {
            //实例代码
            name2 = GetIdName();
            for (int i = 0; i <= name2.Count - 1; i++)
            {
                //dataGridView1.DataSource.ToString();
                dataSet1.Tables.Add(name2[i].文件名.ToString(),name2[i].版本ID.ToString());
                //s1.GetObjectData(name2[i].name,name2[i].id);
            }
            
            dataGridView1.DataSource=name2;
            dataGridView1.Columns[0].Width=40;
            dataGridView1.Columns[1].Width = 208;
            dataGridView1.Columns[2].Width = 208;
            //dataGridView1.Show();
            
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            flag44 = 0;
            flag45 = 0;
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
    public class DataIdName
    {
        int num; //返回数组的大小
        private string name;
        public string 文件名
        {
            set { name = value; }
            get { return name; }
        }
        public int id;
        public int 版本ID
        {
            set { id = value; }
            get { return id; }
        }
       /* {
            set { id = value; }
            get { return id; }
        }*/
        public int dengji; //错误等级
        public DataIdName(string name, int num, int dengji)
        {
            this.name = name;
            this.id = num;
            this.dengji = dengji;
        }
    }
    public class DataAll
    {
        int num; //返回数组的大小
        public string wenjianming; //文件名
        public int banbenhao;  //版本号
        public int cuowuzongshu;  //错误总数
        public int cuowuleixingshumu;   //错误类型种类数目
        public string resultname;   //错误的名称
        public string 错误类型名称
        {
            set { resultname = value; }
            get { return resultname; }
        }
        public int resultnum;       //对应错误的数目
        public int 错误类型数目
        {
            set { resultnum = value; }
            get { return resultnum; }
        }
        public int dengji;              //错误等级
        private void set()
        {
 
        }
        public DataAll(string wenjianming, int banbenhao, int cuowuzongshu, int cuowuleixingshumu, string resultname, int resultnum, int dengji)
        {
            this.wenjianming = wenjianming;
            this.banbenhao = banbenhao;
            this.cuowuzongshu = cuowuzongshu;
            this.cuowuleixingshumu = cuowuleixingshumu;
            this.resultname = resultname;
            this.resultnum = resultnum;
            this.dengji = dengji;
        }
    }
    //数据类
}
