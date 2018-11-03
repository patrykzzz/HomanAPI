namespace Homan.BLL.Utilities
{
    public class Result<T> where T : class
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }

        private Result(T data, bool succeeded = true)
        {
            Data = data;
            Succeeded = succeeded;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data);
        }

        public static Result<T> Fail()
        {
            return new Result<T>(null, false);
        }
    }
}