namespace BlazorApp3
{

    public class TextFinder
    {
        public string location;
        public string key;
        // public List<string> txtFiles;
        private Dictionary<int, Error> textDictionary;

        public TextFinder(string directiory, string text)
        {
            this.location = directiory;
            this.key = text;
            //location = directiory;
            //key = text;
        }
        public List<string> getDebugLoggerFiles()
        {
            //string filep = ErrorCounter.location;
            //if (Directory.Exists(location))
            string strTemp = "temp1";
            //string strTemp2 = 'temp2';

            if (Directory.Exists(this.location))
            {
                var allfiles = Directory.EnumerateFiles(location, "*.log", SearchOption.AllDirectories);// this method will check each every folder for .type document
                //string[] allfiles = System.IO. Directory.GetFiles(this.location,"*.txt");// willonly take particular folder for mentioned doc
                if (allfiles == null)
                {
                    Console.WriteLine("no Debuglogger file is exists");
                    return null;

                }
                else
                {
                    List<string> txtFiles = new List<string>();
                    foreach (string files in allfiles)
                    {
                        txtFiles.Add(files);
                    }
                    return txtFiles;
                }
            }
            else
            {
                Console.WriteLine("path doesn't exists");
                return null;
            }

        }
        public Dictionary<int, Error> searchKeyWord(List<string> txtFiles)
        {
            if (!(txtFiles == null))
            {
                int count = 0;
                int slno = 0;
                this.textDictionary = new Dictionary<int, Error>();
                foreach (string folder in txtFiles)
                {

                    foreach (string lines in System.IO.File.ReadLines(folder))
                    {
                        if (lines.Contains(this.key))
                        {
                            string[] oneline = new string[lines.Length];
                            oneline = lines.Split(this.key);
                            count += oneline.Length;
                        }
                    }
                    Error result = new Error(folder, this.key, count);
                    if (result != null)
                    {
                        textDictionary.Add(slno++, result);
                    }
                    count = 0;
                }
                return textDictionary;
            }
            else
            {
                // Console.WriteLine("folder is not exists");
                return null;
            }

        }
        
        
    }
}
