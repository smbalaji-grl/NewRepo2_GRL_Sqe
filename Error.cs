namespace BlazorApp3
{
    public class Error
    {

        private string path;
        private string keyword;
        private int count;

        public Error(string location, string key, int repeatcount)
        {
            this.path = location;
            this.keyword = key;
            this.count = repeatcount;
        }
        override
       public String ToString()
        {
            return "Path(" + this.path + ")\n" + ", " + "key(" + this.keyword + ")" + ", " + "count(" + this.count + ")";
        }


    }
}
