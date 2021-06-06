using System;

namespace Todo_list_v5
{
    class Todo
    {
        public string title { get; set; }
        public string description { get; set; }


        public Todo(string t, string d)
        {
            this.title = t;
            this.description = d;
        }


        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string t)
        {
            this.title = t;
        }

        public string GetDesc()
        {
            return description;
        }
        public void SetDesc(string d)
        {
            this.description = d;
        }
    }
}
