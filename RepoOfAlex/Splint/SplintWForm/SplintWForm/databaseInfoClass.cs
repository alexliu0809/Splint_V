using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplintWForm
{
    public class Data
    {

        public string name;
        public int num;
        public Data()
        {
            
        }
        public Data(string name, int num)
        {
            this.name = name;
            this.num = num;
        }
        
    }
    public class databaseInfoClass
    {
       public int ver;//版本号
       public string fullPath;//地址，不区分文件和项目，有.exe就是文件，没有就是项目
       public int errorLevel;//错误分级，先计算好
       private List<Data> singleErrorList = new List<Data>();

       public Data[] getErrorArray()
       {
           Data[] temparray = new Data[singleErrorList.Count];
           for (int i = 0; i < singleErrorList.Count; i++)
           {
               temparray[i] = singleErrorList[i];
           }
           return temparray;
       }
       public void addList(Data[] a)
       {
           for (int i = 0; i < a.Length; i++)
           {
               singleErrorList.Add(a[i]);
           }
       }
    }
}
