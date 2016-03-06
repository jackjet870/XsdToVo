using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XsdToVo.Vo;

namespace XsdToVo.Method
{
    public class AnalysisBaseType
    {
        #region 字段和属性
        XmlDocument _document;
        private Dictionary<string, string> dicType = new Dictionary<string, string>();
        /// <summary>
        /// 键值对，《字段，类型》
        /// </summary>
        public Dictionary<string, string> DicType
        {
            get
            {
                return dicType;
            }

            set
            {
                dicType = value;
            }
        }
        #endregion

        public AnalysisBaseType(string xsdpath)
        {
            LoadXSD loadXsd = new LoadXSD(xsdpath);
            _document = loadXsd.Document;
        }
        /// <summary>
        /// 解析基础字段类型文件，生成键值对集合
        /// </summary>
        public void Analysis()
        {
            XmlElement rootElement = _document.DocumentElement;//获取根结点
            XmlNodeList simpleTypeNodes = rootElement.GetElementsByTagName(ConstField.SimpleType);//获取simpleType子节点集合
            foreach(XmlNode simpleTypeNode in simpleTypeNodes)
            {
                XmlElement dicElement = (XmlElement)simpleTypeNode;
                string dicKey = dicElement.GetAttribute("name");//获取类型名字
                string dicValue = ((XmlElement)dicElement.LastChild).GetAttribute("base");//获取类型内容
                dicValue = dicValue.Replace("xs:", "");
                DicType.Add(dicKey, dicValue);
            }
        }
    }
}
