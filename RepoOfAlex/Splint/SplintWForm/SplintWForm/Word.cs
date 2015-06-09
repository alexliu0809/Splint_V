using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplintWForm
{
    class Word
    {
        /// <summary>
        /// 实现导出word
        /// </summary>
        /// <param name="Data">要存储的数据</param>
        /// <param name="NewFileAddress">目的文件绝对路径。eg:J:////4.1.dot</param>
        /// <param name="TemplateAddress"></param>
        /// <returns></returns>
        public static int StoreWord(string name, int banbenhao, Data[] data, int cuowuleixingshumu, int dengji, string NewFileAddress, string TemplateAddress)
        {
            object oMissing = System.Reflection.Missing.Value;
            //创建一个Word应用程序实例
            Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
            //设置为不可见
            oWord.Visible = false;
            //模板文件地址，这里假设在X盘根目录
            //       object oTemplate = "J://学习//大三下//软件体系结构和设计模式//code//11.dot";
            object oTemplate = TemplateAddress;
            //以模板为基础生成文档
            Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
            //声明书签数组
            object[] oBookMark = new object[11];
            //赋值书签名
            oBookMark[0] = "wenjianming";
            oBookMark[1] = "banbenhao";
            oBookMark[2] = "wentidengji";
            oBookMark[3] = "weizhi";
            oBookMark[4] = "wentimiaoshu";
            oBookMark[5] = "yinxiangfenxi";
            oBookMark[6] = "chulijieguo";
            oBookMark[7] = "baogaoren";
            oBookMark[8] = "baogaoriqi";
            oBookMark[9] = "kaifafang";
            oBookMark[10] = "ceshifang";
            //赋值任意数据到书签的位置
            oDoc.Bookmarks.get_Item(ref oBookMark[0]).Range.Text = name;
            oDoc.Bookmarks.get_Item(ref oBookMark[1]).Range.Text = banbenhao.ToString();
            oDoc.Bookmarks.get_Item(ref oBookMark[2]).Range.Text = dengji.ToString();
            oDoc.Bookmarks.get_Item(ref oBookMark[3]).Range.Text = name;

            string temp = "";
            for (int i = 0; i < cuowuleixingshumu; i++)
            {
                temp += "错误名称：";
                temp += data[i].name + "   ";
                temp += "错误数量：";
                temp += data[i].num.ToString();
                temp += "\n";
            }
            string a = "我是第一行\r\n" + "我是第二行";
            oDoc.Bookmarks.get_Item(ref oBookMark[4]).Range.Text = temp;
            if (cuowuleixingshumu == 0)
                oDoc.Bookmarks.get_Item(ref oBookMark[5]).Range.Text = "无错误，影响良好";
            else oDoc.Bookmarks.get_Item(ref oBookMark[5]).Range.Text = "有错误，请及时修改";
            oDoc.Bookmarks.get_Item(ref oBookMark[6]).Range.Text = "";
            oDoc.Bookmarks.get_Item(ref oBookMark[7]).Range.Text = "admin";
            oDoc.Bookmarks.get_Item(ref oBookMark[8]).Range.Text = DateTime.Now.ToString();
            oDoc.Bookmarks.get_Item(ref oBookMark[9]).Range.Text = "admin";
            oDoc.Bookmarks.get_Item(ref oBookMark[10]).Range.Text = "admin";

            //弹出保存文件对话框，保存生成的Word


            {
                // object filename = "J://学习//大三下//软件体系结构和设计模式//code//新导入.dot";
                object filename = NewFileAddress;
                oDoc.SaveAs(ref filename, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);
                oDoc.Close(ref oMissing, ref oMissing, ref oMissing);
                //关闭word
                oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
            }
            return 1;
        }
    }
}
