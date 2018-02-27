namespace ConZole.Common
{
    using System.IO;

    public class HostContext
    {
        public TextWriter Out { get; set; }
        public TextReader In { get; set; }
        public TextWriter Error { get; set; }
    }
}
