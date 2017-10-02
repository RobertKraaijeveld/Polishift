using System;
using UnityEngine;

internal class StringInterpolationTest : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("<color=yellow>String Interpolation:</color>");

        var x = 100;
        var y = 200;

        Debug.Log($"x = {x}, y = {y}");
        Debug.Log($"x > y = {x > y}");

        var id = 100;
        var name = "???Alice???";
        string simpleUrl = $"http://foobar/item/{id}/{name}";

        /* This explicit initialization of escapedUrl and escapedUrl2 is required
         * because otherwise Mono C# compiler version 4.6.2.0 generates two errors:
         * 
         * error CS0165: Use of unassigned local variable `escapedUrl'
         * error CS0165: Use of unassigned local variable `escapedUrl2'
         */
        string escapedUrl = null;
        string escapedUrl2 = null;

        escapedUrl = Url($"http://foobar/item/{id}/{name}");
        escapedUrl2 = Url($"http://foobar/item/{id}/{name:b}");
        Debug.Log(simpleUrl);
        Debug.Log(escapedUrl);
        Debug.Log(escapedUrl2);

        Debug.Log("");
    }

    private static string Url(FormattableString formattable)
    {
        return formattable.ToString(new UrlFormatProvider());
    }
}

internal class UrlFormatProvider : IFormatProvider
{
    private readonly UrlFormatter formatter = new UrlFormatter();

    public object GetFormat(Type formatType)
    {
        if (formatType == typeof(ICustomFormatter))
        {
            return formatter;
        }
        return null;
    }

    private class UrlFormatter : ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
            {
                return string.Empty;
            }
            if (format == "b")
            {
                return arg.ToString().Trim('?') + "-and-Bob";
            }
            return Uri.EscapeDataString(arg.ToString());
        }
    }
}