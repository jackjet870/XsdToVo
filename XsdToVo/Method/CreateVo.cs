using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XsdToVo.Vo;

namespace XsdToVo.Method
{
    public class CreateVo
    {
        //不含通知机制
        private static string pathVo1 = @"Dis/VoWithoutNotify";
        //包含通知机制
        private static string pathVo2 = @"Dis/VoWithNotify";
        //通知类文件
        private static string path = @"Dis";

        public static string PathVo1
        {
            get
            {
                return pathVo1;
            }

            set
            {
                pathVo1 = value;
            }
        }

        public static string PathVo2
        {
            get
            {
                return pathVo2;
            }

            set
            {
                pathVo2 = value;
            }
        }

        /// <summary>
        /// 判断是否存在文件夹，不存在则创建
        /// </summary>
        /// <returns></returns>
        public static bool CreateDirectory()
        {
            if (!Directory.Exists(PathVo1))
            {
                Directory.CreateDirectory(PathVo1);
            }
            if (!Directory.Exists(PathVo2))
            {
                Directory.CreateDirectory(PathVo2);
            }

            if (Directory.Exists(PathVo1) && Directory.Exists(PathVo2))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 生成通知类文件
        /// </summary>
        /// <param name="NameSpace"></param>
        public static void CreateRaisePropertyChangedCS(string NameSpace)
        {
            try
            {
                FileStream fs = new FileStream(path + "/ObjectNotifyPropertyChanged.cs", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(CreateRaisePropertyChanged(NameSpace));
                sw.Flush();
                sw.Close();
                fs.Close();
                MessageBox.Show("ObjectNotifyPropertyChanged.cs文件生成成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 生成不含通知机制的VO
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <param name="list">列表</param>
        public static void CreateVoNoINotifyPropertyChanged(string NameSpace, List<AnalysisVo> list)
        {
            try
            {
                foreach (var vo in list)
                {
                    FileStream fs = new FileStream(PathVo1 + "/" + vo.Name + ".cs", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(CreateCS(NameSpace, vo.Name, vo.Note, vo.Children, 1));
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                MessageBox.Show(".cs文件生成成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// 生成包含通知机制的VO
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <param name="name">文件名</param>
        /// <param name="listName">列表</param>
        public static void CreateVoWithINotifyPropertyChanged(string NameSpace, List<AnalysisVo> list)
        {
            try
            {
                foreach (var vo in list)
                {
                    FileStream fs = new FileStream(PathVo2 + "/" + vo.Name + ".cs", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(CreateCS(NameSpace, vo.Name, vo.Note, vo.Children, 0));
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                MessageBox.Show(".cs文件生成成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// 创建CS实体类文件
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <param name="name">类名称</param>
        /// <param name="list">列表</param>
        /// <param name="type">0：生成带通知机制；1：生成不带通知机制</param>
        /// <returns></returns>
        private static string CreateCS(string NameSpace, string name, string note, List<AnalysisVo> list, int type)
        {
            string content = "";
            content += "using System;\r\n";
            content += "using System.Collections.Generic;\r\n";
            content += "using System.Linq;\r\n";
            content += "using System.Text;\r\n";
            content += "\r\n";
            content += "namespace " + "" + NameSpace + "" + "\r\n";
            content += "{\r\n";
            content += "    /// <summary>\r\n";
            content += "    ///" + note + "\r\n";
            content += "    /// <summary>\r\n";
            if (type == 0)
            {
                content += "    public class " + "" + name + "" + ":ObjectNotifyPropertyChanged" + "\r\n";
            }
            else
            {
                content += "    public class " + "" + name + "" + "\r\n";
            }
            content += "    {\r\n";
            foreach (AnalysisVo s in list)
            {
                if (s.Name.Length > 4 && (s.Name.Substring(s.Name.Length - 4, 4).Equals("Grid") || s.Name.Substring(s.Name.Length - 4, 4).Equals("List")))
                    content = CreateFieldList(type, content, s);
                else
                    content = CreateFieldOrdinary(type, content, s);
            }
            content += "    }\r\n";
            content += "}\r\n";
            return content;
        }
        /// <summary>
        /// 不包含List
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string CreateFieldOrdinary(int type, string content, AnalysisVo s)
        {
            content += "        private " + "" + s.Type + " _" + s.Name + ";" + "\r\n";
            content += "        /// <summary>\r\n";
            content += "        /// " + s.Note + "\r\n";
            content += "        /// </summary>\r\n";
            content += "        public " + "" + s.Type + " " + s.Name.Substring(0, 1).ToUpper() + s.Name.Substring(1, s.Name.Length - 1) + "\r\n";
            content += "        {\r\n";
            content += "            get\r\n";
            content += "            {\r\n";
            content += "                return _" + s.Name + ";\r\n";
            content += "            }\r\n";
            content += "\r\n";
            content += "            set\r\n";
            content += "            {\r\n";
            content += "                _" + s.Name + " = value;\r\n";
            if (type == 0)
            {
                content += "                RaisePropertyChanged(\"" + s.Name.Substring(0, 1).ToUpper() + s.Name.Substring(1, s.Name.Length - 1) + "\");\r\n";
            }
            content += "            }\r\n";
            content += "        }\r\n";
            content += "\r\n";
            return content;
        }
        /// <summary>
        /// 包含List
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string CreateFieldList(int type, string content, AnalysisVo s)
        {
            content += "        private " + "List<" + "" + s.Type + "> _" + s.Name + " = new List<" + s.Type + ">()" + ";" + "\r\n";
            content += "        /// <summary>\r\n";
            content += "        /// " + s.Note + "\r\n";
            content += "        /// </summary>\r\n";
            content += "        public " + "List<" + "" + s.Type + "> " + s.Name.Substring(0, 1).ToUpper() + s.Name.Substring(1, s.Name.Length - 1) + "\r\n";
            content += "        {\r\n";
            content += "            get\r\n";
            content += "            {\r\n";
            content += "                return _" + s.Name + ";\r\n";
            content += "            }\r\n";
            content += "\r\n";
            content += "            set\r\n";
            content += "            {\r\n";
            content += "                _" + s.Name + " = value;\r\n";
            if (type == 0)
            {
                content += "                RaisePropertyChanged(\"" + s.Name.Substring(0, 1).ToUpper() + s.Name.Substring(1, s.Name.Length - 1) + "\");\r\n";
            }
            content += "            }\r\n";
            content += "        }\r\n";
            content += "\r\n";
            return content;
        }
        /// <summary>
        /// 创建通知类文件
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <returns></returns>
        private static string CreateRaisePropertyChanged(string NameSpace)
        {
            string content = "";
            content += "using System;\r\n";
            content += "using System.Collections.Generic;\r\n";
            content += "using System.Linq;\r\n";
            content += "using System.Text;\r\n";
            content += "using System.ComponentModel;\r\n";
            content += "\r\n";
            content += "namespace " + "" + NameSpace + "" + "\r\n";
            content += "{\r\n";
            content += "    public class ObjectNotifyPropertyChanged:INotifyPropertyChanged\r\n";
            content += "    {\r\n";
            content += "        public event PropertyChangedEventHandler PropertyChanged;\r\n";
            content += "        public void RaisePropertyChanged(string propertyName)\r\n";
            content += "        {\r\n";
            content += "            if (PropertyChanged != null)\r\n";
            content += "            {\r\n";
            content += "                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));\r\n";
            content += "            }\r\n";
            content += "        }\r\n";
            content += "    }\r\n";
            content += "}\r\n";
            return content;
        }
    }
}
