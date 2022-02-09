using System.Collections.Generic;
using System.Linq;

namespace eVoting.Model.Response
{
    public class ResponseModel<T>
    {
        public IDictionary<string, List<string>> Errors { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public int StatusCode { get; set; }
        public bool Success => !Errors.Any();

        public ResponseModel()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        #region Errors
        public void AddError(string key, string error)
        {
            if (Errors.ContainsKey(key))
                Errors[key].Add(error);
            else
                Errors.Add(key, new List<string> { error });
        }
        public void AddErrors(string key, List<string> errors)
        {
            if (Errors.ContainsKey(key))
                Errors[key].AddRange(errors);
            else
                Errors.Add(key, errors);
        }
        public void AddErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var error in errors)
            {
                AddErrors(error.Key, error.Value);
            }
        }
        #endregion

        public ResponseModel<T> NotFound()
        {
            StatusCode = 404;
            return this;
        }

        public ResponseModel<T> BadRequest()
        {
            StatusCode = 400;
            return this;
        }

        public ResponseModel<T> Ok()
        {
            StatusCode = 200;
            return this;
        }

        public ResponseModel<T> Ok(T data)
        {
            StatusCode = 200;
            Data = data;

            return this;
        }

        public ResponseModel<T> AddMessage(string message)
        {
            Message = message;

            return this;
        }

        public ResponseModel<T> Created(T data)
        {
            StatusCode = 201;
            Data = data;

            return this;
        }

        public ResponseModel<T> Unauthorized()
        {
            StatusCode = 401;

            return this;
        }

        public ResponseModel<T> NotModified()
        {
            StatusCode = 304;

            return this;
        }
    }
}
