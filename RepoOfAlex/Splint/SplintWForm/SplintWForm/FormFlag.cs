using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplintWForm
{
    public partial class FormFlag : Form
    {
        
        public FormFlag()
        {
            InitializeComponent();
            

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormFlag_Shown(object sender, EventArgs e)
        {
          

            
        }
        private void addListViewItem(string name, string des)
        {
            

           
           
        }

        private void listView1_Click(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public string getFlagCommand()
        {
            string command = "";
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                for (int j = 0; j < this.treeView1.Nodes[i].Nodes.Count; j++)
                {
                    if (this.treeView1.Nodes[i].Nodes[j].Checked == true)
                    {
                        command += " ";
                        command += this.treeView1.Nodes[i].Nodes[j].Text;
                        command += " ";
                    }
                }
            }
            command += " " + TB_userDefine.Text + " ";
            return command;
        }

        private void FormFlag_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                this.treeView1.Nodes[i].Checked = true;
                for (int j = 0; j < this.treeView1.Nodes[i].Nodes.Count; j++)
                {
                    this.treeView1.Nodes[i].Nodes[j].Checked = true;
                   
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                this.treeView1.Nodes[i].Checked = false;
                for (int j = 0; j < this.treeView1.Nodes[i].Nodes.Count; j++)
                {
                    this.treeView1.Nodes[i].Nodes[j].Checked = false;

                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode tempNode = e.Node;
            if (tempNode.Checked == true)
            {
                for (int i = 0; i < tempNode.Nodes.Count; i++)
                {
                    tempNode.Nodes[i].Checked = true;
                }
            }
            if (tempNode.Checked == false)
            {
                for (int i = 0; i < tempNode.Nodes.Count; i++)
                {
                    tempNode.Nodes[i].Checked = false;
                }
            }
        }
    }
}
