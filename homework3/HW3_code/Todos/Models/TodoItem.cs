using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Todos.Models
{
    class TodoItem
    {

        private string id;

        public string title { get; set; }

        public string description { get; set; }

        public bool completed { get; set; }
        
        public ImageSource image { get; set; }

        public DateTimeOffset date { get; set; }
        //日期字段自己写

        public TodoItem(string title, string description, DateTimeOffset date, ImageSource image)
        {
            this.id = Guid.NewGuid().ToString(); //生成id
            this.title = title;
            this.description = description;
            this.completed = false; //默认为未完成
            this.date = date;
            this.image = image;
        }
    }
}
