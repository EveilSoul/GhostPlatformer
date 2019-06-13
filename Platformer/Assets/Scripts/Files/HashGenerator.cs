using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class HashGenerator
{
    public static string Encript(this string data)
    {
        var bulder = new StringBuilder();
        foreach(var e in data)
        {
            var charCode = (int)e;
            charCode += 15;
            
            bulder.Append((char)charCode);
        }
        return bulder.ToString();
    }

    public static string Decript(this string data)
    {
        var bulder = new StringBuilder();
        foreach (var e in data)
        {
            var charCode = (int)e;
            charCode -= 15;

            bulder.Append((char)charCode);
        }
        return bulder.ToString();
    }

}

