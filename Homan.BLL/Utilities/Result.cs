namespace Homan.BLL.Utilities
{
    public class Result<T> where T : class
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }

        public Result()
        {
            
        }

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

    public class Result
    {
        public bool Succeeded { get; set; }

        private Result(bool succeeded = true)
        {
            Succeeded = succeeded;
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Fail()
        {
            return new Result(false);
        }
    }
}