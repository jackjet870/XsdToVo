using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XsdToVo.Vo;

namespace XsdToVo.Method
{
    public class AnalysisXsd
    {
        #region 字段和属性      

        XmlDocument _document;
        private List<AnalysisVo> voList = new List<AnalysisVo>();
        /// <summary>
        /// 实体类列表
        /// </summary>
        public List<AnalysisVo> VoList
        {
            get
            {
                return voList;
            }

            set
            {
                voList = value;
            }
        }
        #endregion

        public AnalysisXsd(string xsdpath)
        {
            LoadXSD loadXsd = new LoadXSD(xsdpath);
            _document = loadXsd.Document;
        }
        /// <summary>
        /// 解析载入的VO文件
        /// </summary>
        public void Analysis()
        {
            XmlElement rootElement = _document.DocumentElement;//获取根节点
            XmlNodeList complexTypeNodes = rootElement.GetElementsByTagName(ConstField.ComplexType);//获取complexType子节点集合
            foreach (XmlNode complexTypeNode in complexTypeNodes)
            {
                AnalysisVo vo = new AnalysisVo();

                XmlElement voElement = (XmlElement)complexTypeNode;
                string nameVo = voElement.GetAttribute("name");//获取类的名字
                string noteVo = voElement.FirstChild.InnerText;//获取类的注释

                List<AnalysisVo> childrenList = new List<AnalysisVo>();

                XmlNodeList elementNodes = voElement.GetElementsByTagName(ConstField.Element);//获取element子节点集合
                foreach (XmlNode elementNode in elementNodes)
                {
                    AnalysisVo childVo = new AnalysisVo();

                    XmlElement fieldElement = (XmlElement)elementNode;
                    string nameField = fieldElement.GetAttribute("name");//获取字段名字
                    string typeField = fieldElement.GetAttribute("type");//获取字段类型
                    string noteField = ""; //获取字段注释
                    if(fieldElement.FirstChild!=null)
                        noteField= fieldElement.FirstChild.InnerText;
                    childVo.Name = nameField;
                    childVo.Type = typeField;
                    childVo.Note = noteField;

                    childrenList.Add(childVo);
                }

                vo.Name = nameVo;
                vo.Note = noteVo;
                vo.Children = childrenList;

                VoList.Add(vo);
            }         
        }        
    }
}
