using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XsdToVo.Method
{
    public class LoadXSD
    {
        XmlDocument _document;

        public XmlDocument Document
        {
            get
            {
                return _document;
            }

            set
            {
                _document = value;
            }
        }

        public LoadXSD(string xsdpath)
        {
            if (string.IsNullOrEmpty(xsdpath))
            {
                throw new ArgumentException(".xsd文件路径不能为空！");
            }
            if (Document == null)
            {
                Document = new XmlDocument();
            }
            Document.Load(xsdpath);
        }
    }
}
