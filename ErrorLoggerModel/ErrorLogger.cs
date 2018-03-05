
namespace ErrorLoggerModel
{
    public class ErrorClass
    {
        public int ApplicationId { get; set; }
        public int Loglevel { get; set; }
        public string ErrorText { get; set; }

        public ErrorClass(int id, int level, string error)
        {
            this.ApplicationId = id;
            this.Loglevel = level;
            this.ErrorText = error;
        }
        public override string ToString()
        {
            return string.Format("ApplicationId: {0}, Error: {1}, Loglevel:{2}", this.ApplicationId, this.ErrorText, this.Loglevel);
        }
    }
}
