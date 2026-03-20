namespace Models
{
    public class LogEntry
    {
        public string IP { get; set; }
        public DateTime Timestamp { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public int StatusCode { get; set; }
        public int Size { get; set; }
        public string UserAgent { get; set; }
        public string Referer { get; set; }
    }
}
