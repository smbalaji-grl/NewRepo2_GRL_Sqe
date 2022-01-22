namespace BlazorApp3
{
    using System.Xml;
    public class SupportedUUT
    {
        private string location;
        private string leftkey;
        private string rightValue;

        public SupportedUUT(string folder, string key, string unidentified)
        {
            location = folder;
            leftkey = key.Trim();
            rightValue = unidentified.Trim();
        }
        public string modifyValue()
        {     
            bool parsedValue;         
            if (bool.TryParse(this.rightValue, out parsedValue))
            {
                if (this.rightValue.Equals("true") || this.rightValue.Equals("True"))
                {
                    return this.rightValue = "true";
                }
                else if (this.rightValue.Equals("false") || this.rightValue.Equals("False"))
                {
                    return this.rightValue = "false";
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return this.rightValue;
            }
        }
        public List<string> readFileAndsendList(string val)
        {
            List<string> fileNames = new();
            if (Directory.Exists(location))
            {
                string[] allFiles = Directory.GetFiles(location, "*xml");

                XmlDocument doc = new XmlDocument();


                string gotVal;

                foreach (string file in allFiles)
                {
                    doc.Load(file);

                    XmlNodeReader rdr = new XmlNodeReader(doc);

                    while (rdr.Read())
                    {
                        if (rdr.NodeType == XmlNodeType.Element)
                        {
                            if (rdr.LocalName.Equals(this.leftkey))
                            {
                                gotVal = rdr.GetAttribute("value");

                                if (gotVal.Equals(val))
                                {
                                    fileNames.Add(Path.GetFileName(file));
                                    break;
                                }
                            }
                        }
                    }
                }
                return fileNames;

            }
            else
            {
                return null;
            }
        }
    }
}
           