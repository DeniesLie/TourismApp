using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Page : Responce, IDisplayable
    {
        Content _content;

        public Page(string title, Content content, Options opt)
        {
            _title = title;
            _content = content;
            _opts = new Options(opt);
        }
        public Page(string title, string text, Options opt)
        {
            _title = title;
            _content = new Content(text);
            _opts = new Options(opt);
        }

        public override void Display()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine($"|{_title}|");
            if (_content != null)
                _content.Display();
            if (_opts != null)
                _opts.Display();
            Console.WriteLine();
        }
    }
}
